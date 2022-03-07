using System.ComponentModel.DataAnnotations;

namespace Shoppers_Square.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "The Email field is required!")]
        [EmailAddress(ErrorMessage = "This Email Is Not Valid!")]
        public string Email { get;set;}
    }
}
