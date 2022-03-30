using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Models
{
    public class EmployeeEducationModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        [Required]
        [Display(Name ="Level*")]
        public string Level { get; set; }
        [Required]
        [Display(Name = "Institute*")]
        public string Institute { get; set; }
        [Display(Name = "Gpa/Score")]
        public string Gpa { get; set; }
  
        [Display(Name = "Major*")]
        public string Major { get; set; }
        [Required]
        [Display(Name = "Year*")]
        public int Year { get; set; }
       
        [Display(Name = "Start Date*")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        
        [Display(Name = "End Date*")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Comments")]
        public string Comment { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
