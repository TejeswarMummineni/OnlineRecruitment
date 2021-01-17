using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BussinessEntites;

namespace BussinessLogic
{
    public class ApplicantBL
    {
        ApplicantDAL ad = new ApplicantDAL();
        public List<JobPostingEntites> Appliedjobs(JobApplicantEntites ja)
        {
            return ad.Appliedjobs(ja);
        }
        public JobApplicantEntites Profile(JobApplicantEntites ja)
        {
            return ad.Profile(ja);
        }
    }
}
