using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BussinessEntites;

namespace BussinessLogic
{
    public class JobAppliedBL
    {
        JobAppliedDAL jd = new JobAppliedDAL();
        public int CandidateClick(JobAppliedEntites ja, String Email)
        {
            return jd.CandidateClick(ja,Email);
        }


    }
}
