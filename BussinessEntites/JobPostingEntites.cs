using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntites
{
    public class JobPostingEntites
    {
        public string JobId { get; set; }
        public string JobDescription { get; set; }
        public string CompanyId { get; set; }
        public string Location { get; set; }
        public System.DateTime PostedDate { get; set; }
        public System.DateTime LastDate { get; set; }
        public bool Status { get; set; }
        public string JobName { get; set; }
        public string JobType { get; set; }
        public bool CandidateReq { get; set; }

    }
}
