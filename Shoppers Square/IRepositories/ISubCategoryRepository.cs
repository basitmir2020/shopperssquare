using Shoppers_Square.Models;
using Shoppers_Square.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shoppers_Square.IRepositories
{
    public interface ISubCategoryRepository : IEntityBaseRepository<SubCategoryModel>
    {
        Task<DropDownVM> GetDropDownSubCategories();
        List<SubCategoryModel> getAllActiveSubCategories(int CategoryId);
        List<SubCategoryModel> getAllActiveSubCategories();
        int GetAllSubCategoryCount();
    }
}
