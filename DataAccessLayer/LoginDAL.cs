using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessEntites;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class LoginDAL
    {
        public int Loginvalidate(LoginEntites log)
        {
            int r;
            OnlineRecruitmentEntities db = new OnlineRecruitmentEntities();
            
            var emp = db.RecruitmentTeams.Where(e => e.Email == log.Email && e.Password == log.Password).Count();
            var candi = db.JobApplicants.Where(c => c.Email == log.Email && c.Password == log.Password).Count();
            var comp = db.CompanyPortals.Where(c => c.Email == log.Email && c.Password == log.Password).Count();
            if (emp > 0)
            {
                r = 1;
            }
            else if (candi > 0)
            {
                r = 2;
            }
            else if (comp > 0)
            {
                r = 3;
            }
            else
            {
                r = 0;
            }
            return r;
        }
    }
}
