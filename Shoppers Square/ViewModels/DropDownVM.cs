using Shoppers_Square.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_Square.ViewModels
{
    public class DropDownVM
    {
        public DropDownVM()
        {
            Category = new List<CategoryModel>();
            SubCategory = new List<SubCategoryModel>();
            Product = new List<ProductModel>();
        }

        public List<CategoryModel> Category { get; set; }
        public List<SubCategoryModel> SubCategory { get; set; }
        public List<ProductModel> Product { get; set; }

    }
}
