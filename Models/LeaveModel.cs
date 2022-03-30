using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Models
{
    public class LeaveModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Leave Type")]
        public string LeaveType { get; set; }
        [Required]
        [Display(Name ="Leave Status")]
        public string LeaveStatus { get; set; }
        public int EmployeeId { get; set; }

        public int NumberOfDays { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
        [Display(Name = "Comments")]
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string Comments { get; set; }
    }
}
