using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rambler
{
    public class RamblerInBoxPage: RamblerBasePage
    {
        IWebElement _writeLetter;
        IWebElement _recipient;
        IWebElement _topic;
        IWebElement _textLetter;
        IWebElement _sendLetter;
        IWebElement _accountFeatures;
        IWebElement _buttonExit;
        ReadOnlyCollection<IWebElement> _letters;
        
        
        const string SITE_BUTTON_WRITE_LETTER = "//span[text()='Написать']";
        const string INPUT_RECIPIENT = "//input[@id='receivers']";
        const string INPUT_TOPIC = "//input[@id='subject']";
        const string INPUT_TEXT = "//iframe[@id='editor_ifr']";
        const string BUTTON_SEND_LETTER = "//span[text()='Отправить']";
        const string BUTTON_ACCOUNT_FEATURES = "//span[@class='rc__Q7HP8']";
        const string BUTTON_EXIT = "//button[text()='Выход']";
        const string LETTERS = "//a[@class = 'ListItem-root-1i ListItem-unseen-kd']";
        public RamblerInBoxPage(IWebDriver driver) : base(driver)
        {
            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            InitializeButtonWriteLetter();

        }

        private void InitializeButtonWriteLetter() 
        {
            Thread.Sleep(1000);
            _writeLetter = FindDRamblerElement(SITE_BUTTON_WRITE_LETTER);
            
        }

        public void WriteLetter(string recipient, string topic, string text)
        {
            ClickElement(_writeLetter);
            _recipient = FindDRamblerElement(INPUT_RECIPIENT);
            _topic = FindDRamblerElement(INPUT_TOPIC);
            _textLetter = FindDRamblerElement(INPUT_TEXT);
            _sendLetter = FindDRamblerElement(BUTTON_SEND_LETTER);
            _recipient.SendKeys(recipient);
            _topic.SendKeys(topic);
            _textLetter.SendKeys(text);
            ClickElement(_sendLetter);
            Thread.Sleep(15000);


        }
        public RamblerHomePage SingOut() 
        {
            _accountFeatures = FindDRamblerElement(BUTTON_ACCOUNT_FEATURES);
            ClickElement(_accountFeatures);
            _buttonExit = FindDRamblerElement(BUTTON_EXIT);
            ClickElement(_buttonExit);
            return new RamblerHomePage(_driver);
        }

        public RamblerLetterPage InfoFirstLetter()
        {
            _letters = FindRamblerElements(LETTERS);
            ClickElement(_letters.First());
            return new RamblerLetterPage(_driver);
        }

    }

}
