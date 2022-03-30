using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Models
{
    public class EmployeeDependantModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        [Required]
        [Display(Name="Depandant Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Relationship*")]
        public string Relationship { get; set; }
        [Required]
        [Display(Name = "Date OF Birth*")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
