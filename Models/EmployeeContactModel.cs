using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Models
{
    public class EmployeeContactModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        [Required]
        [Display(Name ="Home Telephone*")]
        public int HomeTelephone { get; set; }
        [Required]
        [Display(Name = "Mobile*")]
        public int Mobile { get; set; }
        [Display(Name = "Work Telephone")]
        public int Fax { get; set; }
        [Display(Name = "Fax*")]
        public int WorkTelephone { get; set; }
        [Display(Name = "Work Email")]
        [DataType(DataType.EmailAddress)]
        public string WorkEmail { get; set; }
        [Display(Name = "Other Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string OtherEmail { get; set; }
        [Required]
        [Display(Name = "Phone*")]
        public int Phone { get; set; }
        [Required]
        [Display(Name = "Address*")]
        public string Address { get; set; }
        [Required]
        [Display(Name = "State*")]
        public string State { get; set; }
        [Required]
        [Display(Name = "City*")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Country*")]
        public string Country { get; set; }
       
        [Display(Name = "ZipCode/Postal Code*")]
        [DataType(DataType.PostalCode)]
        public int ZipCode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
