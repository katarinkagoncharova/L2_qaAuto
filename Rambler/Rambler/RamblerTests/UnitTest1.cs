using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Rambler;
namespace RamblerTests
{
    [TestClass]
    public class RamblerTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            var ramblerPage = new RamblerHomePage(driver);
            ramblerPage.ClickButtonMail();
            ramblerPage.LogIn("test_user_10000@rambler.ru", "Test00001");
            var ramblerInBoxPage = ramblerPage.InBox();
            ramblerInBoxPage.WriteLetter("test_user_10001@rambler.ru", "First", " Hello!");
            ramblerPage = ramblerInBoxPage.SingOut();

            
            ramblerPage.ClickButtonMail();
            ramblerPage.LogIn("test_user_10001@rambler.ru", "Test10001");
            ramblerInBoxPage = ramblerPage.InBox();
            var firstLetterPage = ramblerInBoxPage.InfoFirstLetter();
            var text = firstLetterPage.GetTextFirstLetter();
            firstLetterPage.ReplyToLetter("Bye!");
            ramblerPage = firstLetterPage.SingOut();

            
            ramblerPage.ClickButtonMail();
            
            ramblerPage.LogIn("test_user_10000@rambler.ru", "Test00001");
            ramblerInBoxPage = ramblerPage.InBox();
            firstLetterPage = ramblerInBoxPage.InfoFirstLetter();
            var text2 = firstLetterPage.GetTextFirstLetter();

            Assert.AreEqual(text, "Hello!");

            driver.Quit();
        }
    }
}