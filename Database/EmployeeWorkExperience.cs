using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Database
{
    public class EmployeeWorkExperience
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public string Comment { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public Employee Employee { get; set; }
    }
}
