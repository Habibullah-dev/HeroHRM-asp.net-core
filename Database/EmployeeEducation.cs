using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Database
{
    public class EmployeeEducation
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Level { get; set; }
        public string Institute { get; set; }
        public string Major { get; set; }
        public string Gpa { get; set; }
        public int Year { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Comment { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public Employee Employee { get; set; }
    }
}
