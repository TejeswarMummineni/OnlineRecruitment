using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntites
{
    public class JobApplicantEntites
    {
        public string CandidateId { get; set; }
        public string Name { get; set; }
        public System.DateTime Dob { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Gender { get; set; }
        public string UniversityName { get; set; }
        public string Location { get; set; }
        public string JobType { get; set; }
    }
}
