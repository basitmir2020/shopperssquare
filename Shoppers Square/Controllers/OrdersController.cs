using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shoppers_Square.Helpers;
using Shoppers_Square.IRepositories;
using Shoppers_Square.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_Square.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IProductRepository _product; 
        private readonly ShoppingCart _shoppingCart ;
        private readonly IOrderRepository _order;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public OrdersController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IOrderRepository order,IProductRepository product, ShoppingCart shoppingCart)
        {
            _product = product;
            _shoppingCart = shoppingCart;
            _order = order;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Cart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            var response = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }

        public async Task<IActionResult> AddToShoppingCart(int id)
        {
            var product = await _product.GetByIdAsync(id);
            if(product != null)
            {
                _shoppingCart.AddItemToCart(product);
            }
            return RedirectToAction(nameof(Cart));
        }

        public async Task<IActionResult> RemoveItemsFromShoppingCart(int id)
        {
            var product = await _product.GetByIdAsync(id);
            if (product != null)
            {
                _shoppingCart.RemoveItemFromCart(product);
            }
            return RedirectToAction(nameof(Cart));
        }

        [HttpGet]
        public async Task<IActionResult> CheckOut()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var userName = User.Identity.Name;
                var user = await _userManager.FindByNameAsync(userName);
                var items = _shoppingCart.GetShoppingCartItems();
                _shoppingCart.ShoppingCartItems = items;

                var response = new CheckOutViewModel
                {
                    ShoppingCart = _shoppingCart,
                    ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Phone = user.PhoneNumber,
                };
                return View(response);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CheckOut(CheckOutViewModel model)
        {
            if (_signInManager.IsSignedIn(User))
            {
                var userName = User.Identity.Name;
                var user = await _userManager.FindByNameAsync(userName);
                var items = _shoppingCart.GetShoppingCartItems();
                _shoppingCart.ShoppingCartItems = items;
                var response = new CheckOutViewModel
                {
                    ShoppingCart = _shoppingCart,
                    ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Phone = user.PhoneNumber,
                };
                if (ModelState.IsValid)
                {
                    await _order.StoreOrderAsync(items, model.Id, model.Email,model.Address,model.City,model.Pincode);
                    await _shoppingCart.ClearShoppingCartAsync();
                    return View("OrderConfirmed");
                }
                return View(response);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
