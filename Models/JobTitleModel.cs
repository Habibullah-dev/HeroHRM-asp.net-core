using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Models
{
    public class JobTitleModel
    {   
        public int Id { get; set; }

        [Required(ErrorMessage ="Job Title cannot be empty")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Job Description cannot be empty")]
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

    }
}
