using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_Square.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "The Email field is required!")]
        [EmailAddress(ErrorMessage = "This Email Is Not Valid!")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "The Password field is required!")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Required(ErrorMessage = "The Confirm Password field is required!")]
        [Compare("Password",ErrorMessage = "Password And Confirm Password Must Be Same!")]
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }
    }
}
