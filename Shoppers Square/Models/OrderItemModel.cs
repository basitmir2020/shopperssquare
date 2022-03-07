using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_Square.Models
{
    public class OrderItemModel
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }

        public double Price { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual ProductModel Product { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual OrderModel Order { get; set; }

        public int isDelete { get; set; }
        public DateTime Dated { get; set; }
    }
}
