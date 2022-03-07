using Microsoft.AspNetCore.Http;
using Shoppers_Square.IRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shoppers_Square.Models
{
    public class SubCategoryModel : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "The SubCategory Name field is required")]
        public string SubCategoryName { get; set; }
        [Required(ErrorMessage = "The SubCategory Slug field is required")]
        public string Slug { get; set; }
        [Required(ErrorMessage = "The Select Category field is required")]
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Choose SubCategory Image")]
        public IFormFile SubCategoryImage { get; set; }
        public string ImageUrl { get; set; }
        public int isDelete { get; set; }
        public int isActive { get; set; }
        public DateTime Dated { get; set; }

        public List<ProductModel> ProductModels { get; set; }
    }
}
