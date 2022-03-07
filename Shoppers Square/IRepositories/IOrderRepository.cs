using Shoppers_Square.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_Square.IRepositories
{
    public interface IOrderRepository
    {
        Task StoreOrderAsync(List<ShoppingCartItemModel> items,string UserId,string UserEmail, string UserAddress, string UserCity, string UserPincode);
        Task<List<OrderModel>> GetOrdersByUserIdAsync(string userId);
        Task<List<OrderModel>> GetAllOrdersByAsync();
        Task<List<OrderItemModel>> GetOrderItemsByOrderId(int Id);
        int GetCustomerOrdersCount(string UserId);
        int GetAllOrdersCount();
        Task DeleteOrderAsync(int Id);
        void ChangeStatusByIdAsync(int OrderId,string Status);
    }
}
