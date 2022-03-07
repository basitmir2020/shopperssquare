using Microsoft.AspNetCore.Http;
using Shoppers_Square.IRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_Square.Models
{
    public class ProductModel : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public int SubCategoryId { get; set; }
        public SubCategoryModel SubCategory { get; set; }

        [Required(ErrorMessage = "The Product Name field is required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "The Product Slug field is required")]
        public string Slug { get; set; }
        [Required(ErrorMessage = "The Product Brand field is required")]
        public string ProductBrand { get; set; }
        [Required(ErrorMessage = "The Product Orginal Price field is required")]
        public float OrginalPrice { get; set; }
        [Required(ErrorMessage = "The Product Discount Price field is required")]
        public float DiscountPrice { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Select Product Image")]
        public IFormFile Image { get; set; }
        public string UrlImage { get; set; }
        public int isDelete { get; set; }

        public List<ImageModel> ProductImage { get; set; }
        public List<ProductDescriptionModel> ProductDescription { get; set; }

        [NotMapped]
        public int CategoryId { get; set; }
        public int isActive { get; set; }
        public DateTime Dated { get; set; }
    }
}
