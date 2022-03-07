using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shoppers_Square.Helpers;
using Shoppers_Square.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Shoppers_Square.Api
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public RegisterController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<ResponseModel> Register([FromBody] RegisterViewModel model)
        {
            var user = new ApplicationUser
            {
                Name = model.Name,
                Email = model.Email,
                UserName = model.Email,
                PhoneNumber = model.Phone
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                return new ResponseModel
                {
                    Message = "User Created Successfully!",
                    IsSuccess = true
                };
            }
            return new ResponseModel
            {
                Message = "Error",
                IsSuccess = false,
                Error = result.Errors.Select(e => e.Description)
            };
        }
    }
}
