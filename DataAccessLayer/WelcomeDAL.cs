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
        public List<JobPostingEntites> PreviousPost(string Search)
        {

            var res = db.JobPostings.Where(x => x.JobType.Contains(Search) || x.JobName.Contains(Search) || x.JobDescription.Contains(Search) || x.Location.Contains(Search));
            List<JobPostingEntites> job = new List<JobPostingEntites>();
            foreach (var item in res)
            {
                job.Add(new JobPostingEntites() { JobId = item.JobId, JobName = item.JobName, JobType = item.JobType, PostedDate = item.PostedDate, LastDate = item.LastDate, CandidateReq = item.CandidateReq });
            }
            return job;
        }



        public List<TestResultEntites> SelectedCandidates()
        {
            var mks = db.TestResults.Where(x => x.Marks > 5);
            List<TestResultEntites> li = new List<TestResultEntites>();
            foreach (var item in mks)
            {
                li.Add(new TestResultEntites()
                {
                    JobId = item.JobId,
                    TestId = item.TestId,
                    CandidateId = item.CandidateId
                });
            }
            return li;
        }
        public int companyportal(CompanyPortalEntites cp)
        {

            var cmpid = db.CompanyPortals.OrderByDescending(s => s.CompanyId).FirstOrDefault();
            if (cmpid == null)
            {
                cp.CompanyId = "CMP10000";
            }
            else
            {
                cp.CompanyId = "CMP" + (Convert.ToInt32(cmpid.CompanyId.Substring(3, 5)) + 1).ToString();
            }
            CompanyPortal st = new CompanyPortal()
            {
                CompanyId = cp.CompanyId,
                CompanyName = cp.CompanyName,
                Email = cp.Email,
                Password = cp.Password,
                CompanyDesc = cp.CompanyDesc,
                Location = cp.Location,
                Logo = cp.Logo
            };
            db.CompanyPortals.Add(st);
            return db.SaveChanges();

        }
    }
}
