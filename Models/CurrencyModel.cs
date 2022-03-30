using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Models
{
    public class CurrencyModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Currency Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Currency Code")]
        public string CurrencyCode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
