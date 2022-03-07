using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoppers_Square.IRepositories;
using Shoppers_Square.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shoppers_Square.Api
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _product;

        public ProductController(IProductRepository product)
        {
            _product = product;
        }

        [HttpGet("{id}")]
        public IEnumerable<ProductModel> Get(int id)
        {
            var products = _product.getAllActiveProductsBySubCategoryId(id);
            return products;
        }
    }
}
