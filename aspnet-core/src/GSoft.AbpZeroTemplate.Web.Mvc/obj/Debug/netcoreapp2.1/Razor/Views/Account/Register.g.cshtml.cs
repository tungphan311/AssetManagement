#pragma checksum "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9df290d7f566ab63241859632c3cc5242af493fc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Register), @"mvc.1.0.view", @"/Views/Account/Register.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/Register.cshtml", typeof(AspNetCore.Views_Account_Register))]
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
#line 2 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
using Abp.Extensions;

#line default
#line hidden
#line 3 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
using Abp.Json;

#line default
#line hidden
#line 4 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
using GSoft.AbpZeroTemplate.MultiTenancy;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9df290d7f566ab63241859632c3cc5242af493fc", @"/Views/Account/Register.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47b1e16907496b203fba5485cd552517620edae5", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Register : GSoft.AbpZeroTemplate.Web.Views.AbpZeroTemplateRazorPage<GSoft.AbpZeroTemplate.Web.Models.Account.RegisterViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("abp-src", new global::Microsoft.AspNetCore.Html.HtmlString("/view-resources/Views/Account/Register.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("m-login__form m-form register-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        private global::PaulMiami.AspNetCore.Mvc.Recaptcha.TagHelpers.RecaptchaScriptTagHelper __PaulMiami_AspNetCore_Mvc_Recaptcha_TagHelpers_RecaptchaScriptTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::PaulMiami.AspNetCore.Mvc.Recaptcha.TagHelpers.RecaptchaTagHelper __PaulMiami_AspNetCore_Mvc_Recaptcha_TagHelpers_RecaptchaTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            DefineSection("Scripts", async() => {
                BeginContext(222, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(228, 140, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "518ee46804c84c7e8247235ea2ef10ea", async() => {
                    BeginContext(236, 45, true);
                    WriteLiteral("\r\n        window.passwordComplexitySetting = ");
                    EndContext();
                    BeginContext(282, 70, false);
#line 9 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
                                      Write(Html.Raw(Model.PasswordComplexitySetting.ToJsonString(indented: true)));

#line default
#line hidden
                    EndContext();
                    BeginContext(352, 7, true);
                    WriteLiteral(";\r\n    ");
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
                BeginContext(368, 8, true);
                WriteLiteral("\r\n\r\n    ");
                EndContext();
                BeginContext(376, 95, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d40a4748b6244fb9b4ddd6900e240a68", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __GSoft_AbpZeroTemplate_Web_TagHelpers_AbpZeroTemplateScriptSrcTagHelper = CreateTagHelper<global::GSoft.AbpZeroTemplate.Web.TagHelpers.AbpZeroTemplateScriptSrcTagHelper>();
                __tagHelperExecutionContext.Add(__GSoft_AbpZeroTemplate_Web_TagHelpers_AbpZeroTemplateScriptSrcTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
#line 12 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __GSoft_AbpZeroTemplate_Web_TagHelpers_AbpZeroTemplateScriptSrcTagHelper.AppendVersion = __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion;
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(471, 8, true);
                WriteLiteral("\r\n\r\n    ");
                EndContext();
                BeginContext(479, 20, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("recaptcha-script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9bd020cdef0548f9a2845ae61cddba55", async() => {
                }
                );
                __PaulMiami_AspNetCore_Mvc_Recaptcha_TagHelpers_RecaptchaScriptTagHelper = CreateTagHelper<global::PaulMiami.AspNetCore.Mvc.Recaptcha.TagHelpers.RecaptchaScriptTagHelper>();
                __tagHelperExecutionContext.Add(__PaulMiami_AspNetCore_Mvc_Recaptcha_TagHelpers_RecaptchaScriptTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(499, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(504, 115, true);
            WriteLiteral("\r\n<div class=\"m-login__signin\">\r\n    <div class=\"m-login__head\">\r\n        <h3 class=\"m-login__title\">\r\n            ");
            EndContext();
            BeginContext(620, 11, false);
#line 20 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
       Write(L("SignUp"));

#line default
#line hidden
            EndContext();
            BeginContext(631, 33, true);
            WriteLiteral("\r\n        </h3>\r\n    </div>\r\n    ");
            EndContext();
            BeginContext(664, 3090, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d47be87937a34736aa49542d05f04876", async() => {
                BeginContext(749, 4, true);
                WriteLiteral("\r\n\r\n");
                EndContext();
#line 25 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
         if (@ViewBag.ErrorMessage != null)
        {

#line default
#line hidden
                BeginContext(809, 92, true);
                WriteLiteral("            <div class=\"alert alert-danger\">\r\n                <i class=\"fa fa-warning\"></i> ");
                EndContext();
                BeginContext(902, 20, false);
#line 28 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
                                         Write(ViewBag.ErrorMessage);

#line default
#line hidden
                EndContext();
                BeginContext(922, 22, true);
                WriteLiteral("\r\n            </div>\r\n");
                EndContext();
#line 30 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
        }

#line default
#line hidden
                BeginContext(955, 53, true);
                WriteLiteral("\r\n        <input type=\"hidden\" name=\"IsExternalLogin\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1008, "\"", 1049, 1);
#line 32 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
WriteAttributeValue("", 1016, Model.IsExternalLogin.ToString(), 1016, 33, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1050, 64, true);
                WriteLiteral(" />\r\n        <input type=\"hidden\" name=\"ExternalLoginAuthSchema\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1114, "\"", 1152, 1);
#line 33 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
WriteAttributeValue("", 1122, Model.ExternalLoginAuthSchema, 1122, 30, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1153, 53, true);
                WriteLiteral(" />\r\n        <input type=\"hidden\" name=\"SingleSignOn\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1206, "\"", 1233, 1);
#line 34 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
WriteAttributeValue("", 1214, Model.SingleSignIn, 1214, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1234, 50, true);
                WriteLiteral(" />\r\n        <input type=\"hidden\" name=\"ReturnUrl\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1284, "\"", 1308, 1);
#line 35 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
WriteAttributeValue("", 1292, Model.ReturnUrl, 1292, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1309, 125, true);
                WriteLiteral(" />\r\n\r\n        <div class=\"form-group m-form__group\">\r\n            <input class=\"form-control placeholder-no-fix\" type=\"text\"");
                EndContext();
                BeginWriteAttribute("placeholder", " placeholder=\"", 1434, "\"", 1458, 1);
#line 38 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
WriteAttributeValue("", 1448, L("Name"), 1448, 10, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1459, 21, true);
                WriteLiteral(" name=\"Name\" required");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1480, "\"", 1499, 1);
#line 38 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
WriteAttributeValue("", 1488, Model.Name, 1488, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginWriteAttribute("maxlength", " maxlength=\"", 1500, "\"", 1573, 1);
#line 38 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
WriteAttributeValue("", 1512, GSoft.AbpZeroTemplate.Authorization.Users.User.MaxNameLength, 1512, 61, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1574, 139, true);
                WriteLiteral(" />\r\n        </div>\r\n        <div class=\"form-group m-form__group\">\r\n            <input class=\"form-control placeholder-no-fix\" type=\"text\"");
                EndContext();
                BeginWriteAttribute("placeholder", " placeholder=\"", 1713, "\"", 1740, 1);
#line 41 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
WriteAttributeValue("", 1727, L("Surname"), 1727, 13, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1741, 24, true);
                WriteLiteral(" name=\"Surname\" required");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1765, "\"", 1787, 1);
#line 41 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
WriteAttributeValue("", 1773, Model.Surname, 1773, 14, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginWriteAttribute("maxlength", " maxlength=\"", 1788, "\"", 1864, 1);
#line 41 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
WriteAttributeValue("", 1800, GSoft.AbpZeroTemplate.Authorization.Users.User.MaxSurnameLength, 1800, 64, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1865, 140, true);
                WriteLiteral(" />\r\n        </div>\r\n        <div class=\"form-group m-form__group\">\r\n            <input class=\"form-control placeholder-no-fix\" type=\"email\"");
                EndContext();
                BeginWriteAttribute("placeholder", " placeholder=\"", 2005, "\"", 2037, 1);
#line 44 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
WriteAttributeValue("", 2019, L("EmailAddress"), 2019, 18, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2038, 29, true);
                WriteLiteral(" name=\"EmailAddress\" required");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2067, "\"", 2094, 1);
#line 44 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
WriteAttributeValue("", 2075, Model.EmailAddress, 2075, 19, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginWriteAttribute("maxlength", " maxlength=\"", 2095, "\"", 2176, 1);
#line 44 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
WriteAttributeValue("", 2107, GSoft.AbpZeroTemplate.Authorization.Users.User.MaxEmailAddressLength, 2107, 69, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2177, 31, true);
                WriteLiteral(" />\r\n        </div>\r\n        \r\n");
                EndContext();
#line 47 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
         if (!Model.IsExternalLogin)
        {

#line default
#line hidden
                BeginContext(2257, 155, true);
                WriteLiteral("            <div class=\"form-group m-form__group\">\r\n                <input class=\"form-control placeholder-no-fix input-ltr\" type=\"text\" autocomplete=\"off\"");
                EndContext();
                BeginWriteAttribute("placeholder", " placeholder=\"", 2412, "\"", 2440, 1);
#line 50 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
WriteAttributeValue("", 2426, L("UserName"), 2426, 14, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2441, 16, true);
                WriteLiteral(" name=\"UserName\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2457, "\"", 2480, 1);
#line 50 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
WriteAttributeValue("", 2465, Model.UserName, 2465, 15, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2481, 9, true);
                WriteLiteral(" required");
                EndContext();
                BeginWriteAttribute("maxlength", " maxlength=\"", 2490, "\"", 2567, 1);
#line 50 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
WriteAttributeValue("", 2502, GSoft.AbpZeroTemplate.Authorization.Users.User.MaxUserNameLength, 2502, 65, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2568, 196, true);
                WriteLiteral(" />\r\n            </div>\r\n            <div class=\"form-group m-form__group\">\r\n                <input class=\"form-control placeholder-no-fix\" type=\"password\" autocomplete=\"off\" id=\"RegisterPassword\"");
                EndContext();
                BeginWriteAttribute("placeholder", " placeholder=\"", 2764, "\"", 2792, 1);
#line 53 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
WriteAttributeValue("", 2778, L("Password"), 2778, 14, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2793, 199, true);
                WriteLiteral(" name=\"Password\" required />\r\n            </div>\r\n            <div class=\"form-group m-form__group\">\r\n                <input class=\"form-control placeholder-no-fix\" type=\"password\" autocomplete=\"off\"");
                EndContext();
                BeginWriteAttribute("placeholder", " placeholder=\"", 2992, "\"", 3026, 1);
#line 56 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
WriteAttributeValue("", 3006, L("PasswordRepeat"), 3006, 20, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(3027, 56, true);
                WriteLiteral(" name=\"PasswordRepeat\" required />\r\n            </div>\r\n");
                EndContext();
#line 58 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
        }

#line default
#line hidden
                BeginContext(3094, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 60 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
         if (ViewBag.UseCaptcha)
        {

#line default
#line hidden
                BeginContext(3141, 60, true);
                WriteLiteral("            <p class=\"hint margin-top-20\">\r\n                ");
                EndContext();
                BeginContext(3202, 16, false);
#line 63 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
           Write(L("Captha_Hint"));

#line default
#line hidden
                EndContext();
                BeginContext(3218, 91, true);
                WriteLiteral("\r\n            </p>\r\n            <div class=\"form-group margin-bottom-20\">\r\n                ");
                EndContext();
                BeginContext(3309, 13, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("recaptcha", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "854222842178450faa200f66b9c64104", async() => {
                }
                );
                __PaulMiami_AspNetCore_Mvc_Recaptcha_TagHelpers_RecaptchaTagHelper = CreateTagHelper<global::PaulMiami.AspNetCore.Mvc.Recaptcha.TagHelpers.RecaptchaTagHelper>();
                __tagHelperExecutionContext.Add(__PaulMiami_AspNetCore_Mvc_Recaptcha_TagHelpers_RecaptchaTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3322, 22, true);
                WriteLiteral("\r\n            </div>\r\n");
                EndContext();
#line 68 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
        }

#line default
#line hidden
                BeginContext(3355, 66, true);
                WriteLiteral("        \r\n        <div class=\"m-login__form-action\">\r\n            ");
                EndContext();
                BeginContext(3421, 155, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0cde3ea18994c42aa44237c7744175b", async() => {
                    BeginContext(3443, 110, true);
                    WriteLiteral("<button type=\"button\" id=\"register-back-btn\" class=\"btn btn-outline-primary  m-btn m-btn--pill m-btn--custom\">");
                    EndContext();
                    BeginContext(3554, 9, false);
#line 71 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
                                                                                                                                           Write(L("Back"));

#line default
#line hidden
                    EndContext();
                    BeginContext(3563, 9, true);
                    WriteLiteral("</button>");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(3576, 128, true);
                WriteLiteral("\r\n            <button type=\"submit\" id=\"register-submit-btn\" class=\"btn btn-primary m-btn m-btn--pill m-btn--custom m-btn--air\">");
                EndContext();
                BeginContext(3705, 11, false);
#line 72 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\Account\Register.cshtml"
                                                                                                                         Write(L("Submit"));

#line default
#line hidden
                EndContext();
                BeginContext(3716, 31, true);
                WriteLiteral("</button>\r\n        </div>\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3754, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GSoft.AbpZeroTemplate.Web.Models.Account.RegisterViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
