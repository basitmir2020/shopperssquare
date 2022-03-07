using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Shoppers_Square.Helpers;
using Shoppers_Square.IRepositories;
using Shoppers_Square.Models;
using Shoppers_Square.ViewModels;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Shoppers_Square.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Authorize(Policy = "AdminPolicy")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ICategoryRepository _category;
        private readonly ISubCategoryRepository _subcategory;
        private readonly IProductRepository _product;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IImagesRepository _images;
        private readonly IDataProtector _protector;
        private readonly IOrderRepository _order;
        private readonly IProductDescriptionRepository _description;
        private readonly IEnquiryRepository _enquiry;

        public AdminController(ILogger<AdminController> logger,IEnquiryRepository enquiry,IProductDescriptionRepository description, IOrderRepository order, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IDataProtectionProvider dataProtectionProvider, DataProtectionPurposeString dataProtectionPurposeString, IImagesRepository images, IWebHostEnvironment hostingEnvironment, IProductRepository product, ISubCategoryRepository subcategory, ICategoryRepository category)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _category = category;
            _subcategory = subcategory;
            _product = product;
            _hostingEnvironment = hostingEnvironment;
            _images = images;
            _protector = dataProtectionProvider.CreateProtector(dataProtectionPurposeString.ShoppersSquareRouteValues);
            _order = order;
            _description = description;
            _enquiry = enquiry;
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToAction("SignIn", "Account");
                }
                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }
                await _signInManager.RefreshSignInAsync(user);
                return RedirectToAction("Dashboard");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            var AdminCount = new AdminCountModel
            {
                Categories = _category.GetAllCategoryCount(),
                SubCategories = _subcategory.GetAllSubCategoryCount(),
                Products = _product.GetAllProductsCount(),
                ProductDescription = _description.GetAllProductsDescriptionCount(),
                Orders = _order.GetAllOrdersCount()
            };
            return View(AdminCount);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                if (categoryModel.CategoryImage != null)
                {
                    string FolderPath = "uploads/category/";
                    categoryModel.ImageUrl = await Upload(FolderPath, categoryModel.CategoryImage);

                }
                categoryModel.isActive = 0;
                categoryModel.isDelete = 0;
                categoryModel.Dated = DateTime.Now;
                
                if (_category.ExistAsync(categoryModel.Slug, 0))
                {
                    await _category.AddAsync(categoryModel);
                    return RedirectToAction(nameof(ListCategory));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "This Slug Already Exists!");
                }
            }
            return View(categoryModel);
        }

        [HttpGet]
        public async Task<IActionResult> ListCategory()
        {
            var category = await _category.GetAllAsync();
            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> EditCategory(int Id)
        {
            if (Id.Equals("")) return RedirectToAction(nameof(ListCategory));
            var categoryDetails = await _category.GetByIdAsync(Id);
            if (categoryDetails == null) return RedirectToAction(nameof(ListCategory));
            var model = new CategoryViewModel
            {
                Id = categoryDetails.Id,
                CategoryName = categoryDetails.CategoryName,
                Slug = categoryDetails.Slug,
                ImageUrl = categoryDetails.ImageUrl,
                isActive = categoryDetails.isActive
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(int Id, CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (Id.Equals("")) return RedirectToAction(nameof(ListCategory));
                if (_category.ExistAsync(model.Slug, model.Id))
                {
                    string folder = "uploads/category/";
                    if (model.CategoryImage != null && model.ImageUrl != null)
                    {
                        string filePath = Path.Combine(_hostingEnvironment.WebRootPath,folder, model.ImageUrl);
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                    }
                    model.ImageUrl = (model.CategoryImage == null) ? model.ImageUrl : await Upload(folder, model.CategoryImage);
                    var categoryModel = new CategoryModel
                    {
                        Id = model.Id,
                        CategoryName = model.CategoryName,
                        Slug = model.Slug,
                        ImageUrl = model.ImageUrl,
                        isActive = model.isActive,
                        isDelete = 0,
                    };
                    await _category.UpdateAsync(Id, categoryModel);
                    return RedirectToAction(nameof(ListCategory));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "This Slug Already Exists!");
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int Id)
        {
            if (Id.Equals("")) return RedirectToAction(nameof(ListCategory));
            var categoryDetails = await _category.GetByIdAsync(Id);
            if (categoryDetails == null) return RedirectToAction(nameof(ListCategory));
            return View(categoryDetails);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int Id, CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                if (Id.Equals("")) return RedirectToAction(nameof(ListCategory));
                categoryModel.isDelete = 1;
                await _category.DeleteAsync(Id, categoryModel);
                return RedirectToAction(nameof(ListCategory));
            }
            return View(categoryModel);
        }

        [HttpGet]
        public async Task<IActionResult> CreateSubCategory()
        {
            var dropdown = await _category.GetDropDownCategories();
            ViewBag.ListCategories = new SelectList(dropdown.Category, "Id", "CategoryName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubCategory(SubCategoryModel subCategoryModel)
        {
            if (ModelState.IsValid)
            {
                subCategoryModel.isActive = 0;
                subCategoryModel.isDelete = 0;
                subCategoryModel.Dated = DateTime.Now;
                if (_subcategory.ExistAsync(subCategoryModel.Slug, 0))
                {
                    if (subCategoryModel.SubCategoryImage != null)
                    {
                        string FolderPath = "uploads/subcategory/";
                        subCategoryModel.ImageUrl = await Upload(FolderPath, subCategoryModel.SubCategoryImage);

                    }
                    await _subcategory.AddAsync(subCategoryModel);
                    return RedirectToAction(nameof(ListSubCategory));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "This Slug Already Exists!");
                }
            }
            return View(subCategoryModel);
        }

        [HttpGet]
        public async Task<IActionResult> ListSubCategory()
        {
            var subCategory = await _subcategory.GetAllAsync(x => x.Category);
            return View(subCategory);
        }

        [HttpGet]
        public async Task<IActionResult> EditSubCategory(int Id)
        {
            if (Id.Equals("")) return RedirectToAction(nameof(ListSubCategory));
            var dropdown = await _category.GetDropDownCategories();
            ViewBag.ListCategories = new SelectList(dropdown.Category, "Id", "CategoryName");
            var subcategoryDetails = await _subcategory.GetByIdAsync(Id);
            if (subcategoryDetails == null) return RedirectToAction(nameof(ListSubCategory));
            var model = new SubCategoryViewModel
            {
                Id = subcategoryDetails.Id,
                CategoryId = subcategoryDetails.CategoryId,
                SubCategoryName = subcategoryDetails.SubCategoryName,
                Slug = subcategoryDetails.Slug,
                ImageUrl = subcategoryDetails.ImageUrl,
                isActive = subcategoryDetails.isActive
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditSubCategory(int Id, SubCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (Id.Equals("")) return RedirectToAction(nameof(ListSubCategory));
                string folder = "uploads/subcategory/";
                if (model.SubCategoryImage != null && model.ImageUrl != null)
                {
                    string filePath = Path.Combine(_hostingEnvironment.WebRootPath, folder, model.ImageUrl);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
                if (_subcategory.ExistAsync(model.Slug, model.Id))
                {
                    model.ImageUrl = (model.SubCategoryImage == null) ? model.ImageUrl : await Upload(folder, model.SubCategoryImage);
                    var subCategoryModel = new SubCategoryModel
                    {
                        Id = model.Id,
                        CategoryId = model.CategoryId,
                        SubCategoryName = model.SubCategoryName,
                        Slug = model.Slug,
                        ImageUrl = model.ImageUrl,
                        isDelete = 0,
                        isActive = model.isActive,
                    };
                    await _subcategory.UpdateAsync(Id, subCategoryModel);
                    return RedirectToAction(nameof(ListSubCategory));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "This Slug Already Exists!");
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteSubCategory(int Id)
        {
            if (Id.Equals("")) return RedirectToAction(nameof(ListSubCategory));
            var dropdown = await _category.GetDropDownCategories();
            ViewBag.ListCategories = new SelectList(dropdown.Category, "Id", "CategoryName");
            var subcategoryDetails = await _subcategory.GetByIdAsync(Id);
            if (subcategoryDetails == null) return RedirectToAction(nameof(ListSubCategory));
            return View(subcategoryDetails);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSubCategory(int id, SubCategoryModel subCategoryModel)
        {
            if (ModelState.IsValid)
            {
                if (id.Equals("")) return RedirectToAction(nameof(ListSubCategory));
                subCategoryModel.isDelete = 1;
                await _subcategory.DeleteAsync(id, subCategoryModel);
                return RedirectToAction(nameof(ListSubCategory));
            }
            return View(subCategoryModel);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProducts()
        {
            var categorydropdown = await _category.GetDropDownCategories();
            var subcategorydropdown = await _subcategory.GetDropDownSubCategories();
            ViewBag.ListCategories = new SelectList(categorydropdown.Category, "Id", "CategoryName");
            ViewBag.ListSubCategories = new SelectList(subcategorydropdown.SubCategory, "Id", "SubCategoryName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProducts(ProductModel productModel)
        {
            var categorydropdown = await _category.GetDropDownCategories();
            var subcategorydropdown = await _subcategory.GetDropDownSubCategories();
            ViewBag.ListCategories = new SelectList(categorydropdown.Category, "Id", "CategoryName");
            ViewBag.ListSubCategories = new SelectList(subcategorydropdown.SubCategory, "Id", "SubCategoryName");
            if (ModelState.IsValid)
            {
                if (productModel.Image != null)
                {
                    string FolderPath = "uploads/product/";
                    productModel.UrlImage = await Upload(FolderPath, productModel.Image);

                }
                productModel.isActive = 0;
                productModel.isDelete = 0;
                productModel.Dated = DateTime.Now;
                if (_product.ExistAsync(productModel.Slug, 0))
                {
                    await _product.AddAsync(productModel);
                    return RedirectToAction(nameof(ListProducts));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "This Slug Already Exists!");
                }
            }
            return View(productModel);
        }

        [HttpGet]
        public async Task<IActionResult> ListProducts()
        {
            var product = await _product.GetAllAsync(x => x.SubCategory);
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> ViewProducts(int Id)
        {
            if (Id.Equals("")) return RedirectToAction(nameof(ListProducts));
            var categorydropdown = await _category.GetDropDownCategories();
            var subcategorydropdown = await _subcategory.GetDropDownSubCategories();
            ViewBag.ListCategories = new SelectList(categorydropdown.Category, "Id", "CategoryName");
            ViewBag.ListSubCategories = new SelectList(subcategorydropdown.SubCategory, "Id", "SubCategoryName");
            var productDetails = await _product.GetByIdAsync(Id, x => x.SubCategory.Category);
            if (productDetails == null) return RedirectToAction(nameof(ListProducts));
            return View(productDetails);
        }

        [HttpPost]
        public IActionResult ViewProducts()
        {
            return RedirectToAction(nameof(ListProducts));
        }

        [HttpGet]
        public async Task<IActionResult> EditProducts(int Id)
        {
            var categorydropdown = await _category.GetDropDownCategories();
            var subcategorydropdown = await _subcategory.GetDropDownSubCategories();
            ViewBag.ListCategories = new SelectList(categorydropdown.Category, "Id", "CategoryName");
            ViewBag.ListSubCategories = new SelectList(subcategorydropdown.SubCategory, "Id", "SubCategoryName");
            if (Id.Equals("")) return RedirectToAction(nameof(ListProducts));
            var productDetails = await _product.GetByIdAsync(Id, x => x.SubCategory.Category);
            if (productDetails == null) return RedirectToAction(nameof(ListProducts));

            var response = new NewProductViewModel()
            {
                Id = productDetails.Id,
                CategoryId = productDetails.SubCategory.Category.Id,
                SubCategoryId = productDetails.SubCategoryId,
                ProductName = productDetails.ProductName,
                Slug = productDetails.Slug,
                ProductBrand = productDetails.ProductBrand,
                DiscountPrice = productDetails.DiscountPrice,
                OrginalPrice = productDetails.OrginalPrice,
                UrlImage = productDetails.UrlImage,
                isActive = productDetails.isActive
            };

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> EditProducts(int Id, NewProductViewModel model)
        {
            var categorydropdown = await _category.GetDropDownCategories();
            var subcategorydropdown = await _subcategory.GetDropDownSubCategories();
            ViewBag.ListCategories = new SelectList(categorydropdown.Category, "Id", "CategoryName");
            ViewBag.ListSubCategories = new SelectList(subcategorydropdown.SubCategory, "Id", "SubCategoryName");
            if (ModelState.IsValid)
            {
                if (Id.Equals("")) return RedirectToAction(nameof(ListProducts));
                if (model.Image != null && model.UrlImage != null)
                {
                    string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads/product", model.UrlImage);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }

                if (_product.ExistAsync(model.Slug, model.Id))
                {
                    string folder = "uploads/product/";
                    var productModel = new ProductModel
                    {
                        Id = model.Id,
                        SubCategoryId = model.SubCategoryId,
                        ProductName = model.ProductName,
                        Slug = model.Slug,
                        ProductBrand = model.ProductBrand,
                        OrginalPrice = model.OrginalPrice,
                        DiscountPrice = model.DiscountPrice,
                        isActive = model.isActive,
                        UrlImage = (model.Image == null) ? model.UrlImage : await Upload(folder, model.Image),
                    };
                    await _product.UpdateAsync(model.Id, productModel);
                    return RedirectToAction(nameof(ListProducts));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "This Slug Already Exists!");
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProducts(int Id)
        {
            if (Id.Equals("")) return RedirectToAction(nameof(ListProducts));
            var categorydropdown = await _category.GetDropDownCategories();
            var subcategorydropdown = await _subcategory.GetDropDownSubCategories();
            ViewBag.ListCategories = new SelectList(categorydropdown.Category, "Id", "CategoryName");
            ViewBag.ListSubCategories = new SelectList(subcategorydropdown.SubCategory, "Id", "SubCategoryName");
            var productDetails = await _product.GetByIdAsync(Id, x => x.SubCategory.Category);
            if (productDetails == null) return RedirectToAction(nameof(ListProducts));
            var response = new NewProductViewModel()
            {
                Id = productDetails.Id,
                CategoryId = productDetails.SubCategory.Category.Id,
                SubCategoryId = productDetails.SubCategoryId,
                ProductName = productDetails.ProductName,
                Slug = productDetails.Slug,
                ProductBrand = productDetails.ProductBrand,
                DiscountPrice = productDetails.DiscountPrice,
                OrginalPrice = productDetails.OrginalPrice,
                isActive = productDetails.isActive
            };
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProducts(int id, ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                if (id.Equals("")) return RedirectToAction(nameof(ListProducts));
                productModel.isDelete = 1;
                await _product.DeleteAsync(id, productModel);
                return RedirectToAction(nameof(ListProducts));
            }
            return View(productModel);
        }

        [HttpGet]
        public async Task<IActionResult> UploadImage()
        {
            var productdropdown = await _product.GetDropDownProducts();
            ViewBag.ListProducts = new SelectList(productdropdown.Product, "Id", "ProductName");
            return View();
        }

        private async Task<string> Upload(string FolderPath, IFormFile file)
        {
            FolderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
            string serverFolder = Path.Combine(_hostingEnvironment.WebRootPath, FolderPath);
            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return "/" + FolderPath;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(UploadImageModel uploadImageModel)
        {
            var productdropdown = await _product.GetDropDownProducts();
            ViewBag.ListProducts = new SelectList(productdropdown.Product, "Id", "ProductName");
            if (uploadImageModel.ProductImages != null)
            {
                string folder = "uploads/";

                foreach (var file in uploadImageModel.ProductImages)
                {
                    var productImage = new ImageModel()
                    {
                        isActive = 0,
                        isDelete = 0,
                        Dated = DateTime.Now,
                        ProductId = uploadImageModel.ProductId,
                        ImageName = file.FileName,
                        ImagesUrl = await Upload(folder, file)
                    };
                    await _images.AddAsync(productImage);
                }
                return RedirectToAction(nameof(ListProductImages));
            }
            return View(uploadImageModel);
        }

        [HttpGet]
        public async Task<IActionResult> ListProductImages()
        {
            var images = await _images.GetAllAsync(x => x.Product);
            return View(images);
        }
        [HttpGet]
        public async Task<IActionResult> EditImage(int Id)
        {
            var productdropdown = await _product.GetDropDownProducts();
            ViewBag.ListProducts = new SelectList(productdropdown.Product, "Id", "ProductName");
            if (Id.Equals("")) return RedirectToAction(nameof(ListProductImages));
            var productImage = await _images.GetByIdAsync(Id, x => x.Product);
            if (productImage == null) return RedirectToAction(nameof(ListProducts));
            var response = new NewImageViewModel()
            {
                Id = productImage.Id,
                ProductId = productImage.ProductId,
                ImageUrl = productImage.ImagesUrl,
                ImageName = productImage.ImageName,
                isActive = productImage.isActive
            };
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> EditImage(int Id, NewImageViewModel newImageViewModel)
        {
            if (Id.Equals("")) return RedirectToAction(nameof(ListProductImages));
            var productdropdown = await _product.GetDropDownProducts();
            ViewBag.ListProducts = new SelectList(productdropdown.Product, "Id", "ProductName");
            if (newImageViewModel.Image != null && newImageViewModel.ImageUrl != null)
            {
                string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", newImageViewModel.ImageUrl);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
            }
            string folder = "uploads/";
            var imageModel = new ImageModel
            {
                Id = newImageViewModel.Id,
                ProductId = newImageViewModel.ProductId,
                ImagesUrl = (newImageViewModel.Image == null) ? newImageViewModel.ImageUrl : await Upload(folder, newImageViewModel.Image),
                ImageName = newImageViewModel.ImageName,
                isActive = newImageViewModel.isActive
            };
            await _images.UpdateAsync(newImageViewModel.Id, imageModel);
            return RedirectToAction(nameof(ListProductImages));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteImage(int Id)
        {
            var productdropdown = await _product.GetDropDownProducts();
            ViewBag.ListProducts = new SelectList(productdropdown.Product, "Id", "ProductName");
            if (Id.Equals("")) return RedirectToAction(nameof(ListProductImages));
            var productImage = await _images.GetByIdAsync(Id, x => x.Product);
            if (productImage == null) return RedirectToAction(nameof(ListProductImages));
            return View(productImage);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteImage(int Id, ImageModel imageModel)
        {
            if (Id.Equals("")) return RedirectToAction(nameof(ListProductImages));
            var productdropdown = await _product.GetDropDownProducts();
            ViewBag.ListProducts = new SelectList(productdropdown.Product, "Id", "ProductName");
            if (imageModel.ImagesUrl != null)
            {
                string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", imageModel.ImagesUrl);
                System.IO.File.Delete(filePath);
            }
            imageModel.isDelete = 1;
            await _images.DeleteAsync(Id, imageModel);
            return RedirectToAction(nameof(ListProductImages));
        }

        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = _userManager.Users;
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> ViewUser(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (Id.Equals("") || user == null)
            {
                return RedirectToAction(nameof(ListUsers));
            }
            var model = new ViewUserViewModel
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                EmailStatus = user.EmailConfirmed,
                Phone = user.PhoneNumber,
                UserName = user.UserName
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ListOrders()
        {
            var Orders = await _order.GetAllOrdersByAsync();
            return View(Orders);
        }
        [HttpGet]
        public async Task<IActionResult> ViewOrder(int Id)
        {
            var Orders = await _order.GetOrderItemsByOrderId(Id);
            return View(Orders);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOrder(int DELETEORDERID)
        {
            if (DELETEORDERID.Equals("")) return RedirectToAction(nameof(ListOrders));
            await _order.DeleteOrderAsync(DELETEORDERID);
            return Json("1");
        }

        [HttpPost]
        public JsonResult EnquiryOrder(int ENQUIRYORDERID)
        {
            if (ENQUIRYORDERID.Equals("")) RedirectToAction(nameof(ListOrders));
            var enq = _enquiry.SelectByIdAsync(ENQUIRYORDERID);
            var orderStatus = new OrderStatusModel
            {
                EnquiryId = enq.EnquiryId,
                OrderId = enq.OrderId,
                OrderStatus = enq.Order.OrderStatus,
                Description = enq.Description
            };
            return Json(orderStatus);
        }

        [HttpPost]
        public JsonResult OrderStatus(int ORDERID,string STATUS)
        {
            if (ORDERID.Equals("") && STATUS.Equals("")) RedirectToAction(nameof(ListOrders));
            _order.ChangeStatusByIdAsync(ORDERID, STATUS);
            return Json("1");
        }

        [HttpGet]
        public async Task<IActionResult> Description()
        {
            var productdropdown = await _product.GetDropDownProducts();
            ViewBag.ListProducts = new SelectList(productdropdown.Product, "Id", "ProductName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Description(ProductDescriptionModel model)
        {
            var productdropdown = await _product.GetDropDownProducts();
            ViewBag.ListProducts = new SelectList(productdropdown.Product, "Id", "ProductName");
            if (ModelState.IsValid)
            {
                model.isActive = 0;
                model.isDelete = 0;
                model.Dated = DateTime.Now;
                if (_description.ExistProductDescriptionAsync(0,model.ProductId))
                {
                    await _description.AddAsync(model);
                    return RedirectToAction(nameof(ListDescription));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Product Description Already Exists");
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ListDescription()
        {
            var productDescription = await _description.GetAllAsync(x => x.Product);
            return View(productDescription);
        }

        [HttpGet]
        public async Task<IActionResult> ViewDescription(int Id)
        {
            if (Id.Equals("")) return RedirectToAction(nameof(ListDescription));
            var productdropdown = await _product.GetDropDownProducts();
            ViewBag.ListProducts = new SelectList(productdropdown.Product, "Id", "ProductName");
            var ProductDescriptionDetails = await _description.GetByIdAsync(Id);
            if (ProductDescriptionDetails == null) return RedirectToAction(nameof(ListDescription));
            return View(ProductDescriptionDetails);
        }

        [HttpPost]
        public IActionResult ViewDescription()
        {
            return RedirectToAction(nameof(ListDescription));
        }

        [HttpGet]
        public async Task<IActionResult> EditDescription(int Id)
        {
            if (Id.Equals("")) return RedirectToAction(nameof(ListDescription));
            var productdropdown = await _product.GetDropDownProducts();
            ViewBag.ListProducts = new SelectList(productdropdown.Product, "Id", "ProductName");
            var ProductDescriptionDetails = await _description.GetByIdAsync(Id);
            if (ProductDescriptionDetails == null) return RedirectToAction(nameof(ListDescription));
            return View(ProductDescriptionDetails);
        }

        [HttpPost]
        public async Task<IActionResult> EditDescription(int Id,ProductDescriptionModel model)
        {
            if (ModelState.IsValid)
            {
                if (Id.Equals("")) return RedirectToAction(nameof(ListDescription));
                if (_description.ExistProductDescriptionAsync(Id,model.ProductId))
                {
                    await _description.UpdateAsync(Id, model);
                    return RedirectToAction(nameof(ListDescription));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "This Description Already Exists!");
                }
            }
            return View(model);
        }
    }
}

