using OpenQA.Selenium;
using System.Globalization;

namespace DevBy
{
    public class HomePage: DevByBasePage
    {
        IWebElement _buttonVacancies;
        const string SITE_BUTTON_VACANCIES = "//a[@class='navbar__nav-item navbar__nav-item_label']";
        const string SITE_LIST_VACANCIES = "//h2[@class='informer__title']//a[@href='https://jobs.devby.io']";


        public HomePage(IWebDriver driver) : base(driver)
        {
            GoToUrl("https://devby.io/");
            InitializeButtonVacancies();
        }


        private void InitializeButtonVacancies()
        {
            _buttonVacancies = FindDevByElement(SITE_BUTTON_VACANCIES);
           
        }

        public VacanciesPage ClickButtonVacancies() 
        {
            ClickElement(_buttonVacancies);
            return new VacanciesPage(_driver);
        }

        public int GetCountVacancies()
        {

            var elementText = FindDevByElement(SITE_LIST_VACANCIES).Text;
            string res = "";
            foreach (char i in elementText)
            {
                if (Char.GetUnicodeCategory(i) == UnicodeCategory.DecimalDigitNumber)
                {
                    res = res + i;
                }

            }
            int count = Int32.Parse(res);
            return count;


        }




    }
}
