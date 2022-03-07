using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shoppers_Square.Db;
using Shoppers_Square.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_Square.Helpers
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItemModel> ShoppingCartItems { get; set; }
        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public List<ShoppingCartItemModel> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems
                .Where(n => n.ShoppingCartId == ShoppingCartId)
                .Include(n=>n.Product)
                .ToList());
        }

        public double GetShoppingCartTotal() => 
            _context.ShoppingCartItems
                .Where(n => n.ShoppingCartId == ShoppingCartId)
                .Select(n => n.Product.DiscountPrice * n.Amount).Sum();

        public void AddItemToCart(ProductModel product)
        {
            var ShoppingCartItem = _context.ShoppingCartItems
                .FirstOrDefault(n => n.Product.Id == product.Id && n.ShoppingCartId == ShoppingCartId);
            if(ShoppingCartItem == null)
            {
                ShoppingCartItem = new ShoppingCartItemModel()
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Amount = 1
                };
                _context.ShoppingCartItems.Add(ShoppingCartItem);
            }
            else
            {
                ShoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public void RemoveItemFromCart(ProductModel product)
        {
            var ShoppingCartItem = _context.ShoppingCartItems
               .FirstOrDefault(n => n.Product.Id == product.Id && n.ShoppingCartId == ShoppingCartId);
            if (ShoppingCartItem != null)
            {
                if (ShoppingCartItem.Amount > 1)
                {
                    ShoppingCartItem.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(ShoppingCartItem);
                }
            }
            _context.SaveChanges();
        }

        public async Task ClearShoppingCartAsync()
        {
            var items = await _context.ShoppingCartItems
               .Where(n => n.ShoppingCartId == ShoppingCartId)
               .ToListAsync();
            _context.ShoppingCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}
