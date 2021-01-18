using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessEntites;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class AptitudeDAL
    {
        OnlineRecruitmentEntities db = new OnlineRecruitmentEntities();
        public int saveresult(int marks, string email)
        {


            var data = db.JobApplicants.Where(x => x.Email == email).FirstOrDefault();


            TestResult test = new TestResult();
            test.CandidateId = data.CandidateId;
            test.Marks = (byte)marks;
            test.JobId = "JOB10001";
            db.TestResults.Add(test);

            return db.SaveChanges();

        }

        public List<AptitudeEntities> storeproc()
        {

            var res = db.Aptitude();


            List<AptitudeEntities> li = new List<AptitudeEntities>();

            foreach (var item in res)
            {
                li.Add(new AptitudeEntities { Qid = item.Qid, Question = item.Question, Option1 = item.Option1, Option2 = item.Option2, Option3 = item.Option3, Option4 = item.Option4, CorrectANS = item.CorrectANS });
            }


            return li;

        }

    }
}
