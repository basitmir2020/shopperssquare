using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shoppers_Square.Helpers;
using Shoppers_Square.IRepositories;
using Shoppers_Square.Models;
using Shoppers_Square.ViewModels;
using System.Threading.Tasks;

namespace Shoppers_Square.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> logger;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IEmailRepository _email;

        public AccountController(IEmailRepository email,ILogger<AccountController> logger,UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.logger = logger;
            this.userManager = userManager;
            this.signInManager = signInManager;
            _email = email;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var email = await userManager.FindByEmailAsync(loginViewModel.Email);
                /*if(email != null && !email.EmailConfirmed && (await userManager.CheckPasswordAsync(email,loginViewModel.Password)))
                {
                    TempData["ErrorMessage"] = "Email Not Confirmed Yet!";
                    return RedirectToAction(nameof(ConfirmAccount));
                }*/

                var result = await signInManager.PasswordSignInAsync(
                    loginViewModel.Email, 
                    loginViewModel.Password, 
                    loginViewModel.RememberMe,false);
                if (result.Succeeded)
                {
                    var user = await userManager.FindByNameAsync(loginViewModel.Email);
                    var roles = await userManager.GetRolesAsync(user);
                    if (roles.Contains("Administrator"))
                    {
                        return RedirectToAction("Dashboard","Admin");
                    }
                    else
                    {
                 
                        return RedirectToAction("Dashboard", "Customer");
                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid Username Or Password!");
            }
            return View(loginViewModel);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ConfirmAccount()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ConfirmAccount(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user =  await userManager.FindByEmailAsync(model.Email);
                if(user != null)
                {
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var confirmationLink = Url.Action("ConfirmEmail", "Account",
                        new { userId = user.Id, token = token }, Request.Scheme);
                    await _email.SendEmailTest(user.Name, user.Email, confirmationLink, "Confirm Account");
                    ViewBag.ErrorTitle = "Check Your Email";
                    return RedirectToAction(nameof(SignIn));
                }
                else
                {
                    ViewBag.sign = "You Are Not Registered!";
                    RedirectToAction(nameof(SignUp));
                }
            }
            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Name = registerViewModel.Name,
                    Email = registerViewModel.Email,
                    UserName = registerViewModel.Email,
                    PhoneNumber = registerViewModel.Phone
                };
                var result = await userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {
                    //var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var confirmationLink = Url.Action("ConfirmEmail", "Account", 
                       // new { userId = user.Id, token = token },Request.Scheme);
                    //await _email.SendEmailTest(registerViewModel.Name,registerViewModel.Email,confirmationLink,"Confirm Account");
                    if (signInManager.IsSignedIn(User) && User.IsInRole("Administrator"))
                    {
                        return RedirectToAction("Dashboard", "Admin");
                    }
                    TempData["SUCCESSMESSAGE"] = "Registration Successfull!";
                    return RedirectToAction(nameof(SignIn));
                    //ViewBag.ErrorTitle = "Registration Successful!";
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(registerViewModel);
        }
        [AllowAnonymous]
        [AcceptVerbs("Get","Post")]
        public async Task<IActionResult> IsEmailInUse(string Email)
        {
            var user =  await userManager.FindByEmailAsync(Email);
            if(user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {Email} is Already In Use");
            }
        }

        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "Home");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            if (signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index","Home");
            }
            ViewBag.ErrorMessage = "You Are Not Authorised!";
            return RedirectToAction(nameof(SignIn));
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId,string token)
        {
            if(userId == null || token == null)
            {
                ViewBag.ErrorMessage = "Invalid Login";
                return RedirectToAction(nameof(SignIn));
            }
            var user = await userManager.FindByIdAsync(userId);
            if(userId == null)
            {
                ViewBag.ErrorMessage = "Invalid Login";
                return RedirectToAction(nameof(SignIn));
            }
            var result = await userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                ViewBag.ErrorTitle = "Email Confirmed!";
                return RedirectToAction(nameof(SignIn));
            }
            ViewBag.ErrorMessage = "Email Not Confirmed!";
            return RedirectToAction(nameof(SignIn));
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel forgotPasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(forgotPasswordViewModel.Email);
                if(user !=null)
                {

                    return RedirectToAction(nameof(ResetPassword));
                    /* if (await userManager.IsEmailConfirmedAsync(user))
                     {
                         //var token = await userManager.GeneratePasswordResetTokenAsync(user);
                         *//*var passwordResentLink = Url.Action("ResetPassword", "Account",
                             new { email = forgotPasswordViewModel.Email, token = token }, Request.Scheme);*/
                    /*  await _email.SendEmailTest(user.Name, user.Email, passwordResentLink, "Reset Password");*//*
                      //logger.Log(LogLevel.Warning, passwordResentLink);
                      *//*ViewBag.forgot = "Password Link Sent!";*//*

                  }
                  else
                  {
                      TempData["ERRORMESSAGE"] = "Email Not Confirmed!";
                      return RedirectToAction(nameof(SignIn));
                  }*/
                }
                else
                {
                    TempData["ERRORMESSAGE"] = "User Not Registered!";
                    return RedirectToAction(nameof(SignUp));
                }
            }

            return View(forgotPasswordViewModel);
        }

        [AllowAnonymous]
        [HttpGet()]
        public IActionResult ResetPassword()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(resetPasswordViewModel.Email);
                if(user != null)
                {
                    /*var result = await userManager.ResetPasswordAsync(user, resetPasswordViewModel.Password);*/
                    if (result.Succeeded)
                    {
                        TempData["SUCCESSMESSAGE"] = "Password Changed Successfully!";
                        return RedirectToAction(nameof(SignIn));
                    }
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(resetPasswordViewModel);
                }
                else
                {
                    TempData["ERRORMESSAGE"] = "User Is Not Registered!";
                    RedirectToAction(nameof(SignUp));
                }
            }
            return View(resetPasswordViewModel);
        }
    }
}
