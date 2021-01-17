using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessEntites;
using DataAccessLayer;

namespace BussinessLogic
{
    public class WelcomeBL
    {
        WelcomeDAL wd = new WelcomeDAL();
        public List<JobPostingEntites> Welcomepage(string Search)
        {
           return wd.Welcomepage(Search);
        }
        public List<JobPostingEntites> PreviousPost(string Search)
        {
            return wd.PreviousPost(Search);
        }
        public List<TestResultEntites> SelectedCandidates()
        {
            return wd.SelectedCandidates();
        }
        public int companyportal(CompanyPortalEntites cp)
        {
            return wd.companyportal(cp);
        }
    }

}
