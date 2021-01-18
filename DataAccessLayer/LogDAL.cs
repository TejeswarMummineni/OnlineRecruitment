using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using BussinessEntites;
namespace DataAccessLayer
{
    public class LogDAL
    {
        OnlineRecruitmentEntities db = new OnlineRecruitmentEntities();
        public int log(LoginEntites ja)
        {
            var candi = db.JobApplicants.Where(c => c.Email == ja.Email && c.Password == ja.Password).Count();
            if(candi > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        

    }
}
