using Microsoft.EntityFrameworkCore;
using Shoppers_Square.Db;
using Shoppers_Square.IRepositories;
using Shoppers_Square.Models;
using Shoppers_Square.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_Square.Repositories
{
    public class CategoryRepository : EntityBaseRepository<CategoryModel>, ICategoryRepository
    {
        public readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) : base(context) {
            _context = context;
        }

        public List<CategoryModel> GetAllActiveCategories()
        {
            var category = _context.Category
                  .Where(c => c.isActive == 1 && c.isDelete == 0)
                  .ToList();
            return category;
        }

        public int GetAllCategoryCount()
        {
            return _context.Category
               .Where(n => n.isDelete == 0 && n.isActive == 1)
               .Count();
        }

        public async Task<DropDownVM> GetDropDownCategories()
        {
            var response = new DropDownVM()
            {
                Category = await _context.Category.OrderBy(n => n.CategoryName).ToListAsync()
            };
            return response;
        }
    }
}
