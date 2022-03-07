using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shoppers_Square.Models
{
    public class OrderModel
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string PaymentType { get; set; }
        public string OrderStatus { get; set; }
        public int isDelete { get; set; }
        public DateTime Dated { get; set; }
        public List<OrderItemModel> OrderItems { get; set; }
    }
}
