using Shoppers_Square.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_Square.Models
{
    public class ImageModel : IEntityBase
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public ProductModel Product { get; set; } 

        public string ImageName { get; set; }
        public string Slug { get; set; }
        public string ImagesUrl { get; set; }
        public int isDelete { get; set; }
        public int isActive { get; set; }
        public DateTime Dated { get; set; }
    }
}
