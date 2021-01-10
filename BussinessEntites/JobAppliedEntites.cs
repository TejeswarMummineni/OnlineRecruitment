using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntites
{
    public class JobAppliedEntites
    {
        public short ApplicationNum { get; set; }
        public string CandidateId { get; set; }
        public string JobId { get; set; }
        public bool Status { get; set; }
    }
}
