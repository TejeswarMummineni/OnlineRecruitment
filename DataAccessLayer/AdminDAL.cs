using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessEntites;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class AdminDAL
    {
        
        OnlineRecruitmentEntities db = new OnlineRecruitmentEntities();
        public AdminEntites Registered(AdminEntites ae)
        {
            int a = 0, b = 0, c = 0, d = 0, e = 0;
            var app = db.JobApplicants.Where(x => x.CandidateId.StartsWith("APP"));
            foreach (var item in app)
            {
                a++;
            }
            var cmp = db.CompanyPortals.Where(x => x.CompanyId.StartsWith("CMP"));
            foreach (var item in cmp)
            {
                b++;
            }
            var placed = db.JobApplieds.Where(x => x.Status == true);
            foreach (var item in placed)
            {
                c++;
            }
            var btw = db.JobPostings.Where(x => x.PostedDate.Year == 2020 && x.PostedDate.Month == 01);
            foreach (var item in btw)
            {
                d++;
            }
            var apply = db.JobApplieds.Where(x => x.CandidateId.StartsWith("APP"));
            foreach (var item in apply)
            {
                e++;
            }
            ae.RegisterUsers = a;
            ae.RegisterCompines = b;
            ae.gotplaced =c;
            ae.reqmonth = d;
            ae.usersapplied= e;

            return ae;
        }
        public List<JobApplicantEntites> RegisterUser(string Search)
        {
            var app = db.JobApplicants.Where(x => x.CandidateId.StartsWith(Search)||Search==null);
            List<JobApplicantEntites> li = new List<JobApplicantEntites>();
            foreach (var item in app)
            {
                li.Add(new JobApplicantEntites()
                {
                    CandidateId=item.CandidateId,
                    Name=item.Name,
                    Dob=item.Dob,
                    Phone=item.Phone,
                    Email=item.Email,
                    Gender=item.Gender,
                    UniversityName=item.UniversityName,
                    Location=item.Location
                });
            }
            return li;
        }
        public List<CompanyPortalEntites> RegistredCompines(string Search)
        {
            var cmp = db.CompanyPortals.Where(x => x.CompanyId.StartsWith(Search)|| Search==null);
            List<CompanyPortalEntites> li = new List<CompanyPortalEntites>();
            foreach (var item in cmp)
            {
                li.Add(new CompanyPortalEntites()
                {
                    CompanyId = item.CompanyId,
                    CompanyName = item.CompanyName,
                    CompanyDesc = item.CompanyDesc,
                    Email = item.Email,
                    Logo = item.Logo,
                    Location = item.Location,
                });
            }
            return li;
        }
        public List<JobApplicantEntites> PLacedApplicants()
        {
            
            List<JobApplicantEntites> li = new List<JobApplicantEntites>();
            var placed = db.JobApplieds.Where(x => x.Status == true);
            foreach (var item in placed)
            {
                var id = item.CandidateId;
                var app = db.JobApplicants.Where(x => x.CandidateId==id);
                foreach (var i in app)
                {
                    li.Add(new JobApplicantEntites()
                    {
                        CandidateId =i.CandidateId,
                        Name = i.Name,
                        Dob = i.Dob,
                        Phone = i.Phone,
                        Email = i.Email,
                        Gender = i.Gender,
                        UniversityName = i.UniversityName,
                        Location = i.Location
                    });
                }
            }
            return li;
        }
        public List<JobPostingEntites> JanuaryMonthApplieds()
        {
            var btw = db.JobPostings.Where(x => x.PostedDate.Year == 2020 && x.PostedDate.Month == 01);
            List<JobPostingEntites> li = new List<JobPostingEntites>();
            foreach (var item in btw)
            {
                li.Add(new JobPostingEntites()
                {
                    JobId=item.JobId,
                    JobName=item.JobName,
                    CompanyId=item.CompanyId,
                    JobType=item.JobType,
                    JobDescription=item.JobDescription,
                    Location=item.Location,
                    CandidateReq=item.CandidateReq,
                    PostedDate=item.PostedDate,
                    LastDate=item.LastDate
                });
            }
            return li;
        }
        public List<JobApplicantEntites> TotalApplied()
        {

            List<JobApplicantEntites> li = new List<JobApplicantEntites>();
            var apply = db.JobApplieds.Where(x => x.CandidateId.StartsWith("APP"));
            foreach (var item in apply)
            {
                var id = item.CandidateId;
                var app = db.JobApplicants.Where(x => x.CandidateId == id);
                foreach (var i in app)
                {
                    li.Add(new JobApplicantEntites()
                    {
                        CandidateId = i.CandidateId,
                        Name = i.Name,
                        Dob = i.Dob,
                        Phone = i.Phone,
                        Email = i.Email,
                        Gender = i.Gender,
                        UniversityName = i.UniversityName,
                        Location = i.Location
                    });
                }
            }
            return li;
        }
    }
}