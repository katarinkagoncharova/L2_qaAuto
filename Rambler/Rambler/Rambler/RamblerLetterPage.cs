using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rambler
{
    public class RamblerLetterPage : RamblerBasePage
    {
        IWebElement _textLetter;
        IWebElement _replyBox;
        IWebElement _sendReply;
        IWebElement _accountFeatures;
        IWebElement _buttonExit;

        const string TEXT_LETTER = "//div[@class='messageBody']";
        const string REPLY_BOX = "//textarea";
        const string BUTTON_SEND_REPLY = "//span[text()='Отправить']";
        const string BUTTON_ACCOUNT_FEATURES = "//span[@class='rc__Q7HP8']";
        const string BUTTON_EXIT = "//button[text()='Выход']";

        public RamblerLetterPage(IWebDriver driver) : base(driver)
        {
            _textLetter = FindDRamblerElement(TEXT_LETTER);
            _replyBox = FindDRamblerElement(REPLY_BOX);
        }

        public string GetTextFirstLetter()
        {
            return _textLetter.Text;
        }

        public void ReplyToLetter(string text) 
        {
            _replyBox.SendKeys(text);
            _sendReply = FindDRamblerElement(BUTTON_SEND_REPLY);
            ClickElement(_sendReply);

        }

        public RamblerHomePage SingOut()
        {
            _accountFeatures = FindDRamblerElement(BUTTON_ACCOUNT_FEATURES);
            ClickElement(_accountFeatures);
            _buttonExit = FindDRamblerElement(BUTTON_EXIT);
            ClickElement(_buttonExit);
            return new RamblerHomePage(_driver);
        }

    }
}
