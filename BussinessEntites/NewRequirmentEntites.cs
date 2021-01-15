using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntites
{
    public class NewRequirmentEntites
    {
        public string Requirmentid { get; set; }
        public string EmployeeId { get; set; }
        public string CompanyId { get; set; }
        public string jobtype { get; set; }
        public Nullable<int> candidatereq { get; set; }
        public string Location { get; set; }
        public System.DateTime PostedDate { get; set; }
        public string JobDesc { get; set; }
        public System.DateTime LastDate { get; set; }
        public string JobName { get; set; }
        public bool Status { get; set; }
    }
}
