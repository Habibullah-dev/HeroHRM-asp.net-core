using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Models
{
    public class CompanyBranchModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Location Name*")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "City*")]
        public string City { get; set; }
        [Required]
        [Display(Name = "Country*")]
        public string Country { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
