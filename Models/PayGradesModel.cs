using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Models
{
    public class PayGradesModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Pay Grade Name cannot be empty")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Currency cannot be empty")]
        public string Currency { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public int MinimumSalary { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public int MaximumSalary { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
