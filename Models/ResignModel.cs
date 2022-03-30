using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Models
{
    public class ResignModel
    {
        public int Id { get; set; }
        public string ResignationLetter { get; set; }
        [Required]
        [Display(Name = "Reason")]
        public string Reason { get; set; }
        [Display(Name = "Comments")]
        public string Comments { get; set; }
        [Display(Name = "Resination Letter")]
        [DataType(DataType.Upload)]
        public IFormFile ResignationFile { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
