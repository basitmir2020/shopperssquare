using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shoppers_Square.IRepositories;
using Shoppers_Square.Models;
using System.Collections.Generic;

namespace Shoppers_Square.Api
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _category;

        public CategoryController(ICategoryRepository category)
        {
            _category = category;
        }

        [HttpGet]
        public IEnumerable<CategoryModel> Get()
        {
             return _category.GetAllActiveCategories();
        }
    }
}
