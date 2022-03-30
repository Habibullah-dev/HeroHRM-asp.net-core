using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Database
{
    public class EmployeeMembership
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int MembershipId { get; set; }
        public string ReportingMethod { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public Employee Employee { get; set; }
        public Membership Membership { get; set; }
   
    }
}
