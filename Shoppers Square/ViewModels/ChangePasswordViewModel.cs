using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_Square.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "The Current Password Field Is Empty!")]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "The New Password field is required!")]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]       
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm New Password")]
        [Required(ErrorMessage = "The Confirm New Password field is required!")]
        [Compare("NewPassword", ErrorMessage = "New Password And Confirm New Password Must Be Same!")]
        public string ConfirmPassword { get; set; }
    }
}
