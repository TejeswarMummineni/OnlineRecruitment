using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using BussinessEntites;

namespace DataAccessLayer
{
    public class CompanyDAL
    {
        OnlineRecruitmentEntities db = new OnlineRecruitmentEntities();
        public int Newreq(NewRequirmentEntites ne)
        {
            try
            {
               
                var cd = db.NewRequirments.OrderByDescending(t => t.Requirmentid).FirstOrDefault();
                
                if (cd == null)
                {
                    ne.Requirmentid = "REQ10000";
                }
                else
                {
                    ne.Requirmentid = "REQ" + (Convert.ToInt32(cd.Requirmentid.Substring(3, 5)) + 1).ToString();
                }
                NewRequirment c = new NewRequirment()
                {
                    Requirmentid = ne.Requirmentid,
                    EmployeeId = ne.EmployeeId,
                    CompanyId = ne.CompanyId,
                    jobtype = ne.jobtype,
                    candidatereq = ne.candidatereq,
                    Location = ne.Location,
                    PostedDate = ne.PostedDate,
                    JobDesc = ne.JobDesc,
                    LastDate = ne.LastDate,
                    JobName = ne.JobName,
                    Status = true,
                    Salary = ne.Salary
                };
                db.NewRequirments.Add(c);
                db.SaveChanges();
                return 1;
            }
           
            catch(Exception e)
            {
                return 0;
            }
        }
        public List<JobApplicantEntites> SelectCandidate(CompanyPortalEntites cp)
        {
            var cmp = db.CompanyPortals.Where(x => x.Email == cp.Email);
            foreach (var item in cmp)
            {
                cp.CompanyId = item.CompanyId; 
            }
            var job = db.JobPostings.Where(x => x.CompanyId == cp.CompanyId);
            JobPostingEntites jb = new JobPostingEntites();
            foreach (var item in job)
            {
                jb.JobId = item.JobId;
            }
            SelectedCandidateEntites se = new SelectedCandidateEntites();
            var res = db.SelectedCandidates.Where(x => x.JobId == jb.JobId);
            List<JobApplicantEntites> li = new List<JobApplicantEntites>();
            foreach (var item in res)
            {
                se.CandidateId = item.CandidateId;
            }
            var can = db.JobApplicants.Where(x => x.CandidateId == se.CandidateId);
            foreach (var ite in can)
            {
                li.Add(new JobApplicantEntites()
                {
                    CandidateId = ite.CandidateId,
                    Name = ite.Name,
                    Dob = ite.Dob,
                    Phone = ite.Phone,
                    Email = ite.Email,
                    Gender = ite.Gender,
                    UniversityName = ite.UniversityName,
                    Location = ite.Location
                });
            }
            return li;
        }
        public List<RejectedEntites> rejectedpost(CompanyPortalEntites cp)
        {
            var res = db.CompanyPortals.Where(x => x.Email == cp.Email);
            foreach (var item in res)
            {
                cp.CompanyId = item.CompanyId;
            }
            List<RejectedEntites> li = new List<RejectedEntites>();
            var rej = db.Rejecteds.Where(x => x.CompanyId == cp.CompanyId);
            foreach (var item in rej)
                {
                li.Add(new RejectedEntites(){ 
                    Rejectedid=item.Rejectedid,
                    CompanyId=item.CompanyId,
                    CompanyDesc=item.CompanyDesc,
                    jobtype=item.jobtype,
                    candidatereq=item.candidatereq,
                    Location=item.Location,
                    jobName=item.jobName,
                    PostDate=item.PostDate,
                    LastDate=item.LastDate
                });
               
            }
            return li;
        }
    }

}

