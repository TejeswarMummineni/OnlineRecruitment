using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BussinessEntites;

namespace BussinessLogic
{
    public class LoginBL
    {
        LoginDAL ld = new LoginDAL();
        public int Loginvalidate(LoginEntites log)
        {
            return ld.Loginvalidate(log);
        }

        LogDAL l = new LogDAL();
        public int log(LoginEntites ja)
        {
            return l.log(ja);
        }
    }
}
