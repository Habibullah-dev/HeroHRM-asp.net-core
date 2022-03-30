using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Models
{
    public class EmployeeWorkExperienceModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        [Required]
        [Display(Name ="Company Name*")]
        public string CompanyName { get; set; }
        [Required]
        [Display(Name = "Job Title*")]
        public string JobTitle { get; set; }
 
        [Display(Name = "Comment")]
        public string Comment { get; set; }
        [Required]
        [Display(Name = "From*")]
        public DateTime? From { get; set; }
        [Required]
        [Display(Name = "To*")]
        public DateTime? To { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
