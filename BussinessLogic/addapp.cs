using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessEntites;
using DataAccessLayer;

namespace BussinessLogic
{
    public class addapp
    {
        AddApplicantDAL wd = new AddApplicantDAL();
        public int addapplicant(JobApplicantEntites ap)
        {
            return wd.addapplicant(ap);
        }

    }
}

