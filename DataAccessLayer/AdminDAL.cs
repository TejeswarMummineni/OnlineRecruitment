﻿using System;
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
            int a = 0, b = 0, c = 0, d = 0, e = 0, f = 0;
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
            var newreq = db.NewRequirments.Where(x => x.Requirmentid.StartsWith("req") && x.Status==true);
            foreach (var item in newreq)
            {
                f++;
            }
            ae.RegisterUsers = a;
            ae.RegisterCompines = b;
            ae.gotplaced = c;
            ae.reqmonth = d;
            ae.usersapplied = e;
            ae.newrequirment = f;
            return ae;
        }
        public List<JobApplicantEntites> RegisterUser(string Search)
        {
            var app = db.JobApplicants.Where(x => x.CandidateId.StartsWith(Search) || Search == null);
            List<JobApplicantEntites> li = new List<JobApplicantEntites>();
            foreach (var item in app)
            {
                li.Add(new JobApplicantEntites()
                {
                    CandidateId = item.CandidateId,
                    Name = item.Name,
                    Dob = item.Dob,
                    Phone = item.Phone,
                    Email = item.Email,
                    Gender = item.Gender,
                    UniversityName = item.UniversityName,
                    Location = item.Location
                });
            }
            return li;
        }
        public List<CompanyPortalEntites> RegistredCompines(string Search)
        {
            var cmp = db.CompanyPortals.Where(x => x.CompanyId.StartsWith(Search) || Search == null);
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
        public List<JobPostingEntites> JanuaryMonthApplieds()
        {
            var btw = db.JobPostings.Where(x => x.PostedDate.Year == 2020 && x.PostedDate.Month == 01);
            List<JobPostingEntites> li = new List<JobPostingEntites>();
            foreach (var item in btw)
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
        public List<NewRequirmentEntites> NewRequirment()
        {
            var newreq = db.NewRequirments.Where(x => x.Requirmentid.StartsWith("req"));
            List<NewRequirmentEntites> li = new List<NewRequirmentEntites>();
            foreach (var item in newreq)
            {
                li.Add(new NewRequirmentEntites()
                {
                    Requirmentid = item.Requirmentid,
                    CompanyId = item.CompanyId,
                    JobDesc = item.JobDesc,
                    jobtype = item.jobtype,
                    Location = item.Location,
                    candidatereq = item.candidatereq

                });
            }
            return li;
        }
        public int PostApprove(NewRequirmentEntites ne)
        {
            try
            {
                string jobid;
                var res = db.NewRequirments.Where(x => x.Requirmentid == ne.Requirmentid && x.Status == true);
                var cd = db.JobPostings.OrderByDescending(t => t.JobId).FirstOrDefault();
                if (cd == null)
                {
                    jobid = "JOB10000";
                }
                else
                {
                    jobid = "JOB" + (Convert.ToInt32(cd.JobId.Substring(3, 5)) + 1).ToString();
                }
                if (res.Count() > 0)
                {
                    foreach (var item in res)
                    {
                        JobPosting j = new JobPosting()
                        {
                            JobId = jobid,
                            JobDescription = item.JobDesc,
                            CompanyId = item.CompanyId,
                            Location = item.Location,
                            PostedDate = item.PostedDate,
                            LastDate = item.LastDate,
                            Status = true,
                            JobName = item.JobName,
                            JobType = item.jobtype,
                            CandidateReq = item.candidatereq

                        };
                        db.JobPostings.Add(j);
                    }
                    db.NewRequirments.Remove(res.First());
                    db.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch(Exception e)
            {
                return 0;
            }

        }
        public int PostReject(NewRequirmentEntites ne)
        {
            string rejid;
            try
            {

                var res = db.NewRequirments.Where(x => x.Requirmentid == ne.Requirmentid);
                var cd = db.Rejecteds.OrderByDescending(t => t.Rejectedid).FirstOrDefault();
                if (cd == null)
                {
                    rejid = "REJ10000";
                }
                else
                {
                    rejid = "REJ" + (Convert.ToInt32(cd.Rejectedid.Substring(3, 5)) + 1).ToString();
                }
                if (res.Count() > 0)
                {
                    foreach (var item in res)
                    {
                        Rejected j = new Rejected()
                        {
                            Rejectedid=rejid,
                            EmployeeId = item.EmployeeId,
                            CompanyDesc = item.JobDesc,
                            CompanyId = item.CompanyId,
                            Location = item.Location,
                            PostDate = item.PostedDate,
                            LastDate = item.LastDate,
                            jobName = item.JobName,
                            jobtype = item.jobtype,
                            candidatereq = item.candidatereq

                        };
                        db.Rejecteds.Add(j);
                    }
                    db.NewRequirments.Remove(res.First());
                    db.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch(Exception e)
            {
                return 0;
            }
        }
        public JobApplicantEntites Viewresume(JobApplicantEntites jp)
        {
            var newreq = db.JobApplicants.Where(x => x.CandidateId == jp.CandidateId);
            foreach (var item in newreq)
            {
                jp.resume = item.resume;
            }
            return jp;
        }
       
        public JobApplicantEntites Gamil(JobApplicantEntites ge)
        {

            var res = db.JobApplicants.Where(x => x.CandidateId == ge.CandidateId);
            if (res.Count() > 0)
            {
                foreach (var item in res)
                {
                    ge.Email = item.Email;
                }
                var change = db.JobApplieds.Where(x => x.CandidateId == ge.CandidateId);
                foreach (var item in change)
                {
                    item.Status = true;
                }
                db.SaveChanges();
                return ge;
            }
            return ge;
        }
    }
}