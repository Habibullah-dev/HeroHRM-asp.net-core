using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Models
{
    public class EmployeeLicenseModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        [Required]
        [Display(Name ="License*")]
        public int LicenseId { get; set; }
        public string License { get; set; }
        [Required]
        [Display(Name = "License Number*")]
        public int LicenseNumber { get; set; }
        [Required]
        [Display(Name = "Issued Date*")]
        [DataType(DataType.Date)]
        public DateTime? IssuedDate { get; set; }
        [Required]
        [Display(Name = "Expiry Date*")]
        [DataType(DataType.Date)]
        public DateTime? ExpiryDate { get; set; }
        [Display(Name = "Comment")]
        public string Comments { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

    }
}
