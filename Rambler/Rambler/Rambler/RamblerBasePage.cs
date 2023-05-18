using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Rambler
{
    public abstract class RamblerBasePage
    {
        protected IWebDriver _driver;
        Actions _action;
        WebDriverWait _wait;

        protected RamblerBasePage(IWebDriver driver)
        {
            _driver = driver;
            _action = new Actions(driver);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        protected void GoToUrl(string url)
        {
            _driver.Url = url;
            _driver.Manage().Window.Maximize();
        }

        protected void ClickElement(IWebElement webElement)
        {
            _action.MoveToElement(webElement);
            _action.Perform();
            webElement.Click();
        }

        public ReadOnlyCollection<IWebElement> FindRamblerElements(string xPath)
        {
            return _wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(xPath)));
        }

        public IWebElement FindDRamblerElement(string xPath)
        {

            return _wait.Until(ExpectedConditions.ElementExists(By.XPath(xPath)));
        }

    }


}
