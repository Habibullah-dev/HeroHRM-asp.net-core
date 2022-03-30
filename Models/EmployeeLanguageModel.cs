using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Models
{
    public class EmployeeLanguageModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        [Required]
        [Display(Name ="Language")]
        public int LanguageId { get; set; }
        public string Language { get; set; }
        [Required]
        [Display(Name = "Fluency")]
        public string Fluency { get; set; }
        [Required]
        [Display(Name = "Competency")]
        public string Competency { get; set; }
  
        [Display(Name = "Comments")]
        public string Comments { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
