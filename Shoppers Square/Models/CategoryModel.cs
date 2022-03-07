using Microsoft.AspNetCore.Http;
using Shoppers_Square.IRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shoppers_Square.Models
{
    public class CategoryModel : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Category Name Field Is Required!")]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "The Category Slug Field Is Required!")]
        public string Slug { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Choose Category Image!")]
        public IFormFile CategoryImage { get; set; }
        public string ImageUrl { get; set; }
        public List<SubCategoryModel> subCategories { get; set; }
        public int isDelete { get; set; }
        public int isActive { get; set; }
        public DateTime Dated { get; set; }
    }
}
