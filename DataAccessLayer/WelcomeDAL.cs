using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessEntites;
using DataAccessLayer.Models;
using PagedList;
using PagedList.Mvc;

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
                    JobDescription = item.JobDescription,
                    CompanyId = item.CompanyId,
                    Location = item.Location,
                    PostedDate=item.PostedDate,
                    LastDate=item.LastDate,
                    JobName = item.JobName,
                    JobType = item.JobType,
                    CandidateReq =item.CandidateReq
                   
                });
                
            }
            return po;
        }
    }
}
