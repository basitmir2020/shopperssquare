using Shoppers_Square.IRepositories;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shoppers_Square.Models
{
    public class OrderStatusModel
    {
        [Key]
        public int EnquiryId { get; set; }

        public int OrderId { get; set; }
        
        [ForeignKey("OrderId")]
        public OrderModel Order { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Select Status")]
        public string OrderStatus { get; set; }
        [NotMapped]
        public string OrdersId { get; set; }
        [Required(ErrorMessage = "Enter Valid Reason")]
        public string Description { get; set; }

        public int isDelete { get; set; }
        public DateTime Dated { get; set; }
    }
}
