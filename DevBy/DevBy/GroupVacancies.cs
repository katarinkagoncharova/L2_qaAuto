using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBy
{
    public class GroupVacancies
    {
        public string Specialization { get; set; }
        public int CountVacancies { get; set; }

        public GroupVacancies(string specialization, int countVacancies) 
        {
            Specialization = specialization;
            CountVacancies = countVacancies;
        }
    }
}
