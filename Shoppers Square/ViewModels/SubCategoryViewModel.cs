using Microsoft.AspNetCore.Http;
using Shoppers_Square.Models;
using System.ComponentModel.DataAnnotations;

namespace Shoppers_Square.ViewModels
{
    public class SubCategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The SubCategory Name field is required")]
        public string SubCategoryName { get; set; }

        [Required(ErrorMessage = "The SubCategory Slug field is required")]
        public string Slug { get; set; }

        [Required(ErrorMessage = "The Select Category field is required")]
        public int CategoryId { get; set; }
        public IFormFile SubCategoryImage { get; set; }
        public string ImageUrl { get; set; }
        public int isActive { get; set; }
    }
}
