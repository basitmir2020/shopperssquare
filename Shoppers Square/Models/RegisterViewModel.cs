using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Shoppers_Square.Models
{
    public class RegisterViewModel
    {
        [Key]
        public int UID { get; set; }
        [Required(ErrorMessage = "The Name field is required!")]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage ="The Name Is Not Valid!")]
        public string Name { get; set; }
        [RegularExpression("^[0-9]+$", ErrorMessage = "This Phone Number is Not Valid")]
        [Required(ErrorMessage = "The Phone Number field is required!")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "The Email field is required!")]
        [EmailAddress(ErrorMessage = "This Email Is Not Valid!")]
        [Remote(action: "IsEmailInUse",controller: "Account")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "The Password field is required!")]
        public string Password { get; set; }
    }
}
