#pragma checksum "C:\Users\Ayman\OneDrive\Desktop\Projects\Shopify_Image_App\Shopify_Image_App\Views\Shared\ErrorPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "665754572b6bc94561854f5a0c432c9bc0402fd1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_ErrorPage), @"mvc.1.0.view", @"/Views/Shared/ErrorPage.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Ayman\OneDrive\Desktop\Projects\Shopify_Image_App\Shopify_Image_App\Views\_ViewImports.cshtml"
using Shopify_Image_App;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ayman\OneDrive\Desktop\Projects\Shopify_Image_App\Shopify_Image_App\Views\_ViewImports.cshtml"
using Shopify_Image_App.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Ayman\OneDrive\Desktop\Projects\Shopify_Image_App\Shopify_Image_App\Views\_ViewImports.cshtml"
using Shopify_Image_App.ViewModels.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Ayman\OneDrive\Desktop\Projects\Shopify_Image_App\Shopify_Image_App\Views\_ViewImports.cshtml"
using Shopify_Image_App.ViewModels.Images;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Ayman\OneDrive\Desktop\Projects\Shopify_Image_App\Shopify_Image_App\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"665754572b6bc94561854f5a0c432c9bc0402fd1", @"/Views/Shared/ErrorPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d2c0b68057c02a63d9d27cb0211d9cde4d92923", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_ErrorPage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"


<div class=""jumbotron jumbotron-fluid text-white text-center"" style=""background-color: indianred; margin-top: 200px;"">
    <div class=""container"">
        <h1 class=""display-4"">Error!</h1>
        <p class=""lead"" style=""font-size: 24px; font-weight: 200;"">");
#nullable restore
#line 8 "C:\Users\Ayman\OneDrive\Desktop\Projects\Shopify_Image_App\Shopify_Image_App\Views\Shared\ErrorPage.cshtml"
                                                              Write(Model);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <a class=\"btn btn-outline-light\" href=\"javascript:void(0);\" onclick=\"history.go(-1)\" ;>Go Back</a>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; }
    }
}
#pragma warning restore 1591