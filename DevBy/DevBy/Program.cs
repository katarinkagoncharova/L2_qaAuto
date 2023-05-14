using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;
namespace DevBy
{
    public class Program
    {
        static void Main(string[] args)
        {

            IWebDriver driver = new ChromeDriver();
            HomePage devByioPage = new HomePage(driver);
            var a = devByioPage.GetCountVacancies();
            VacanciesPage pageVac = devByioPage.ClickButtonVacancies();
            var count = pageVac.GetAllVacancies();
            var sumVac = count.Select(x => x.CountVacancies).Sum();

            var c = count.OrderBy(x => x.CountVacancies).Reverse().ToList().Select(x => x.Specialization);

            foreach (var i in c) 
            {
                Console.WriteLine(i);
            }

            driver.Quit();

            

        }
    }
}