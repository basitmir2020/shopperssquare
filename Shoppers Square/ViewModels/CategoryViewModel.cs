using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Shoppers_Square.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Category Name Field Is Required!")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "The Category Slug Field Is Required!")]
        public string Slug { get; set; }

        public IFormFile CategoryImage { get; set; }
        public string ImageUrl { get; set; }
        public int isActive { get; set; }
    }
}
