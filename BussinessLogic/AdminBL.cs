using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessEntites;
using DataAccessLayer;

namespace BussinessLogic
{
    public class AdminBL
    {
        AdminDAL ad = new AdminDAL();
        public AdminEntites Registered(AdminEntites ae)
        {
            return ad.Registered(ae);
        }
        public List<JobApplicantEntites> RegisterUser(string Search)
        {
            return ad.RegisterUser(Search);
        }
        public List<CompanyPortalEntites> RegistredCompines(string Search)
        {
            return ad.RegistredCompines(Search);
        }
        public List<JobApplicantEntites> PLacedApplicants()
        {
            return ad.PLacedApplicants();
        }
        public List<JobPostingEntites> JanuaryMonthApplieds()
        {
            return ad.JanuaryMonthApplieds();
        }
        public List<JobApplicantEntites> TotalApplied()
        {
            return ad.TotalApplied();
        }
        public List<NewRequirmentEntites> NewRequirment()
        {
            return ad.NewRequirment();
        }
        public int PostApprove(NewRequirmentEntites ne)
        {
            return ad.PostApprove(ne);
        }
        public int PostReject(NewRequirmentEntites ne)
        {
            return ad.PostReject(ne);
        }
         public JobApplicantEntites Gamil(JobApplicantEntites ge)
        {
            return ad.Gamil(ge);
        }
    }
}
