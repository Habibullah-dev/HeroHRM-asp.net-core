using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeroHRM.Models
{
    public class SignupUserModel
    {   
        [Required(ErrorMessage = "Please Enter Your User Name")]
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter A Strong password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword" , ErrorMessage ="Password does not match")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Enter A Strong password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
