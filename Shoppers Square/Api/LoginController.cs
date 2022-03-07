using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shoppers_Square.Helpers;
using Shoppers_Square.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shoppers_Square.Api
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public LoginController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<ResponseModel> Login([FromBody] LoginViewModel model)
        {
            if(model == null)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = "Login Model Null!"
                };
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = "User Not Registered!"
                };
            }
            if (!user.EmailConfirmed)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = "Email Not Confirmed!"
                };
            }
            var result1 = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!result1)
            {
                return new ResponseModel
                {
                    IsSuccess = false,
                    Message = "Invalid Credentials!"
                };
            }
            var result = await _signInManager.PasswordSignInAsync(
                    model.Email,
                    model.Password,
                    model.RememberMe, false);
            if (result.Succeeded)
            {
                return new ResponseModel
                {
                    Message = "Success!",
                    IsSuccess = true
                };
            }
            return new ResponseModel
            {
                Message = "Error",
                IsSuccess = false
            };
        }
    }
}
