#pragma checksum "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Home\Category.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "691cd791ae1a33d88d6a086e4ee7034ae61a02be"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Category), @"mvc.1.0.view", @"/Views/Home/Category.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\_ViewImports.cshtml"
using Shoppers_Square;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\_ViewImports.cshtml"
using Shoppers_Square.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\_ViewImports.cshtml"
using Shoppers_Square.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\_ViewImports.cshtml"
using Shoppers_Square.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\_ViewImports.cshtml"
using Shoppers_Square.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\_ViewImports.cshtml"
using Shoppers_Square.IRepositories;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\_ViewImports.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\_ViewImports.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\_ViewImports.cshtml"
using X.PagedList.Web.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\_ViewImports.cshtml"
using System.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Mvc;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"691cd791ae1a33d88d6a086e4ee7034ae61a02be", @"/Views/Home/Category.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20e8fc8c51c6604de165577cee2e20c4f24504f0", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Category : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SubCategory", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Orders", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddToShoppingCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ProductDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Home\Category.cshtml"
  
    Layout = "_Layout";
    ViewData["Title"] = "Category";

#line default
#line hidden
#nullable disable
            WriteLiteral("<!-- Breadcrumb Begin -->\r\n<div class=\"breadcrumb-option\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-lg-12\">\r\n                <div class=\"breadcrumb__links\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "691cd791ae1a33d88d6a086e4ee7034ae61a02be7358", async() => {
                WriteLiteral("<i class=\"fa fa-home\"></i> Home");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    <span>Shop</span>
                </div>
            </div>
        </div>
    </div>
</div>
<!-- Breadcrumb End -->
<!-- Shop Section Begin -->
<section class=""shop spad"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-3 col-md-3"">
                <div class=""shop__sidebar"">
                    <div class=""sidebar__categories"">
                        <div class=""section-title"">
                            <h4>Categories</h4>
                        </div>
                        <div class=""categories__accordion"">
                            <div class=""accordion"" id=""accordionExample"">
");
#nullable restore
#line 33 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Home\Category.cshtml"
                                 foreach (var category in ViewBag.Category)
                                {
                                    var count = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <div class=\"card\">\r\n                                        <div class=\"card-heading active\">\r\n                                            <a data-toggle=\"collapse\" data-target=\"#collapse");
#nullable restore
#line 38 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Home\Category.cshtml"
                                                                                        Write(++count);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">");
#nullable restore
#line 38 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Home\Category.cshtml"
                                                                                                    Write(category.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                        </div>\r\n                                        <div");
            BeginWriteAttribute("id", " id=\"", 1665, "\"", 1686, 2);
            WriteAttributeValue("", 1670, "collapse", 1670, 8, true);
#nullable restore
#line 40 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Home\Category.cshtml"
WriteAttributeValue("", 1678, count, 1678, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"collapse show\" data-parent=\"#accordionExample\">\r\n                                            <div class=\"card-body\">\r\n                                                <ul>\r\n");
#nullable restore
#line 43 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Home\Category.cshtml"
                                                     foreach (var subcategory in _subcategory.getAllActiveSubCategories(category.Id))
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "691cd791ae1a33d88d6a086e4ee7034ae61a02be11850", async() => {
#nullable restore
#line 45 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Home\Category.cshtml"
                                                                                                                                             Write(subcategory.SubCategoryName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-slug", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 45 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Home\Category.cshtml"
                                                                                                                  WriteLiteral(subcategory.Slug);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["slug"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-slug", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["slug"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n");
#nullable restore
#line 46 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Home\Category.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                </ul>\r\n                                            </div>\r\n                                        </div>\r\n                                    </div>\r\n");
#nullable restore
#line 51 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Home\Category.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <div class=\"col-lg-9 col-md-9\">\r\n                <div class=\"row\">\r\n");
#nullable restore
#line 59 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Home\Category.cshtml"
                     foreach (var product in ViewBag.Products)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"col-lg-4 col-md-6\">\r\n                            <div class=\"product__item\">\r\n                                <div class=\"product__item__pic set-bg\" data-setbg=\"");
#nullable restore
#line 63 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Home\Category.cshtml"
                                                                               Write(product.UrlImage);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                                    <div class=\"label new\">New</div>\r\n                                    <ul class=\"product__hover\">\r\n                                        <li><a");
            BeginWriteAttribute("href", " href=\"", 3240, "\"", 3266, 1);
#nullable restore
#line 66 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Home\Category.cshtml"
WriteAttributeValue("", 3247, product.UrlImage, 3247, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"image-popup\"><span class=\"arrow_expand\"></span></a></li>\r\n                                        <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "691cd791ae1a33d88d6a086e4ee7034ae61a02be17040", async() => {
                WriteLiteral("<span class=\"icon_bag_alt\"></span>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 67 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Home\Category.cshtml"
                                                                                                         WriteLiteral(product.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n                                    </ul>\r\n                                </div>\r\n                                <div class=\"product__item__text\">\r\n                                    <h6>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "691cd791ae1a33d88d6a086e4ee7034ae61a02be19706", async() => {
#nullable restore
#line 71 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Home\Category.cshtml"
                                                                                                                          Write(product.ProductName);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-slug", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 71 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Home\Category.cshtml"
                                                                                                  WriteLiteral(product.Slug);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["slug"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-slug", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["slug"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</h6>
                                    <div class=""rating"">
                                        <i class=""fa fa-star""></i>
                                        <i class=""fa fa-star""></i>
                                        <i class=""fa fa-star""></i>
                                        <i class=""fa fa-star""></i>
                                        <i class=""fa fa-star""></i>
                                    </div>
                                    <div class=""product__price"">");
#nullable restore
#line 79 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Home\Category.cshtml"
                                                           Write(product.DiscountPrice.ToString("c"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<span>");
#nullable restore
#line 79 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Home\Category.cshtml"
                                                                                                     Write(product.OrginalPrice.ToString("c"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></div>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 83 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Home\Category.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <style>
                        .pageUl {
                            list-style: none;
                            margin: 0;
                            padding: 0;
                            overflow: hidden;
                        }
                        .pageLi {
                            margin-right:5px;
                            display:inline-flex;
                            justify-content:center;
                            align-items:center;
                        }
                        .pageUl > .active {
                            font-family: sans-serif;
                            background: #000;
                            color: white;
                            height: 40px;
                            width: 40px;
                            border: 1px solid #f2f2f2;
                            border-radius: 50%;
                            font-weight: 600;
                        }
                    </style>
              ");
            WriteLiteral("      <div class=\"col-lg-12\">\r\n                        ");
#nullable restore
#line 109 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Home\Category.cshtml"
                   Write(Html.PagedListPager((IPagedList)ViewBag.Products,
                             page => Url.Action("Category", "Home",
                                new
                                {
                                    page = page
                                }), new PagedListRenderOptions()
                                {
                                    ContainerDivClasses = new List<string> { "pagination__option" },
                                    UlElementClasses = new List<string> { "text-center" , "pageUl" },
                                    LiElementClasses = new List<string> { "pageLi" }
                                }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n<!-- Shop Section End -->\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public ISubCategoryRepository _subcategory { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUser> signInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
