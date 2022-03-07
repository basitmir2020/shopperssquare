using Microsoft.EntityFrameworkCore;
using Shoppers_Square.Db;
using Shoppers_Square.IRepositories;
using Shoppers_Square.Models;
using Shoppers_Square.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Shoppers_Square.Repositories
{
    public class ProductRepository : EntityBaseRepository<ProductModel>, IProductRepository
    {
        public readonly AppDbContext _context;
        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public List<ProductModel> getAllActiveProductsBySubCategoryId(int SubcategoryId)
        {
            var product = _context.Product
                  .Where(s => s.SubCategory.Id == SubcategoryId
                  &&  s.isActive == 1 && s.isDelete == 0)
                  .ToList();
            return product;
        }

        public int GetAllProductsCount()
        {
            return _context.Product
              .Where(n => n.isDelete == 0 && n.isActive == 1)
              .Count();
        }

        public async Task<DropDownVM> GetDropDownProducts()
        {
            var response = new DropDownVM()
            {
                Product = await _context.Product.OrderBy(n => n.ProductName).ToListAsync()
            };
            return response;
        }

        public List<ProductModel> GetProductByCategorySlug(string Slug)
        {
            if (Slug == null)
            {
                return _context.Product
                    .OrderByDescending(o => o.Id)
                    .Take(8)
                    .Where(p => p.isActive == 1 && p.isDelete == 0)
                    .ToList();
            }
            else
            {
                return _context.Product
                    .OrderByDescending(o => o.Id)
                    .Take(8)
                    .Where(p => p.SubCategory.Category.Slug == Slug && p.isActive == 1 && p.isDelete == 0)
                    .ToList();
            }
        }

        public List<ProductModel> GetProductBySubCategorySlug(string Slug)
        {
            if (Slug == null)
            {
                return _context.Product
                    .OrderByDescending(o => o.Id)
                    .Take(8)
                    .Where(p => p.isActive == 1 && p.isDelete == 0)
                    .ToList();
            }
            else
            {
                return _context.Product
                   .OrderByDescending(o => o.Id)
                   .Take(8)
                   .Where(p => p.SubCategory.Slug == Slug && p.isActive == 1 && p.isDelete == 0)
                   .ToList();
            }
        }

        public List<ProductModel> RelatedProductsBySubcategoryId(int SubcategoryId)
        {
            return _context.Product
                    .OrderBy(o => o.Id)
                    .Where(p => p.isActive == 1 && p.isDelete == 0 && p.SubCategoryId == SubcategoryId)
                    .ToList();
        }

        public List<ProductModel> Search(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return _context.Product.ToList();
            }
            return _context.Product.Where(e => e.Slug.Contains(search)).ToList();
        }
    }
}
