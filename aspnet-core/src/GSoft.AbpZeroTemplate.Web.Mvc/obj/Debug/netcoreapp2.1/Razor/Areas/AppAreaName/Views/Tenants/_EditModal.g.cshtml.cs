#pragma checksum "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dd45f4988f6aef2f2d1d701f43fd2f4a20035f70"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_AppAreaName_Views_Tenants__EditModal), @"mvc.1.0.view", @"/Areas/AppAreaName/Views/Tenants/_EditModal.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/AppAreaName/Views/Tenants/_EditModal.cshtml", typeof(AspNetCore.Areas_AppAreaName_Views_Tenants__EditModal))]
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
#line 1 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\_ViewImports.cshtml"
using Abp.Localization;

#line default
#line hidden
#line 1 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
using Abp.Extensions;

#line default
#line hidden
#line 2 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
using GSoft.AbpZeroTemplate.MultiTenancy;

#line default
#line hidden
#line 3 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
using GSoft.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Common.Modals;

#line default
#line hidden
#line 4 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
using GSoft.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Tenants;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd45f4988f6aef2f2d1d701f43fd2f4a20035f70", @"/Areas/AppAreaName/Views/Tenants/_EditModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47b1e16907496b203fba5485cd552517620edae5", @"/Areas/AppAreaName/Views/_ViewImports.cshtml")]
    public class Areas_AppAreaName_Views_Tenants__EditModal : GSoft.AbpZeroTemplate.Web.Views.AbpZeroTemplateRazorPage<EditTenantViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("TenantInformationsForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(234, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(237, 152, false);
#line 7 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
Write(Html.Partial("~/Areas/AppAreaName/Views/Common/Modals/_ModalHeader.cshtml", new ModalHeaderViewModel(L("EditTenant") + ": " + Model.Tenant.TenancyName)));

#line default
#line hidden
            EndContext();
            BeginContext(389, 36, true);
            WriteLiteral("\r\n\r\n<div class=\"modal-body\">\r\n\r\n    ");
            EndContext();
            BeginContext(425, 3068, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "88566b15691641b8a73911a3973fff31", async() => {
                BeginContext(461, 42, true);
                WriteLiteral("\r\n\r\n        <input type=\"hidden\" name=\"Id\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 503, "\"", 527, 1);
#line 13 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
WriteAttributeValue("", 511, Model.Tenant.Id, 511, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(528, 52, true);
                WriteLiteral(" />\r\n        <input type=\"hidden\" name=\"TenancyName\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 580, "\"", 613, 1);
#line 14 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
WriteAttributeValue("", 588, Model.Tenant.TenancyName, 588, 25, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(614, 71, true);
                WriteLiteral(" />\r\n\r\n        <div class=\"form-group\">\r\n            <label for=\"Name\">");
                EndContext();
                BeginContext(686, 9, false);
#line 17 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
                         Write(L("Name"));

#line default
#line hidden
                EndContext();
                BeginContext(695, 62, true);
                WriteLiteral("</label>\r\n            <input id=\"Name\" type=\"text\" name=\"Name\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 757, "\"", 783, 1);
#line 18 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
WriteAttributeValue("", 765, Model.Tenant.Name, 765, 18, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(784, 37, true);
                WriteLiteral(" class=\"form-control edited\" required");
                EndContext();
                BeginWriteAttribute("maxlength", " maxlength=\"", 821, "\"", 854, 1);
#line 18 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
WriteAttributeValue("", 833, Tenant.MaxNameLength, 833, 21, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(855, 21, true);
                WriteLiteral(">\r\n        </div>\r\n\r\n");
                EndContext();
#line 21 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
         if (!Model.Tenant.ConnectionString.IsNullOrEmpty())
        {

#line default
#line hidden
                BeginContext(949, 84, true);
                WriteLiteral("            <div class=\"form-group\">\r\n                <label for=\"ConnectionString\">");
                EndContext();
                BeginContext(1034, 29, false);
#line 24 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
                                         Write(L("DatabaseConnectionString"));

#line default
#line hidden
                EndContext();
                BeginContext(1063, 118, true);
                WriteLiteral("</label>\r\n                <input id=\"ConnectionString\" type=\"text\" name=\"ConnectionString\" class=\"form-control edited\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1181, "\"", 1219, 1);
#line 25 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
WriteAttributeValue("", 1189, Model.Tenant.ConnectionString, 1189, 30, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1220, 9, true);
                WriteLiteral(" required");
                EndContext();
                BeginWriteAttribute("maxlength", " maxlength=\"", 1229, "\"", 1274, 1);
#line 25 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
WriteAttributeValue("", 1241, Tenant.MaxConnectionStringLength, 1241, 33, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1275, 23, true);
                WriteLiteral(">\r\n            </div>\r\n");
                EndContext();
                BeginContext(1300, 73, true);
                WriteLiteral("            <div>\r\n                <span class=\"help-block text-warning\">");
                EndContext();
                BeginContext(1374, 55, false);
#line 29 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
                                                 Write(L("TenantDatabaseConnectionStringChangeWarningMessage"));

#line default
#line hidden
                EndContext();
                BeginContext(1429, 29, true);
                WriteLiteral("</span>\r\n            </div>\r\n");
                EndContext();
#line 31 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
        }

#line default
#line hidden
                BeginContext(1469, 71, true);
                WriteLiteral("\r\n        <div class=\"form-group\">\r\n            <label for=\"EditionId\">");
                EndContext();
                BeginContext(1541, 12, false);
#line 34 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
                              Write(L("Edition"));

#line default
#line hidden
                EndContext();
                BeginContext(1553, 85, true);
                WriteLiteral("</label>\r\n            <select class=\"form-control\" id=\"EditionId\" name=\"EditionId\">\r\n");
                EndContext();
#line 36 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
                 foreach (var edition in Model.EditionItems)
                {

#line default
#line hidden
                BeginContext(1719, 20, true);
                WriteLiteral("                    ");
                EndContext();
                BeginContext(1739, 121, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8c89e32625344196bfbfe2d28c7f33c6", async() => {
                    BeginContext(1832, 19, false);
#line 38 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
                                                                                                           Write(edition.DisplayText);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 38 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
                       WriteLiteral(edition.Value);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
#line 38 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
                                                           Write(edition.IsFree);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("data-isfree", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "selected", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#line 38 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
AddHtmlAttributeValue("", 1810, edition.IsSelected, 1810, 19, false);

#line default
#line hidden
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1860, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 39 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
                }

#line default
#line hidden
                BeginContext(1881, 239, true);
                WriteLiteral("            </select>\r\n        </div>\r\n        \r\n        <div class=\"m-checkbox-list subscription-component\">\r\n            <label class=\"m-checkbox\">\r\n                <input id=\"CreateTenant_IsUnlimited\" type=\"checkbox\" name=\"IsUnlimited\" ");
                EndContext();
                BeginContext(2122, 74, false);
#line 45 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
                                                                                    Write(!Model.Tenant.SubscriptionEndDateUtc.HasValue ? "checked=\"checked\"" : "");

#line default
#line hidden
                EndContext();
                BeginContext(2197, 21, true);
                WriteLiteral(" />\r\n                ");
                EndContext();
                BeginContext(2219, 30, false);
#line 46 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
           Write(L("UnlimitedTimeSubscription"));

#line default
#line hidden
                EndContext();
                BeginContext(2249, 186, true);
                WriteLiteral("\r\n                <span></span>\r\n            </label>\r\n        </div>\r\n        \r\n        <div class=\"form-group subscription-component\">\r\n            <label for=\"SubscriptionEndDateUtc\">");
                EndContext();
                BeginContext(2436, 27, false);
#line 52 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
                                           Write(L("SubscriptionEndDateUtc"));

#line default
#line hidden
                EndContext();
                BeginContext(2463, 102, true);
                WriteLiteral("</label>\r\n            <input id=\"SubscriptionEndDateUtc\" type=\"datetime\" name=\"SubscriptionEndDateUtc\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2565, "\"", 2611, 1);
#line 53 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
WriteAttributeValue("", 2573, Model.Tenant.SubscriptionEndDateUtc, 2573, 38, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2612, 46, true);
                WriteLiteral(" class=\"form-control edited date-time-picker\" ");
                EndContext();
                BeginContext(2660, 63, false);
#line 53 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
                                                                                                                                                                                     Write(!Model.Tenant.SubscriptionEndDateUtc.HasValue ? "required" : "");

#line default
#line hidden
                EndContext();
                BeginContext(2724, 238, true);
                WriteLiteral(">\r\n        </div>\r\n        \r\n        <div class=\"m-checkbox-list subscription-component\">\r\n            <label class=\"m-checkbox\">\r\n                <input id=\"EditTenant_IsInTrialPeriod\" type=\"checkbox\" name=\"IsInTrialPeriod\" value=\"true\" ");
                EndContext();
                BeginContext(2964, 57, false);
#line 58 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
                                                                                                       Write(Model.Tenant.IsInTrialPeriod ? "checked=\"checked\"" : "");

#line default
#line hidden
                EndContext();
                BeginContext(3022, 21, true);
                WriteLiteral(" />\r\n                ");
                EndContext();
                BeginContext(3044, 20, false);
#line 59 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
           Write(L("IsInTrialPeriod"));

#line default
#line hidden
                EndContext();
                BeginContext(3064, 253, true);
                WriteLiteral("\r\n                <span></span>\r\n            </label>\r\n        </div>\r\n        \r\n        <div class=\"m-checkbox-list\">\r\n            <label class=\"m-checkbox\">\r\n                <input id=\"EditTenant_IsActive\" type=\"checkbox\" name=\"IsActive\" value=\"true\" ");
                EndContext();
                BeginContext(3318, 60, false);
#line 66 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
                                                                                        Write(Html.Raw(Model.Tenant.IsActive ? "checked=\"checked\"" : ""));

#line default
#line hidden
                EndContext();
                BeginContext(3378, 19, true);
                WriteLiteral(">\r\n                ");
                EndContext();
                BeginContext(3398, 11, false);
#line 67 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
           Write(L("Active"));

#line default
#line hidden
                EndContext();
                BeginContext(3409, 77, true);
                WriteLiteral("\r\n                <span></span>\r\n            </label>\r\n        </div>\r\n\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3493, 14, true);
            WriteLiteral("\r\n\r\n</div>\r\n\r\n");
            EndContext();
            BeginContext(3508, 92, false);
#line 76 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_EditModal.cshtml"
Write(Html.Partial("~/Areas/AppAreaName/Views/Common/Modals/_ModalFooterWithSaveAndCancel.cshtml"));

#line default
#line hidden
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EditTenantViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591