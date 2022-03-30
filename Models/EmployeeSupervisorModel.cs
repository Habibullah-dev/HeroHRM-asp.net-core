using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Models
{
    public class EmployeeSupervisorModel
    {
        public int Id { get; set; }
        [Display(Name = "Supervisor*")]
        public int Supervisor { get; set; }
        public int EmployeeId { get; set; }
        [Required]
        [Display(Name = "Reporting Method*")]
        public string ReportingMethod { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
