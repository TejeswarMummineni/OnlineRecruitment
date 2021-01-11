using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessEntites;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class WelcomeDAL
    {
        OnlineRecruitmentEntities db = new OnlineRecruitmentEntities();
        public List<JobPostingEntites> Welcomepage(string Search)
        {
            List<JobPostingEntites> po = new List<JobPostingEntites>();
            var res = db.JobPostings.Where(x => x.JobType.StartsWith(Search) || Search == null);
            foreach (var item in res)
            {
                po.Add(new JobPostingEntites()
                {
                    JobId = item.JobId,
                    JobName =item.JobName,
                    JobType=item.JobType,
                    JobDescription=item.JobDescription,
                    CompanyId=item.CompanyId,
                    Location=item.Location,
                    PostedDate=item.PostedDate,
                    LastDate=item.LastDate
                   
                });
                
            }
            return po;
        }
    }
}
