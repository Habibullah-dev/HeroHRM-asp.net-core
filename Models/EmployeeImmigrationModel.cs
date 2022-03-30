using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Models
{
    public class EmployeeImmigrationModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
      
        [Display(Name ="Document Type*")]
        public string DocumentType { get; set; }
      
        [Display(Name = "Number*")]
        public int Number { get; set; }
       
        [Display(Name = "Eligible Status*")]
        public string EligibleStatus { get; set; }
        public string Country { get; set; }
        [Display(Name = "issued By*")]
        public int IssuedBy { get; set; }
      
        [Display(Name = "issued Date*")]
        [DataType(DataType.Date)]
        public DateTime? IssuedDate { get; set; }
     
        [Display(Name = "Expiry Date*")]
        [DataType(DataType.Date)]
        public DateTime? ExpiryDate { get; set; }
       
        [Display(Name = "Eligible Review Date*")]
        [DataType(DataType.Date)]
        public DateTime? EligibleReviewDate { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
