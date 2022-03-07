using Microsoft.EntityFrameworkCore;
using Shoppers_Square.Db;
using Shoppers_Square.IRepositories;
using Shoppers_Square.Models;
using Shoppers_Square.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_Square.Repositories
{
    public class SubCategoryRepository : EntityBaseRepository<SubCategoryModel>, ISubCategoryRepository
    {
        public readonly AppDbContext _context;
        public SubCategoryRepository(AppDbContext context) : base(context) {
            _context = context;
        }

        public List<SubCategoryModel> getAllActiveSubCategories(int CategoryId)
        {
            var subcategory = _context.Subcategory
                 .Include(s => s.Category)
                 .Where(s => s.Category.Id == CategoryId && s.isActive == 1 && s.isDelete == 0)
                 .ToList();
            return subcategory;
        }

        public List<SubCategoryModel> getAllActiveSubCategories()
        {
            var subcategory = _context.Subcategory
                 .Where(s => s.isActive == 1 && s.isDelete == 0)
                 .ToList();
            return subcategory;
        }

        public int GetAllSubCategoryCount()
        {
            return _context.Subcategory
              .Where(n => n.isDelete == 0 && n.isActive == 1)
              .Count();
        }

        public async Task<DropDownVM> GetDropDownSubCategories()
        {
            var response = new DropDownVM()
            {
                SubCategory = await _context.Subcategory.OrderBy(n => n.SubCategoryName).ToListAsync()
            };
            return response;
        }
    }
}
