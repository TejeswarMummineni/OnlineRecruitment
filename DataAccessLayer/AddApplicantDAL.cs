using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using BussinessEntites;
namespace DataAccessLayer
{
    public class AddApplicantDAL
    {
        public int addapplicant(JobApplicantEntites ap)
        {
            OnlineRecruitmentEntities db = new OnlineRecruitmentEntities();

            var cust = db.JobApplicants.OrderByDescending(s => s.CandidateId).FirstOrDefault();
            if (cust == null)
            {
                ap.CandidateId = "APP10000";
            }
            else
            {
                ap.CandidateId = "APP" + (Convert.ToInt32(cust.CandidateId.Substring(3, 5)) + 1).ToString();
            }
            JobApplicant st = new JobApplicant()
            {
                CandidateId = ap.CandidateId,
                Name = ap.Name,
                Dob = ap.Dob,
                Phone = ap.Phone,
                Email = ap.Email,
                Password = ap.Password,
                UniversityName = ap.UniversityName,
                Location = ap.Location,
                JobType = ap.JobType,
                Gender = ap.Gender,
                resume = ap.resume

            };
            db.JobApplicants.Add(st);
            return db.SaveChanges();


        }
    }
}
