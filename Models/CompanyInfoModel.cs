using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Models
{
    public class CompanyInfoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Company Name invalid or cannot be empty")]
        [Display(Name ="Company Name*")]
        public string Name { get; set; }

        [Required,EmailAddress]
        [Display(Name = "Company Email*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Address*")]
        public string Address { get; set; }
        [Required(ErrorMessage = "State invalid or cannot be empty")]
        [Display(Name = "State*")]
        public string State { get; set; }
        [Required(ErrorMessage = "City invalid or cannot be empty")]
        [Display(Name = "City*")]
        public string City { get; set; }
        [Required(ErrorMessage = "Country invalid or cannot be empty")]
        [Display(Name = "Country*")]
        public string Country { get; set; }
        public int ZipCode { get; set; }
        [Required]
        [Display(Name = "Tax ID*")]
        public int TaxId { get; set; }
        [Required]
        [Display(Name = "Number Of Employees*")]
        public int EmployeeNumbers { get; set; }
        [Display(Name = "Fax")]
        public int Fax { get; set; }
        [Required]
        [Display(Name = "Phone Number*")]
        public int Phone { get; set; }
        [Required]
        [Display(Name = "Regsitration Number*")]
        public string RegistrationNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
