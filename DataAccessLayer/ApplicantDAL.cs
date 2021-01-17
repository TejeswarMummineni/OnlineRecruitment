using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessEntites;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class ApplicantDAL
    {
        OnlineRecruitmentEntities db = new OnlineRecruitmentEntities();
        public List<JobPostingEntites> Appliedjobs(JobApplicantEntites ja)
        {
            var job = db.JobApplicants.Where(x => x.Email == ja.Email);
            foreach (var item in job)
            {
                ja.CandidateId = item.CandidateId;
            }
            List<JobPostingEntites> li = new List<JobPostingEntites>();
            JobApplied je = new JobApplied();
            var app = db.JobApplieds.Where(x => x.CandidateId == ja.CandidateId);
            foreach (var item in app)
            {
                je.JobId = item.JobId;
            }
            var res = db.JobPostings.Where(x => x.JobId == je.JobId);
            foreach (var item in res)
            {
                li.Add(new JobPostingEntites()
                {
                    JobId = item.JobId,
                    JobName = item.JobName,
                    CompanyId = item.CompanyId,
                    JobType = item.JobType,
                    JobDescription = item.JobDescription,
                    Location = item.Location,
                    CandidateReq = item.CandidateReq,
                    PostedDate = item.PostedDate,
                    LastDate = item.LastDate
                });
            }
            return li;
        }
        public JobApplicantEntites Profile(JobApplicantEntites ja)
        {
            var job = db.JobApplicants.Where(x => x.Email == ja.Email);
            foreach (var item in job)
            {

                ja.CandidateId = item.CandidateId;
                ja.Name = item.Name;
                ja.Dob = item.Dob;
                ja.Phone = item.Phone;
                ja.Email = item.Email;
                ja.Gender = item.Gender;
                ja.UniversityName = item.UniversityName;
                ja.Location = item.Location;

            }
            return ja;
        }
        
    }
}
