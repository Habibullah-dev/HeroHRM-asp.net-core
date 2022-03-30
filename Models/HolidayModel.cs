using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Models
{
    public class HolidayModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Holiday Type")]
        public string HolidayType { get; set; }
        [Required]
        [Display(Name = "Holiday Status")]
        public string HolidayStatus { get; set; }
        [Display(Name = "Number of days")]
        public int NumberOfDays { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }
        public string Comments { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
