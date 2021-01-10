using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessEntites
{
    public class QualificationEntites
    {
        public string QualificationId { get; set; }
        public byte Percentage { get; set; }
        public string ApplicantId { get; set; }
        public System.DateTime YearOfPassing { get; set; }
        public byte Experience { get; set; }
        public string HighestEducation { get; set; }
    }
}
