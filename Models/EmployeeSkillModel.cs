using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Models
{
    public class EmployeeSkillModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        [Required]
        [Display(Name ="Skill")]
        public int SkillId { get; set; }
        public string Skill { get; set; }
        [Required]
        [Display(Name = "Year Of Experience")]
        public int YearOfExperience { get; set; }
        [Display(Name = "Comments")]
        public string Comments { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
