#pragma checksum "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "691945e8af0b15df10d11d390a43f33fd18829d5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_AppAreaName_Views_Tenants__CreateModal), @"mvc.1.0.view", @"/Areas/AppAreaName/Views/Tenants/_CreateModal.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/AppAreaName/Views/Tenants/_CreateModal.cshtml", typeof(AspNetCore.Areas_AppAreaName_Views_Tenants__CreateModal))]
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
#line 1 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
using Abp.Json;

#line default
#line hidden
#line 2 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
using GSoft.AbpZeroTemplate.MultiTenancy;

#line default
#line hidden
#line 3 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
using GSoft.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Common.Modals;

#line default
#line hidden
#line 4 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
using GSoft.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Tenants;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"691945e8af0b15df10d11d390a43f33fd18829d5", @"/Areas/AppAreaName/Views/Tenants/_CreateModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47b1e16907496b203fba5485cd552517620edae5", @"/Areas/AppAreaName/Views/_ViewImports.cshtml")]
    public class Areas_AppAreaName_Views_Tenants__CreateModal : GSoft.AbpZeroTemplate.Web.Views.AbpZeroTemplateRazorPage<CreateTenantViewModel>
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
        private global::GSoft.AbpZeroTemplate.Web.TagHelpers.AbpZeroTemplateScriptSrcTagHelper __GSoft_AbpZeroTemplate_Web_TagHelpers_AbpZeroTemplateScriptSrcTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(230, 132, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4308b7ca6f0d401c8c1c70f09e8ecf09", async() => {
                BeginContext(238, 41, true);
                WriteLiteral("\r\n    window.passwordComplexitySetting = ");
                EndContext();
                BeginContext(280, 70, false);
#line 7 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
                                  Write(Html.Raw(Model.PasswordComplexitySetting.ToJsonString(indented: true)));

#line default
#line hidden
                EndContext();
                BeginContext(350, 3, true);
                WriteLiteral(";\r\n");
                EndContext();
            }
            );
            __GSoft_AbpZeroTemplate_Web_TagHelpers_AbpZeroTemplateScriptSrcTagHelper = CreateTagHelper<global::GSoft.AbpZeroTemplate.Web.TagHelpers.AbpZeroTemplateScriptSrcTagHelper>();
            __tagHelperExecutionContext.Add(__GSoft_AbpZeroTemplate_Web_TagHelpers_AbpZeroTemplateScriptSrcTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(362, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(365, 123, false);
#line 9 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
Write(Html.Partial("~/Areas/AppAreaName/Views/Common/Modals/_ModalHeader.cshtml", new ModalHeaderViewModel(L("CreateNewTenant"))));

#line default
#line hidden
            EndContext();
            BeginContext(488, 34, true);
            WriteLiteral("\r\n\r\n<div class=\"modal-body\">\r\n    ");
            EndContext();
            BeginContext(522, 5100, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "76d35f6440f44e9da6fff7e35710862f", async() => {
                BeginContext(558, 73, true);
                WriteLiteral("\r\n        <div class=\"form-group\">\r\n            <label for=\"TenancyName\">");
                EndContext();
                BeginContext(632, 16, false);
#line 14 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
                                Write(L("TenancyName"));

#line default
#line hidden
                EndContext();
                BeginContext(648, 106, true);
                WriteLiteral("</label>\r\n            <input id=\"TenancyName\" class=\"form-control\" type=\"text\" name=\"TenancyName\" required");
                EndContext();
                BeginWriteAttribute("maxlength", " maxlength=\"", 754, "\"", 794, 1);
#line 15 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
WriteAttributeValue("", 766, Tenant.MaxTenancyNameLength, 766, 28, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginWriteAttribute("regex", " regex=\"", 795, "\"", 827, 1);
#line 15 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
WriteAttributeValue("", 803, Tenant.TenancyNameRegex, 803, 24, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(828, 93, true);
                WriteLiteral(">\r\n        </div>\r\n\r\n        <div class=\"form-group no-hint\">\r\n            <label for=\"Name\">");
                EndContext();
                BeginContext(922, 9, false);
#line 19 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
                         Write(L("Name"));

#line default
#line hidden
                EndContext();
                BeginContext(931, 92, true);
                WriteLiteral("</label>\r\n            <input id=\"Name\" type=\"text\" name=\"Name\" class=\"form-control\" required");
                EndContext();
                BeginWriteAttribute("maxlength", " maxlength=\"", 1023, "\"", 1056, 1);
#line 20 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
WriteAttributeValue("", 1035, Tenant.MaxNameLength, 1035, 21, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1057, 233, true);
                WriteLiteral(">\r\n        </div>\r\n\r\n        <div class=\"m-checkbox-list\">\r\n            <label class=\"m-checkbox\">\r\n                <input id=\"CreateTenant_UseHostDb\" type=\"checkbox\" name=\"UseHostDb\" value=\"true\" checked=\"checked\">\r\n                ");
                EndContext();
                BeginContext(1291, 20, false);
#line 26 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
           Write(L("UseHostDatabase"));

#line default
#line hidden
                EndContext();
                BeginContext(1311, 179, true);
                WriteLiteral("\r\n                <span></span>\r\n            </label>\r\n        </div>\r\n\r\n        <div class=\"form-group no-hint\" style=\"display: none\">\r\n            <label for=\"ConnectionString\">");
                EndContext();
                BeginContext(1491, 29, false);
#line 32 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
                                     Write(L("DatabaseConnectionString"));

#line default
#line hidden
                EndContext();
                BeginContext(1520, 116, true);
                WriteLiteral("</label>\r\n            <input id=\"ConnectionString\" type=\"text\" name=\"ConnectionString\" class=\"form-control\" required");
                EndContext();
                BeginWriteAttribute("maxlength", " maxlength=\"", 1636, "\"", 1681, 1);
#line 33 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
WriteAttributeValue("", 1648, Tenant.MaxConnectionStringLength, 1648, 33, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1682, 98, true);
                WriteLiteral(">\r\n        </div>\r\n\r\n        <div class=\"form-group\">\r\n            <label for=\"AdminEmailAddress\">");
                EndContext();
                BeginContext(1781, 22, false);
#line 37 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
                                      Write(L("AdminEmailAddress"));

#line default
#line hidden
                EndContext();
                BeginContext(1803, 119, true);
                WriteLiteral("</label>\r\n            <input id=\"AdminEmailAddress\" type=\"email\" name=\"AdminEmailAddress\" class=\"form-control\" required");
                EndContext();
                BeginWriteAttribute("maxlength", " maxlength=\"", 1922, "\"", 2003, 1);
#line 38 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
WriteAttributeValue("", 1934, GSoft.AbpZeroTemplate.Authorization.Users.User.MaxEmailAddressLength, 1934, 69, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2004, 251, true);
                WriteLiteral(">\r\n        </div>\r\n\r\n        <div class=\"m-checkbox-list\">\r\n            <label class=\"m-checkbox\">\r\n                <input id=\"CreateTenant_SetRandomPassword\" type=\"checkbox\" name=\"SetRandomPassword\" value=\"true\" checked=\"checked\" />\r\n                ");
                EndContext();
                BeginContext(2256, 22, false);
#line 44 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
           Write(L("SetRandomPassword"));

#line default
#line hidden
                EndContext();
                BeginContext(2278, 211, true);
                WriteLiteral("\r\n                <span></span>\r\n            </label>\r\n        </div>\r\n\r\n        <div class=\"form-group no-hint tenant-admin-password\" style=\"display: none\">\r\n            <label for=\"CreateTenant_AdminPassword\">");
                EndContext();
                BeginContext(2490, 13, false);
#line 50 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
                                               Write(L("Password"));

#line default
#line hidden
                EndContext();
                BeginContext(2503, 118, true);
                WriteLiteral("</label>\r\n            <input id=\"CreateTenant_AdminPassword\" type=\"password\" name=\"AdminPassword\" class=\"form-control\"");
                EndContext();
                BeginWriteAttribute("maxlength", " maxlength=\"", 2621, "\"", 2703, 1);
#line 51 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
WriteAttributeValue("", 2633, GSoft.AbpZeroTemplate.Authorization.Users.User.MaxPlainPasswordLength, 2633, 70, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2704, 163, true);
                WriteLiteral(" autocomplete=\"off\">\r\n        </div>\r\n\r\n        <div class=\"form-group tenant-admin-password\" style=\"display: none\">\r\n            <label for=\"AdminPasswordRepeat\">");
                EndContext();
                BeginContext(2868, 19, false);
#line 55 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
                                        Write(L("PasswordRepeat"));

#line default
#line hidden
                EndContext();
                BeginContext(2887, 117, true);
                WriteLiteral("</label>\r\n            <input id=\"AdminPasswordRepeat\" type=\"password\" name=\"AdminPasswordRepeat\" class=\"form-control\"");
                EndContext();
                BeginWriteAttribute("maxlength", " maxlength=\"", 3004, "\"", 3086, 1);
#line 56 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
WriteAttributeValue("", 3016, GSoft.AbpZeroTemplate.Authorization.Users.User.MaxPlainPasswordLength, 3016, 70, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3087, 155, true);
                WriteLiteral(" equalto=\"#CreateTenant_AdminPassword\" autocomplete=\"off\">\r\n        </div>\r\n\r\n        <div class=\"form-group no-hint\">\r\n            <label for=\"EditionId\">");
                EndContext();
                BeginContext(3243, 12, false);
#line 60 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
                              Write(L("Edition"));

#line default
#line hidden
                EndContext();
                BeginContext(3255, 85, true);
                WriteLiteral("</label>\r\n            <select class=\"form-control\" id=\"EditionId\" name=\"EditionId\">\r\n");
                EndContext();
#line 62 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
                 foreach (var edition in Model.EditionItems)
                {

#line default
#line hidden
                BeginContext(3421, 20, true);
                WriteLiteral("                    ");
                EndContext();
                BeginContext(3441, 90, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "99823a0d778744ecb21f150c67a007ee", async() => {
                    BeginContext(3503, 19, false);
#line 64 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
                                                                            Write(edition.DisplayText);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#line 64 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
                       WriteLiteral(edition.Value);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
#line 64 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
                                                           Write(edition.IsFree);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("data-isfree", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3531, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 65 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
                }

#line default
#line hidden
                BeginContext(3552, 282, true);
                WriteLiteral(@"            </select>
        </div>

        <div class=""m-checkbox-list subscription-component"">
            <label for=""CreateTenant_IsUnlimited"" class=""m-checkbox"">
                <input id=""CreateTenant_IsUnlimited"" type=""checkbox"" name=""IsUnlimited"" />
                ");
                EndContext();
                BeginContext(3835, 30, false);
#line 72 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
           Write(L("UnlimitedTimeSubscription"));

#line default
#line hidden
                EndContext();
                BeginContext(3865, 178, true);
                WriteLiteral("\r\n                <span></span>\r\n            </label>\r\n        </div>\r\n\r\n        <div class=\"form-group subscription-component\">\r\n            <label for=\"SubscriptionEndDateUtc\">");
                EndContext();
                BeginContext(4044, 27, false);
#line 78 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
                                           Write(L("SubscriptionEndDateUtc"));

#line default
#line hidden
                EndContext();
                BeginContext(4071, 453, true);
                WriteLiteral(@"</label>
            <input id=""SubscriptionEndDateUtc"" type=""datetime"" name=""SubscriptionEndDateUtc"" class=""form-control date-time-picker"" required>
        </div>

        <div class=""m-checkbox-list subscription-component"">
            <label for=""CreateTenant_IsInTrialPeriod"" class=""m-checkbox"">
                <input id=""CreateTenant_IsInTrialPeriod"" class=""md-check"" type=""checkbox"" name=""IsInTrialPeriod"" value=""true"" />
                ");
                EndContext();
                BeginContext(4525, 20, false);
#line 85 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
           Write(L("IsInTrialPeriod"));

#line default
#line hidden
                EndContext();
                BeginContext(4545, 380, true);
                WriteLiteral(@"
                <span></span>
            </label>
        </div>

        <div class=""m-checkbox-list"">
            <label for=""CreateTenant_ShouldChangePasswordOnNextLogin"" class=""m-checkbox"">
                <input id=""CreateTenant_ShouldChangePasswordOnNextLogin"" type=""checkbox"" name=""ShouldChangePasswordOnNextLogin"" value=""true"" checked=""checked"">
                ");
                EndContext();
                BeginContext(4926, 36, false);
#line 93 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
           Write(L("ShouldChangePasswordOnNextLogin"));

#line default
#line hidden
                EndContext();
                BeginContext(4962, 287, true);
                WriteLiteral(@"
                <span></span>
            </label>
            <label for=""CreateTenant_SendActivationEmail"" class=""m-checkbox"">
                <input id=""CreateTenant_SendActivationEmail"" type=""checkbox"" name=""SendActivationEmail"" value=""true"" checked=""checked"">
                ");
                EndContext();
                BeginContext(5250, 24, false);
#line 98 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
           Write(L("SendActivationEmail"));

#line default
#line hidden
                EndContext();
                BeginContext(5274, 254, true);
                WriteLiteral("\r\n                <span></span>\r\n            </label>\r\n            <label for=\"CreateTenant_IsActive\" class=\"m-checkbox\">\r\n                <input id=\"CreateTenant_IsActive\" type=\"checkbox\" name=\"IsActive\" value=\"true\" checked=\"checked\">\r\n                ");
                EndContext();
                BeginContext(5529, 11, false);
#line 103 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
           Write(L("Active"));

#line default
#line hidden
                EndContext();
                BeginContext(5540, 75, true);
                WriteLiteral("\r\n                <span></span>\r\n            </label>\r\n        </div>\r\n    ");
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
            BeginContext(5622, 12, true);
            WriteLiteral("\r\n</div>\r\n\r\n");
            EndContext();
            BeginContext(5635, 92, false);
#line 110 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Tenants\_CreateModal.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CreateTenantViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
