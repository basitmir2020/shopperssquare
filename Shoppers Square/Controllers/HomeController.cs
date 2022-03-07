using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shoppers_Square.Db;
using Shoppers_Square.IRepositories;
using Shoppers_Square.Models;
using System;
using System.Linq;
using X.PagedList;

namespace Shoppers_Square.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        private readonly IProductRepository _product;
        private readonly ICategoryRepository _category;
        private readonly ISubCategoryRepository _SubCategory;
        public HomeController(ISubCategoryRepository SubCategory, ICategoryRepository category, IProductRepository product, ILogger<HomeController> logger, AppDbContext context)
        {
            _context = context;
            _logger = logger;
            _product = product;
            _category = category;
            _SubCategory = SubCategory;
        }
        [Route("~/")]
        [Route("Home")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Category")]
        [Route("Category/{slug}")]
        [Route("Category/{slug}/{page}")]
        [HttpGet]
        public IActionResult Category(string slug,int? page)
        {
            var pageNumber = page ?? 1;
            if(slug == null)
            {
                ViewBag.Products = _context.Product
                          .Where(p => p.isActive == 1 && p.isDelete == 0)
                          .ToList().ToPagedList(pageNumber,3);
            }
            else
            {
                ViewBag.Products = _context.Product
                          .Where(p => p.SubCategory.Category.Slug == slug && p.isActive == 1 && p.isDelete == 0)
                          .ToList().ToPagedList(pageNumber, 3);
            }
            ViewBag.Category = _category.GetAllActiveCategories();
            return View();
        }
        [Route("SubCategory")]
        [Route("SubCategory/{slug}")]
        [Route("SubCategory/{slug}/{page}")]
        [HttpGet]
        public IActionResult SubCategory(string slug, int? page)
        {
            var pageNumber = page ?? 1;
            if (slug == null)
            {
                ViewBag.Products = _context.Product
                          .Where(p => p.isActive == 1 && p.isDelete == 0)
                          .ToList().ToPagedList(pageNumber, 3);
            }
            else
            {
                ViewBag.Products = _context.Product
                          .Where(p => p.SubCategory.Slug == slug && p.isActive == 1 && p.isDelete == 0)
                          .ToList().ToPagedList(pageNumber, 3);
            }
            ViewBag.Category = _category.GetAllActiveCategories();
            return View();
        }

        [Route("ProductDetails/{slug}")]
        [HttpGet]
        public IActionResult ProductDetails(string slug)
        {
            if (slug == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var model = _context
                .Product
                .Where(x => x.Slug == slug && x.isDelete == 0 && x.isActive == 1)
                .Select(Product => new ProductModel()
                {
                    Id = Product.Id,
                    ProductName = Product.ProductName,
                    Slug = Product.Slug,
                    SubCategoryId = Product.SubCategoryId,
                    ProductBrand = Product.ProductBrand,
                    UrlImage = Product.UrlImage,
                    OrginalPrice = Product.OrginalPrice,
                    DiscountPrice = Product.DiscountPrice,
                    ProductImage = Product.ProductImage.Select(I => new ImageModel()
                    {
                        Id = I.Id,
                        ImageName = I.ImageName,
                        ImagesUrl = I.ImagesUrl
                    }).ToList(),
                    ProductDescription = Product.ProductDescription
                    .Select(D => new ProductDescriptionModel()
                    {
                        Id = D.Id,
                        Slug = D.Slug,
                        LongDescription = D.LongDescription
                    }).ToList(),
                }).FirstOrDefault();
            return View(model);
        }

     
        [HttpGet]
        [Route("Search")]
        [Route("Search/Page/{page}")]
        public IActionResult Search(string q,int? page)
        {
            var pageNumber = page ?? 1;
            var keyword = (string.IsNullOrEmpty(q) ? " " : q);
            ViewBag.Search = keyword;
            var products = _context.Product
                           .Include(s => s.SubCategory)
                           .ThenInclude(c => c.Category)
                           .Where(e => e.isActive == 1 
                            && e.isDelete == 0 
                            && e.Slug.Contains(keyword) || 
                            e.SubCategory.Slug.Contains(keyword) ||
                            e.SubCategory.Category.Slug.Contains(keyword)).ToList();          
            if (products != null)
            {
                ViewBag.Products = products.ToPagedList(pageNumber, 3);
            }
            else
            {
                ViewBag.Products = _context.Product
                          .Where(e => e.isActive == 1 && e.isDelete == 0)
                          .ToList().ToPagedList(pageNumber, 3);
            }
            ViewBag.keyword = keyword;
            ViewBag.Category = _category.GetAllActiveCategories();
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }
    }
}
