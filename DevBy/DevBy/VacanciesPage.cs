using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Globalization;

namespace DevBy
{
    public class VacanciesPage : DevByBasePage
    {
        ReadOnlyCollection<IWebElement> _listSpecialization;
        IWebElement _jobsBot;
        const string SITE_PARTS_SPECIALIZATION = "//label[@class = 'collection_radio_buttons']";
        const string COUNT_VACANCIES = "//h1[@class='vacancies-list__header-title']";
        const string JOBS_BOT = "//button[@class='wishes-popup__button-close wishes-popup__button-close_icon']";


        public VacanciesPage(IWebDriver driver) : base(driver)
        {
            CloseJobsBot();
            _listSpecialization = FindDevByElements(SITE_PARTS_SPECIALIZATION);

        }
                
        public int GetNumberFromText(string text)
        {
            string res = "";
            foreach (char i in text)
            {
                if (Char.GetUnicodeCategory(i) == UnicodeCategory.DecimalDigitNumber)
                {
                    res = res + i;
                }

            }
            int count = Int32.Parse(res);
            return count;
        }

  
        public void CloseJobsBot() 
        {
            _jobsBot = FindDevByElement(JOBS_BOT);
            Thread.Sleep(500);
            ClickElement(_jobsBot);
        }

        public List<GroupVacancies> GetAllVacancies()
        {
            List <GroupVacancies> allVacancies = new List<GroupVacancies>();
            foreach (IWebElement i in _listSpecialization)
            {
                string specialization = i.Text;
                ClickElement(i);
                Thread.Sleep(500);
                IWebElement countVac = FindDevByElement(COUNT_VACANCIES);
                int count = GetNumberFromText(countVac.Text);
                allVacancies.Add(new GroupVacancies(specialization, count));
            }
            return allVacancies;
        }



    }
}
