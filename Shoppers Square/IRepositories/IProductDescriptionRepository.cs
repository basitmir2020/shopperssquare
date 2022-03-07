using Shoppers_Square.Models;
using System.Collections.Generic;

namespace Shoppers_Square.IRepositories
{
   public interface IProductDescriptionRepository : IEntityBaseRepository<ProductDescriptionModel>
    {
        bool ExistProductDescriptionAsync(int Id, int ProductId);

        int GetAllProductsDescriptionCount();

        List<ProductDescriptionModel> getProductDescriptionByProductId(int ProductId);
    }
}
