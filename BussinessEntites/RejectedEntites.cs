using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntites
{
    public class RejectedEntites
    {
        public string Rejectedid { get; set; }
        public string EmployeeId { get; set; }
        public string CompanyId { get; set; }
        public string CompanyDesc { get; set; }
        public string jobtype { get; set; }
        public Nullable<int> candidatereq { get; set; }
        public string Location { get; set; }
        public string jobName { get; set; }
        public int status { get; set; }
        public System.DateTime PostDate { get; set; }
        public System.DateTime LastDate { get; set; }
    }
}
