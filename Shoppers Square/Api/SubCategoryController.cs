using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Shoppers_Square.IRepositories;
using Shoppers_Square.Models;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Shoppers_Square.Api
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryRepository _subcategory;

        public SubCategoryController(ISubCategoryRepository subcategory)
        {
            _subcategory = subcategory;
        }

        [HttpGet("{id}")]
        public IEnumerable<SubCategoryModel> Get(int id)
        {
            var subcategories = _subcategory.getAllActiveSubCategories(id);
            return subcategories;
        }
    }
}
