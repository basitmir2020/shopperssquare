#pragma checksum "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Customer\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c224946a690108f87fc03b780720da7cc5f02195"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_Dashboard), @"mvc.1.0.view", @"/Views/Customer/Dashboard.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c224946a690108f87fc03b780720da7cc5f02195", @"/Views/Customer/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20e8fc8c51c6604de165577cee2e20c4f24504f0", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Customer\Dashboard.cshtml"
  
    Layout = "_Customer";
    ViewData["Title"] = "Dashboard";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""container-fluid"">
    <div class=""row"">
        <div class=""col-xl-3 col-md-6 mb-4"">
            <div class=""card border-left-primary shadow h-100 py-2"">
                <div class=""card-body"">
                    <div class=""row no-gutters align-items-center"">
                        <div class=""col mr-2"">
                            <div class=""text-xs font-weight-bold text-primary text-uppercase mb-1"">Orders</div>
                            <div class=""h5 mb-0 font-weight-bold text-gray-800"">");
#nullable restore
#line 14 "C:\Users\basiit\source\repos\Shoppers Square\Shoppers Square\Views\Customer\Dashboard.cshtml"
                                                                           Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>
                        </div>
                        <div class=""col-auto"">
                            <i class=""fas fa-cart-plus fa-2x text-gray-300""></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int> Html { get; private set; }
    }
}
#pragma warning restore 1591