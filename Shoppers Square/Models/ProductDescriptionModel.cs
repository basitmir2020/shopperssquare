using Shoppers_Square.IRepositories;
using System;
using System.ComponentModel.DataAnnotations;

namespace Shoppers_Square.Models
{
    public class ProductDescriptionModel : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductModel Product { get; set; }
        [Required(ErrorMessage = "The Short Description Field Is Required!")]
        public string Slug { get; set; }
        [Required(ErrorMessage = "The Long Description Field Is Required!")]
        public string LongDescription { get; set; }
        public int isDelete { get; set; }
        public int isActive { get; set; }
        public DateTime Dated { get; set; }
    }
}
