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
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDescriptionRepository _description;

        public ProductDetailsController(IProductDescriptionRepository description)
        {
            _description = description;
        }

        [HttpGet("{id}")]
        public IEnumerable<ProductDescriptionModel> Get(int id)
        {
            var productDescription = _description.getProductDescriptionByProductId(id);
            return productDescription;
        }
    }
}
