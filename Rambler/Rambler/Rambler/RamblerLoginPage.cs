using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rambler
{
    public class RamblerLoginPage: RamblerBasePage
    {
        /*IWebElement _inputLogin;
        IWebElement _inputPassword;
        IWebElement _buttonComeIn;
        const string SITE_INPUT_LOGIN = "//input[@id='login']";
        const string SITE_INPUT_PASSWORD = "//input[@id='password']";
        const string SITE_BUTTON_COME_IN = "//span[@class='rui-Button-content']";*/

        public RamblerLoginPage(IWebDriver driver) : base(driver)
        {
           /* _inputLogin = FindDRamblerElement(SITE_INPUT_LOGIN);
            _inputPassword = FindDRamblerElement(SITE_INPUT_PASSWORD);
            _buttonComeIn = FindDRamblerElement(SITE_BUTTON_COME_IN);*/

        }

        /*public void LogIn(string mail, string password) 
        {
            _inputLogin.SendKeys(mail);
            _inputPassword.SendKeys(password);
            ClickElement(_buttonComeIn);
            //return new RamblerPersonalMailPage(_driver);
        }*/

    }
}
