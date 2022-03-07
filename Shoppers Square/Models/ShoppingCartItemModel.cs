using System.ComponentModel.DataAnnotations;

namespace Shoppers_Square.Models
{
    public class ShoppingCartItemModel
    {
        [Key]
        public int Id { get; set; }

        public ProductModel Product { get; set; }

        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
