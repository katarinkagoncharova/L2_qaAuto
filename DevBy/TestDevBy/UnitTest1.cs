using DevBy;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace TestDevBy
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver _driver;

        [TestInitialize]
        public void BeforeTest()
        {
            _driver = new ChromeDriver();
        }
        
        [TestMethod]
        public void CheckCountVacansies()
        {
            HomePage devByioPage = new HomePage(_driver);
            var countVac = devByioPage.GetCountVacancies();
            VacanciesPage pageVac = devByioPage.ClickButtonVacancies();
            var count = pageVac.GetAllVacancies();
            var sumVac = count.Select(x => x.CountVacancies).Sum();
            Assert.AreEqual(countVac, sumVac);
        }

        [TestCleanup]
        public void AfterTest() 
        {
            _driver.Quit();
        }
    }
}