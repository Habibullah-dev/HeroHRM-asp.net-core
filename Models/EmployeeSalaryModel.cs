using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Models
{
    public class EmployeeSalaryModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        [Required]
        [Display(Name ="Pay Grade*")]
        public int PayGradeId { get; set; }

        public string PayGrade { get; set; }
      
        [Required]
        [Display(Name = "Pay Frequency*")]
        public string PayFrequency { get; set; }

        [Required]
        [Display(Name = "Currency*")]
        [DataType(DataType.Currency)]
        public int CuurencyId { get; set; }
        public string Currency { get; set; }
        [Required]
        [Display(Name = "Amount*")]
        public int Amount { get; set; }
     
        public DateTime? DateOfBirth { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
