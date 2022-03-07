using Microsoft.EntityFrameworkCore;
using Shoppers_Square.Db;
using Shoppers_Square.IRepositories;
using Shoppers_Square.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shoppers_Square.Repositories
{
    public class ProductDescriptionRepository : EntityBaseRepository<ProductDescriptionModel>, IProductDescriptionRepository
    {
        public readonly AppDbContext _context;
        public ProductDescriptionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public bool ExistProductDescriptionAsync(int Id, int ProductId)
        {
            var description = _context.ProductDescription
                .Where(x => x.Id != Id && x.ProductId == ProductId && x.isDelete == 0).FirstOrDefault();
            if (description == null)
                return true;
            return false;
        }

        public int GetAllProductsDescriptionCount()
        {
            return _context.ProductDescription
               .Where(n => n.isDelete == 0 && n.isActive == 1)
               .Count();
        }

        public List<ProductDescriptionModel> getProductDescriptionByProductId(int ProductId)
        {
            return _context.ProductDescription
                .Where(s => s.Product.Id == ProductId&& s.isActive == 1 && s.isDelete == 0)
                .ToList();
        }
    }
}
