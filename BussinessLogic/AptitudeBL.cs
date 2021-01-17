using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BussinessEntites;

namespace BussinessLogic
{
    public class AptitudeBL
    {
        AptitudeDAL wd = new AptitudeDAL();

        public int saveresult(int marks, string email)
        {
            return wd.saveresult(marks, email);
        }

        public List<AptitudeEntities> storedproc()
        {

            return wd.storeproc();
        }
    }
}
