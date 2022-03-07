using Shoppers_Square.Models;
using Shoppers_Square.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shoppers_Square.IRepositories
{
    public interface IProductRepository : IEntityBaseRepository<ProductModel>
    {
        Task<DropDownVM> GetDropDownProducts();
        List<ProductModel> GetProductBySubCategorySlug(string Slug);
        List<ProductModel> GetProductByCategorySlug(string Slug);
        List<ProductModel> getAllActiveProductsBySubCategoryId(int SubcategoryId);
        List <ProductModel> Search(string search);
        int GetAllProductsCount();

        List<ProductModel> RelatedProductsBySubcategoryId(int SubcategoryId);
    }
}
