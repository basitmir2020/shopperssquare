using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shoppers_Square.Helpers;
using Shoppers_Square.Models;
using System.Threading.Tasks;

namespace Shoppers_Square.Api
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class DetailsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public DetailsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<UserModel> Get([FromQuery] string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                return new UserModel
                {
                    IsSuccess = true,
                    UserId = user.Id,
                    Name = user.Name,
                    Email = email,
                    Phone = user.PhoneNumber
                };
            }
            else
            {
                return new UserModel
                {
                    IsSuccess = false,
                    Message = "Not Valid"
                };
            }
        }
    }
}
