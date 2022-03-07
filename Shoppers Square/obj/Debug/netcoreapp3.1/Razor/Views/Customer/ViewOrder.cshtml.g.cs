#pragma checksum "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Customer\ViewOrder.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "891f52f473ec1a573d0225cda6ba5be83833e528"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_ViewOrder), @"mvc.1.0.view", @"/Views/Customer/ViewOrder.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"891f52f473ec1a573d0225cda6ba5be83833e528", @"/Views/Customer/ViewOrder.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20e8fc8c51c6604de165577cee2e20c4f24504f0", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_ViewOrder : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<OrderItemModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Customer\ViewOrder.cshtml"
  
    Layout = "_Customer";
    ViewData["Title"] = "View Order";
    var counter = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container"">
    <div class=""row"">
        <div class=""col-xl-12 col-lg-12"">
            <div class=""card shadow mb-4"">
                <div class=""card-header py-3"">
                    <h6 class=""m-0 font-weight-bold text-primary"">Order Details</h6>
                </div>
                <div class=""card-body"">
                    <div class=""table-responsive"">
                        <table class=""table table-bordered"">
                            <thead>
                                <tr>
                                    <th>S.No</th>
                                    <th>Product</th>
                                    <th>Quantity</th>
                                    <th>Price</th>
                                    <th>Total</th>
                                </tr>
                            </thead>
");
#nullable restore
#line 26 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Customer\ViewOrder.cshtml"
                             foreach (var orderItem in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tbody>\r\n                                    <tr>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 31 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Customer\ViewOrder.cshtml"
                                        Write(++counter);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            <img width=\"50\" class=\"rounded\"");
            BeginWriteAttribute("src", " src=\"", 1437, "\"", 1472, 1);
#nullable restore
#line 34 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Customer\ViewOrder.cshtml"
WriteAttributeValue("", 1443, orderItem.Product.UrlImage, 1443, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 37 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Customer\ViewOrder.cshtml"
                                        Write(orderItem.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 40 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Customer\ViewOrder.cshtml"
                                        Write(orderItem.Price.ToString("c"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>");
#nullable restore
#line 42 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Customer\ViewOrder.cshtml"
                                        Write((orderItem.Product.DiscountPrice * orderItem.Amount).ToString("c"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    </tr>\r\n                                </tbody>\r\n");
#nullable restore
#line 45 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Customer\ViewOrder.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <tfoot>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <th>Grand Total</th>
                                    <td>");
#nullable restore
#line 52 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Customer\ViewOrder.cshtml"
                                    Write(Model.Select(m => m.Price * m.Amount).Sum().ToString("c"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n                            </tfoot>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<OrderItemModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591