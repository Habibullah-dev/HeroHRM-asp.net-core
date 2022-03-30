using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Models
{
    public class EmployeeEmergencyModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        [Required]
        [Display(Name="Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Relationship*")]
        public string Relationship { get; set; }

        [Display(Name = "Home Phone")]
        [DataType(DataType.PhoneNumber)]
        public int HomeTelephone { get; set; }
        [Required]
        [Display(Name = "Mobile")]
        [DataType(DataType.PhoneNumber)]
        public int Mobile { get; set; }
        [Display(Name = "Work Telephone")]
        [DataType(DataType.PhoneNumber)]
        public int WorkTelephone { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
