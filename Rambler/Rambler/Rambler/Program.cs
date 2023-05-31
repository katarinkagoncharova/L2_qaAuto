﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Reflection.Metadata;
using OpenQA.Selenium.Support.Events;

namespace Rambler
{
    public class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            var ramblerPage = new RamblerHomePage(driver);
            ramblerPage.ClickButtonMail();
            ramblerPage.LogIn("test_user_10000@rambler.ru", "Test00001");
            var ramblerInBoxPage = ramblerPage.InBox();
            ramblerInBoxPage.WriteLetter("test_user_10001@rambler.ru", "First", " Hello!");
            ramblerPage = ramblerInBoxPage.SingOut();

            Thread.Sleep(1000);
            ramblerPage.ClickButtonMail();
            ramblerPage.LogIn("test_user_10001@rambler.ru", "Test10001");
            ramblerInBoxPage = ramblerPage.InBox();
            var firstLetterPage = ramblerInBoxPage.InfoFirstLetter();
            var text = firstLetterPage.GetTextFirstLetter();
            firstLetterPage.ReplyToLetter("Bye!");
            ramblerPage = firstLetterPage.SingOut();

            Thread.Sleep(1000);
            ramblerPage.ClickButtonMail();
            ramblerPage.LogIn("test_user_10000@rambler.ru", "Test00001");
            ramblerInBoxPage = ramblerPage.InBox();
            firstLetterPage = ramblerInBoxPage.InfoFirstLetter();
            var text2 = firstLetterPage.GetTextFirstLetter();

            driver.Quit();
            
            Console.WriteLine("Hello");
        }
    }
}