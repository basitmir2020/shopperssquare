using Microsoft.AspNetCore.Mvc;
using Shoppers_Square.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_Square.ViewComponents
{
    public class ShoppingCart: ViewComponent
    {
        private readonly Helpers.ShoppingCart _shoppingCart;
        public ShoppingCart(Helpers.ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            return View(items.Count);
        }
    }
}
