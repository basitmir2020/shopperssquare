using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shoppers_Square.Helpers;
using Shoppers_Square.IRepositories;
using Shoppers_Square.Models;
using Shoppers_Square.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_Square.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IOrderRepository _order;
        private readonly IEnquiryRepository _enquiry;

        public CustomerController(IEnquiryRepository enquiry,IOrderRepository order,SignInManager<ApplicationUser> signInManager,UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _order = order;
            _enquiry = enquiry;
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToAction("SignIn", "Account");
                }
                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }
                await _signInManager.RefreshSignInAsync(user);
                return RedirectToAction("Dashboard");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("SignIn", "Account");
            }
            var order =  _order.GetCustomerOrdersCount(user.Id);
            return View(order);
        }

        public async Task<IActionResult> Orders()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("SignIn", "Account");
            }
            var orders = await _order.GetOrdersByUserIdAsync(user.Id);
            return View(orders);
        }

        public async Task<IActionResult> ViewOrder(int Id)
        {
            var orderItem = await _order.GetOrderItemsByOrderId(Id);
            return View(orderItem);
        }

        public async Task<IActionResult> OrderStatus()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("SignIn", "Account");
            }
            var orders = await _order.GetOrdersByUserIdAsync(user.Id);
            return View(orders);
        }
        [HttpGet]
        public IActionResult Status(int Id)
        {
            var Order = new OrderStatusModel
            {
                OrderId = Id,
                OrdersId = "#ShoppersSquare"+Id
            };
            return View(Order);
        }

        [HttpPost]
        public async Task<IActionResult> Status(OrderStatusModel Enquiry)
        {
            if (ModelState.IsValid)
            {
                Enquiry.isDelete = 0;
                Enquiry.Dated = DateTime.Now;
                if (_enquiry.ExistEnquiryAsync(Enquiry.OrderId))
                {
                    await _enquiry.AddEnquiryAsync(Enquiry);
                    return RedirectToAction(nameof(Orders));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Enquiry Already Submitted!");
                }
            }
            return View(Enquiry);
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var editUser = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Phone = user.PhoneNumber,
                Name = user.Name
            };
            return View(editUser);
        }
        [HttpPost]
        public async Task<IActionResult> Profile(EditUserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            user.Name = model.Name;
            user.PhoneNumber = model.Phone;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Dashboard));
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }
    }
}
