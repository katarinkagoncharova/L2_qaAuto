using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rambler
{
    public class RamblerHomePage: RamblerBasePage
    {
        IWebElement _buttonMail;
        IWebElement _inputLogin;
        IWebElement _inputPassword;
        IWebElement _buttonComeIn;

        const string SITE_BUTTON_MAIL = "//a[text()='Войти в почту']";
        const string SITE_INPUT_LOGIN = "//input[@id='login']";
        const string SITE_INPUT_PASSWORD = "//input[@id='password']";
        const string SITE_BUTTON_COME_IN = "//span[@class='rui-Button-content']";


        
        public RamblerHomePage(IWebDriver driver) : base(driver)
        {
            GoToUrl("https://www.rambler.ru/");
            InitializeButtonMail();
        }

        private void InitializeButtonMail()
        {
            _buttonMail = FindDRamblerElement(SITE_BUTTON_MAIL);

        }

        public void ClickButtonMail()
        {
            ClickElement(_buttonMail);
        }

        public void LogIn(string mail, string password)
        {
            _inputLogin = FindDRamblerElement(SITE_INPUT_LOGIN);
            _inputPassword = FindDRamblerElement(SITE_INPUT_PASSWORD);
            _buttonComeIn = FindDRamblerElement(SITE_BUTTON_COME_IN);
            _inputLogin.SendKeys(mail);
            _inputPassword.SendKeys(password);
            ClickElement(_buttonComeIn);
        }


    }
}
