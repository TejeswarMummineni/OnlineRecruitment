using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessEntites;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class JobAppliedDAL
    {
        string Id;
        int a;
        OnlineRecruitmentEntities db = new OnlineRecruitmentEntities();
        public int CandidateClick(JobAppliedEntites ja, String Email)
        {
            var con = db.JobApplicants.Where(x => x.Email == Email);
            foreach (var item in con)
            {
                Id = item.CandidateId;
            }
            var res2 = db.JobApplieds.Where(x => x.CandidateId == Id).Count();
            var res = db.JobPostings.Where(x => x.JobId == ja.JobId).Count();
            if(res < 0 && res2 >0 )
            {
                a=0;
            }
            else
            {
                JobApplied j = new JobApplied()
                {
                    JobId = ja.JobId,
                    CandidateId=Id,
                    Status=false  
                };
                db.JobApplieds.Add(j);
                db.SaveChanges();
                a = 1;
            }
            return a;
        }
    }
}
