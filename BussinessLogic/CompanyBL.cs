using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessEntites;
using DataAccessLayer;
namespace BussinessLogic
{
    public class CompanyBL
    {
        CompanyDAL cd = new CompanyDAL();
        public int Newreq(NewRequirmentEntites ne)
        {
            return cd.Newreq(ne);
        }
        public List<JobApplicantEntites> SelectCandidate(CompanyPortalEntites se)
        {
            return cd.SelectCandidate(se);
        }
        public List<RejectedEntites> rejectedpost(CompanyPortalEntites cp)
        {
            return cd.rejectedpost(cp);
        }
    }
}
