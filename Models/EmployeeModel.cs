using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        [Required]
        [Display(Name ="First Name*")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name*")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Last Name*")]
        public string LastName { get; set; }
       
        [Display(Name = "UserName*")]
        public string UserId { get; set; }
        [Required]
        [Display(Name = "Gender*")]
        public string Gender { get; set; }
        public string Photograph { get; set; }
        public int NationalityId { get; set; }
        [Required]
        [Display(Name = "Marital Status*")]
        public string MaritalStatus { get; set; }
        [Required]
        [Display(Name = "Date Of Birth*")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string Nationality { get; set; }
        public string UpdatedBy { get; set; }
        
        [Display(Name ="Photo Image")]
        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }
      
    }
}
