#pragma checksum "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Payment\_PayPal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8ca31dfe7e66a828529e372b3df8eee2e81fd5ef"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Payment__PayPal), @"mvc.1.0.view", @"/Views/Payment/_PayPal.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Payment/_PayPal.cshtml", typeof(AspNetCore.Views_Payment__PayPal))]
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
#line 1 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Payment\_PayPal.cshtml"
using IdentityServer4.Extensions;

#line default
#line hidden
#line 2 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Payment\_PayPal.cshtml"
using GSoft.AbpZeroTemplate.MultiTenancy.Payments;

#line default
#line hidden
#line 3 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Payment\_PayPal.cshtml"
using GSoft.AbpZeroTemplate.Web.Resources;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ca31dfe7e66a828529e372b3df8eee2e81fd5ef", @"/Views/Payment/_PayPal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47b1e16907496b203fba5485cd552517620edae5", @"/Views/_ViewImports.cshtml")]
    public class Views_Payment__PayPal : GSoft.AbpZeroTemplate.Web.Views.AbpZeroTemplateRazorPage<GSoft.AbpZeroTemplate.Web.Models.Payment.PaymentViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 6 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Payment\_PayPal.cshtml"
  
    WebResourceManager.AddScript("https://www.paypalobjects.com/api/checkout.js");
    WebResourceManager.AddScript(ApplicationPath + "view-resources/Views/Payment/_PayPal.js");

#line default
#line hidden
            BeginContext(432, 46, true);
            WriteLiteral("\r\n<input type=\"hidden\" id=\"paypal-environment\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 478, "\"", 564, 1);
#line 11 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Payment\_PayPal.cshtml"
WriteAttributeValue("", 486, Model.GetAdditionalData(SubscriptionPaymentGatewayType.Paypal, "Environment"), 486, 78, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(565, 105, true);
            WriteLiteral(" />\r\n<input type=\"hidden\" name=\"PaymentId\" value=\"\" />\r\n<input type=\"hidden\" name=\"PayerId\" value=\"\" />\r\n");
            EndContext();
#line 14 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Payment\_PayPal.cshtml"
 if (!Model.GetAdditionalData(SubscriptionPaymentGatewayType.Paypal, "DemoUsername").IsNullOrEmpty())
{

#line default
#line hidden
            BeginContext(776, 217, true);
            WriteLiteral("    <div class=\"m-alert m-alert--icon m-alert--icon-solid m-alert--outline alert alert-brand alert-dismissible fade show\" role=\"alert\">\r\n        <div class=\"m-alert__icon\">\r\n            <i class=\"flaticon-exclamation\"");
            EndContext();
            BeginWriteAttribute("aria-label", " aria-label=\"", 993, "\"", 1019, 1);
#line 18 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Payment\_PayPal.cshtml"
WriteAttributeValue("", 1006, L("Payment"), 1006, 13, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1020, 121, true);
            WriteLiteral("></i>\r\n            <span></span>\r\n        </div>\r\n        <div class=\"m-alert__text\">\r\n            <h4>\r\n                ");
            EndContext();
            BeginContext(1142, 22, false);
#line 23 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Payment\_PayPal.cshtml"
           Write(L("DemoPayPalAccount"));

#line default
#line hidden
            EndContext();
            BeginContext(1164, 60, true);
            WriteLiteral("\r\n            </h4>\r\n            <p>\r\n                <span>");
            EndContext();
            BeginContext(1225, 13, false);
#line 26 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Payment\_PayPal.cshtml"
                 Write(L("UserName"));

#line default
#line hidden
            EndContext();
            BeginContext(1238, 10, true);
            WriteLiteral(": <strong>");
            EndContext();
            BeginContext(1249, 78, false);
#line 26 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Payment\_PayPal.cshtml"
                                         Write(Model.GetAdditionalData(SubscriptionPaymentGatewayType.Paypal, "DemoUsername"));

#line default
#line hidden
            EndContext();
            BeginContext(1327, 46, true);
            WriteLiteral("</strong></span><br />\r\n                <span>");
            EndContext();
            BeginContext(1374, 13, false);
#line 27 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Payment\_PayPal.cshtml"
                 Write(L("Password"));

#line default
#line hidden
            EndContext();
            BeginContext(1387, 10, true);
            WriteLiteral(": <strong>");
            EndContext();
            BeginContext(1398, 78, false);
#line 27 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Payment\_PayPal.cshtml"
                                         Write(Model.GetAdditionalData(SubscriptionPaymentGatewayType.Paypal, "DemoPassword"));

#line default
#line hidden
            EndContext();
            BeginContext(1476, 64, true);
            WriteLiteral("</strong></span>\r\n            </p>\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 31 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Payment\_PayPal.cshtml"
}

#line default
#line hidden
            BeginContext(1543, 30, true);
            WriteLiteral("<div id=\"paypal-button\"></div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GSoft.AbpZeroTemplate.Web.Models.Payment.PaymentViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591