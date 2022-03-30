using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Database
{
    public class Leave
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string LeaveType { get; set;}
        public string LeaveStatus { get; set; }
       
        public int NumberOfDays { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Comments { get; set; }

        public Employee Employee { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

    }
}
