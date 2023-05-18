using OpenQA.Selenium;
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
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            Thread.Sleep(1000);
            var a = driver.WindowHandles.Count();
            var b = driver.WindowHandles;
            driver.SwitchTo().Window(b[0]);
            //driver.SwitchTo().Alert();

         
            //var element = ramblerPage.FindRamblerElements("//input[@id='login']");

            var s = driver.FindElement(By.XPath("//input[@id='login']"));

            
            

            driver.SwitchTo().Window(driver.WindowHandles.Last());


            //var m = driver.FindElement(By.XPath("//html[@class='no-js']"));
            //var g = driver.FindElement(By.XPath("//form//input[@id='login']"));
            //var tmp = driver.FindElement(By.XPath("//form//section//div//div[@class='rui-FieldStatus-error']"));
            ramblerPage.LogIn("test_user_10000@rambler.ru", "Test00001");
            //IList<IWebElement> all = driver.FindElements(By.TagName("input"));
            //PopupWindowFinder
            
            //driver.switch_to_popup(driver.window_handles())

            //loginpage.LogIn("test_user_10000@rambler.ru", "Test00001");

            Console.WriteLine("Hello");
        }
    }
}