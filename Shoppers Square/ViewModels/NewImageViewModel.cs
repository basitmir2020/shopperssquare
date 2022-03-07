using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_Square.ViewModels
{
    public class NewImageViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ImageUrl { get; set; }
        public string ImageName { get; set; }
        public IFormFile Image { get; set; }
        public int isActive { get; set; }
    }
}
