using Shoppers_Square.Models;
using Shoppers_Square.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shoppers_Square.IRepositories
{
    public interface ICategoryRepository : IEntityBaseRepository<CategoryModel>
    {
        Task<DropDownVM> GetDropDownCategories();
        List<CategoryModel> GetAllActiveCategories();

        int GetAllCategoryCount();
    }
}
