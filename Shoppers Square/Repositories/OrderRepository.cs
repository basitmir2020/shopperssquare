using Microsoft.EntityFrameworkCore;
using Shoppers_Square.Db;
using Shoppers_Square.IRepositories;
using Shoppers_Square.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_Square.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderItemModel>> GetOrderItemsByOrderId(int Id)
        => await _context.OrderItems
                 .Include(n => n.Order)
                 .Include(n => n.Product)
                 .Where(n => n.OrderId == Id && n.isDelete == 0)
                 .OrderByDescending(n => n.Id)
                 .ToListAsync();

        public async Task<List<OrderModel>> GetAllOrdersByAsync()
        => await _context.Order
                 .Include(n => n.OrderItems)
                 .ThenInclude(n => n.Product)
                 .Where(n => n.isDelete == 0)
                 .OrderByDescending(n => n.Id)
                 .ToListAsync();

        public async Task<List<OrderModel>> GetOrdersByUserIdAsync(string userId)
            => await _context.Order
                .Include(n => n.OrderItems)
                .ThenInclude(n => n.Product)
                .Where(n => n.UserId == userId && n.isDelete == 0 && n.OrderStatus != "Completed")
                .OrderByDescending(n => n.Id)
                .ToListAsync();

        public async Task StoreOrderAsync(List<ShoppingCartItemModel> items, string UserId, string UserEmail, string UserAddress, string UserCity, string UserPincode)
        {
            var order = new OrderModel()
            {
                Email = UserEmail,
                UserId = UserId,
                Address = UserAddress,
                City = UserCity,
                Pincode = UserPincode,
                PaymentType = "COD",
                OrderStatus = "In Process",
                isDelete = 0,
                Dated = DateTime.Now
            };
            await _context.Order.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItemModel()
                {
                    Amount = item.Amount,
                    Price = item.Product.DiscountPrice,
                    ProductId = item.Product.Id,
                    OrderId = order.Id,
                    isDelete = 0,
                    Dated = DateTime.Now
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }

        public int GetCustomerOrdersCount(string UserId)
        {
            return _context.Order
                 .Include(n => n.OrderItems)
                 .Where(n => n.UserId == UserId && n.isDelete == 0 && n.OrderStatus != "Completed")
                 .Count();
        }

        public int GetAllOrdersCount()
        {
            return _context.Order
               .Include(n => n.OrderItems)
               .Where(n => n.isDelete == 0 && n.OrderStatus != "Completed")
               .Count();
        }

        public async Task DeleteOrderAsync(int Id)
        {
            var Order = new OrderModel
            {
                Id = Id,
                isDelete = 1
            };
            _context.Entry(Order).Property(x => x.isDelete).IsModified = true;
            await _context.SaveChangesAsync();
        }

        public void ChangeStatusByIdAsync(int OrderId, string Status)
        {
            var Order = new OrderModel
            {
                Id = OrderId,
                OrderStatus = Status
            };
            _context.Entry(Order).Property(x => x.OrderStatus).IsModified = true;
            _context.SaveChanges();
        }
    }
}
