#pragma checksum "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Shared\Components\TenantChange\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1d0271c96a0909654f37de0ab3180c9a955f478c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_TenantChange_Default), @"mvc.1.0.view", @"/Views/Shared/Components/TenantChange/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/TenantChange/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_TenantChange_Default))]
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
#line 1 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\_ViewImports.cshtml"
using Abp.Localization;

#line default
#line hidden
#line 1 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Shared\Components\TenantChange\Default.cshtml"
using GSoft.AbpZeroTemplate.Web.Resources;

#line default
#line hidden
#line 2 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Shared\Components\TenantChange\Default.cshtml"
using GSoft.AbpZeroTemplate.Web.Views.Shared.Components.TenantChange;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1d0271c96a0909654f37de0ab3180c9a955f478c", @"/Views/Shared/Components/TenantChange/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47b1e16907496b203fba5485cd552517620edae5", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_TenantChange_Default : GSoft.AbpZeroTemplate.Web.Views.AbpZeroTemplateRazorPage<TenantChangeViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 5 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Shared\Components\TenantChange\Default.cshtml"
  
    WebResourceManager.AddScript(ApplicationPath + "view-resources/Views/Shared/Components/TenantChange/Default.js");

#line default
#line hidden
            BeginContext(319, 44, true);
            WriteLiteral("<span class=\"tenant-change-component\">\r\n    ");
            EndContext();
            BeginContext(364, 18, false);
#line 9 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Shared\Components\TenantChange\Default.cshtml"
Write(L("CurrentTenant"));

#line default
#line hidden
            EndContext();
            BeginContext(382, 5, true);
            WriteLiteral(":\r\n\r\n");
            EndContext();
#line 11 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Shared\Components\TenantChange\Default.cshtml"
     if (Model.Tenant != null)
    {

#line default
#line hidden
            BeginContext(426, 13, true);
            WriteLiteral("        <span");
            EndContext();
            BeginWriteAttribute("title", " title=\"", 439, "\"", 465, 1);
#line 13 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Shared\Components\TenantChange\Default.cshtml"
WriteAttributeValue("", 447, Model.Tenant.Name, 447, 18, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(466, 9, true);
            WriteLiteral("><strong>");
            EndContext();
            BeginContext(476, 24, false);
#line 13 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Shared\Components\TenantChange\Default.cshtml"
                                            Write(Model.Tenant.TenancyName);

#line default
#line hidden
            EndContext();
            BeginContext(500, 18, true);
            WriteLiteral("</strong></span>\r\n");
            EndContext();
#line 14 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Shared\Components\TenantChange\Default.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(542, 14, true);
            WriteLiteral("        <span>");
            EndContext();
            BeginContext(557, 16, false);
#line 17 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Shared\Components\TenantChange\Default.cshtml"
         Write(L("NotSelected"));

#line default
#line hidden
            EndContext();
            BeginContext(573, 9, true);
            WriteLiteral("</span>\r\n");
            EndContext();
#line 18 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Shared\Components\TenantChange\Default.cshtml"
    }

#line default
#line hidden
            BeginContext(589, 19, true);
            WriteLiteral("\r\n    (<a href=\"#\">");
            EndContext();
            BeginContext(609, 11, false);
#line 20 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Shared\Components\TenantChange\Default.cshtml"
            Write(L("Change"));

#line default
#line hidden
            EndContext();
            BeginContext(620, 14, true);
            WriteLiteral("</a>)\r\n</span>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IWebResourceManager WebResourceManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TenantChangeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591