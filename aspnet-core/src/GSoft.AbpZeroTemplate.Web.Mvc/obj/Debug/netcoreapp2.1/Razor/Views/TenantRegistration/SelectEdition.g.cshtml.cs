#pragma checksum "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9fd05069dabc66a8d62ebe089db9f02e253ad999"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TenantRegistration_SelectEdition), @"mvc.1.0.view", @"/Views/TenantRegistration/SelectEdition.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/TenantRegistration/SelectEdition.cshtml", typeof(AspNetCore.Views_TenantRegistration_SelectEdition))]
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
#line 1 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
using Abp.UI.Inputs;

#line default
#line hidden
#line 2 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
using GSoft.AbpZeroTemplate.Editions;

#line default
#line hidden
#line 3 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
using GSoft.AbpZeroTemplate.MultiTenancy.Payments.Dto;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fd05069dabc66a8d62ebe089db9f02e253ad999", @"/Views/TenantRegistration/SelectEdition.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47b1e16907496b203fba5485cd552517620edae5", @"/Views/_ViewImports.cshtml")]
    public class Views_TenantRegistration_SelectEdition : GSoft.AbpZeroTemplate.Web.Views.AbpZeroTemplateRazorPage<GSoft.AbpZeroTemplate.Web.Models.TenantRegistration.EditionsSelectViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", "~/view-resources/Views/TenantRegistration/SelectEdition.css", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::GSoft.AbpZeroTemplate.Web.TagHelpers.AbpZeroTemplateLinkHrefTagHelper __GSoft_AbpZeroTemplate_Web_TagHelpers_AbpZeroTemplateLinkHrefTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 5 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
  
    ViewBag.DisableTenantChange = true;
    Layout = "_Layout";
    var isSetted = false;
    var editionIcons = new string[] { "flaticon-open-box", "flaticon-rocket", "flaticon-gift", "flaticon-confetti", "flaticon-puzzle", "flaticon-app", "flaticon-coins", "flaticon-piggy-bank", "flaticon-bag", "flaticon-lifebuoy", "flaticon-technology-1", "flaticon-cogwheel-1", "flaticon-infinity", "flaticon-interface-5", "flaticon-squares-3", "flaticon-interface-6", "flaticon-mark", "flaticon-business", "flaticon-interface-7", "flaticon-list-2", "flaticon-bell", "flaticon-technology", "flaticon-squares-2", "flaticon-notes", "flaticon-profile", "flaticon-layers", "flaticon-interface-4", "flaticon-signs", "flaticon-menu-1", "flaticon-symbol" };

#line default
#line hidden
            DefineSection("Styles", async() => {
                BeginContext(974, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(980, 92, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "60a99aff4fb948c2b0c3ab2b36a678c6", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __GSoft_AbpZeroTemplate_Web_TagHelpers_AbpZeroTemplateLinkHrefTagHelper = CreateTagHelper<global::GSoft.AbpZeroTemplate.Web.TagHelpers.AbpZeroTemplateLinkHrefTagHelper>();
                __tagHelperExecutionContext.Add(__GSoft_AbpZeroTemplate_Web_TagHelpers_AbpZeroTemplateLinkHrefTagHelper);
                __GSoft_AbpZeroTemplate_Web_TagHelpers_AbpZeroTemplateLinkHrefTagHelper.Href = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1072, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(1077, 195, true);
            WriteLiteral("<div class=\"m-pricing-table-1 m-pricing-table-1--fixed\">\r\n    <div class=\"m-portlet\">\r\n        <div class=\"m-portlet__body\">\r\n            <div class=\"m-pricing-table-1__items row row-centered\">\r\n");
            EndContext();
#line 19 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                   var i = 0;

#line default
#line hidden
            BeginContext(1304, 16, true);
            WriteLiteral("                ");
            EndContext();
#line 20 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                 foreach (var editionWithFeatures in Model.EditionsWithFeatures)
                {
                    var edition = editionWithFeatures.Edition;


#line default
#line hidden
            BeginContext(1471, 418, true);
            WriteLiteral(@"                    <div class=""m-pricing-table-1__item col-lg-3 col-centered"">

                        <div class=""m-pricing-table-1__visual"">
                            <div class=""m-pricing-table-1__hexagon1""></div>
                            <div class=""m-pricing-table-1__hexagon2""></div>
                            <span class=""m-pricing-table-1__icon m--font-brand"">
                                <i");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1889, "\"", 1916, 2);
            WriteAttributeValue("", 1897, "fa", 1897, 2, true);
#line 30 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
WriteAttributeValue(" ", 1899, editionIcons[i], 1900, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1917, 171, true);
            WriteLiteral("></i>\r\n                            </span>\r\n                        </div>\r\n\r\n                        <span class=\"m-pricing-table-1__price\">\r\n                            ");
            EndContext();
            BeginContext(2089, 19, false);
#line 35 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                       Write(edition.DisplayName);

#line default
#line hidden
            EndContext();
            BeginContext(2108, 101, true);
            WriteLiteral("\r\n                        </span>\r\n                        <h2 class=\"m-pricing-table-1__subtitle\">\r\n");
            EndContext();
#line 38 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                             if (!edition.AnnualPrice.HasValue && !edition.MonthlyPrice.HasValue)
                            {

                                

#line default
#line hidden
            BeginContext(2380, 9, false);
#line 41 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                                 Write(L("Free"));

#line default
#line hidden
            EndContext();
#line 41 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                                                       

                            }
                            else
                            {
                                

#line default
#line hidden
            BeginContext(2534, 48, true);
            WriteLiteral("<span class=\"m-pricing-table-1__label\">$</span> ");
            EndContext();
            BeginContext(2583, 36, false);
#line 46 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                                                                                 Write(edition.MonthlyPrice?.ToString("N2"));

#line default
#line hidden
            EndContext();
            BeginContext(2619, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(2621, 13, false);
#line 46 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                                                                                                                       Write(L("PerMonth"));

#line default
#line hidden
            EndContext();
            BeginContext(2634, 3, true);
            WriteLiteral(" / ");
            EndContext();
            BeginContext(2644, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(2684, 48, true);
            WriteLiteral("<span class=\"m-pricing-table-1__label\">$</span> ");
            EndContext();
            BeginContext(2733, 35, false);
#line 47 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                                                                                 Write(edition.AnnualPrice?.ToString("N2"));

#line default
#line hidden
            EndContext();
            BeginContext(2768, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(2770, 12, false);
#line 47 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                                                                                                                      Write(L("PerYear"));

#line default
#line hidden
            EndContext();
#line 47 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                                                                                                                                               
                            }

#line default
#line hidden
            BeginContext(2822, 102, true);
            WriteLiteral("                        </h2>\r\n                        <span class=\"m-pricing-table-1__description\">\r\n");
            EndContext();
#line 51 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                             foreach (var feature in Model.AllFeatures)
                            {
                                var featureValue = editionWithFeatures.FeatureValues.FirstOrDefault(f => f.Name == feature.Name);
                                if (feature.InputType.GetType() == typeof(CheckboxInputType))
                                {
                                    if (featureValue.Value == "true")
                                    {

#line default
#line hidden
            BeginContext(3399, 85, true);
            WriteLiteral("                                        <i class=\"la la-check m--font-success\"></i>\r\n");
            EndContext();
#line 59 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
            BeginContext(3604, 83, true);
            WriteLiteral("                                        <i class=\"la la-times m--font-metal\"></i>\r\n");
            EndContext();
#line 63 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                                    }
                                    

#line default
#line hidden
            BeginContext(3768, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(3770, 19, false);
#line 64 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                                      Write(feature.DisplayName);

#line default
#line hidden
            EndContext();
#line 64 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                                                                      
                                }
                                else
                                {

#line default
#line hidden
            BeginContext(3906, 79, true);
            WriteLiteral("                                    <i class=\"la la-check m--font-success\"></i>");
            EndContext();
            BeginContext(3991, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(3993, 19, false);
#line 68 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                                                                                 Write(feature.DisplayName);

#line default
#line hidden
            EndContext();
            BeginContext(4012, 3, true);
            WriteLiteral(" : ");
            EndContext();
            BeginContext(4016, 28, false);
#line 68 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                                                                                                        Write(Html.Raw(featureValue.Value));

#line default
#line hidden
            EndContext();
#line 68 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                                                                                                                                                 
                                }

#line default
#line hidden
            BeginContext(4088, 39, true);
            WriteLiteral("                                <br/>\r\n");
            EndContext();
#line 71 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                            }

#line default
#line hidden
            BeginContext(4158, 95, true);
            WriteLiteral("                        </span>\r\n                        <div class=\"m-pricing-table-1__btn\">\r\n");
            EndContext();
#line 74 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                             if (AbpSession.UserId.HasValue)
                            {
                                if (!isSetted)
                                {
                                    if (edition.Id == Model.TenantEditionId)
                                    {
                                        isSetted = true;
                                    }


#line default
#line hidden
            BeginContext(4645, 228, true);
            WriteLiteral("                                    <a class=\"btn btn-warning m-btn m-btn--custom m-btn--pill m-btn--wide m-btn--uppercase m-btn--bolder m-btn--sm disabled\" href=\"#\" disabled=\"disabled\">\r\n                                        ");
            EndContext();
            BeginContext(4874, 12, false);
#line 84 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                                   Write(L("Upgrade"));

#line default
#line hidden
            EndContext();
            BeginContext(4886, 44, true);
            WriteLiteral("\r\n                                    </a>\r\n");
            EndContext();
#line 86 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                                }
                                else
                                {

#line default
#line hidden
            BeginContext(5038, 147, true);
            WriteLiteral("                                    <a class=\"btn btn-warning m-btn m-btn--custom m-btn--pill m-btn--wide m-btn--uppercase m-btn--bolder m-btn--sm\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 5185, "\"", 5311, 1);
#line 89 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
WriteAttributeValue("", 5192, Url.Action("Upgrade", "Payment", new {upgradeEditionId = edition.Id, editionPaymentType = EditionPaymentType.Upgrade}), 5192, 119, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5312, 43, true);
            WriteLiteral(">\r\n                                        ");
            EndContext();
            BeginContext(5356, 12, false);
#line 90 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                                   Write(L("Upgrade"));

#line default
#line hidden
            EndContext();
            BeginContext(5368, 44, true);
            WriteLiteral("\r\n                                    </a>\r\n");
            EndContext();
#line 92 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                                }
                            }
                            else
                            {
                                if (!edition.MonthlyPrice.HasValue && !edition.AnnualPrice.HasValue)
                                {

#line default
#line hidden
            BeginContext(5680, 147, true);
            WriteLiteral("                                    <a class=\"btn btn-success m-btn m-btn--custom m-btn--pill m-btn--wide m-btn--uppercase m-btn--bolder m-btn--sm\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 5827, "\"", 5961, 1);
#line 98 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
WriteAttributeValue("", 5834, Url.Action("Register", "TenantRegistration", new {editionId = edition.Id, subscriptionStartType = SubscriptionStartType.Free}), 5834, 127, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5962, 43, true);
            WriteLiteral(">\r\n                                        ");
            EndContext();
            BeginContext(6006, 10, false);
#line 99 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                                   Write(L("Start"));

#line default
#line hidden
            EndContext();
            BeginContext(6016, 44, true);
            WriteLiteral("\r\n                                    </a>\r\n");
            EndContext();
#line 101 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                                }
                                else
                                {
                                    if (edition.TrialDayCount.HasValue)
                                    {

#line default
#line hidden
            BeginContext(6280, 151, true);
            WriteLiteral("                                        <a class=\"btn btn-warning m-btn m-btn--custom m-btn--pill m-btn--wide m-btn--uppercase m-btn--bolder m-btn--sm\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 6431, "\"", 6566, 1);
#line 106 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
WriteAttributeValue("", 6438, Url.Action("Register", "TenantRegistration", new {editionId = edition.Id, subscriptionStartType = SubscriptionStartType.Trial}), 6438, 128, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6567, 47, true);
            WriteLiteral(">\r\n                                            ");
            EndContext();
            BeginContext(6615, 14, false);
#line 107 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                                       Write(L("FreeTrial"));

#line default
#line hidden
            EndContext();
            BeginContext(6629, 48, true);
            WriteLiteral("\r\n                                        </a>\r\n");
            EndContext();
#line 109 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                                    }


#line default
#line hidden
            BeginContext(6718, 147, true);
            WriteLiteral("                                    <a class=\"btn btn-primary m-btn m-btn--custom m-btn--pill m-btn--wide m-btn--uppercase m-btn--bolder m-btn--sm\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 6865, "\"", 7046, 1);
#line 111 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
WriteAttributeValue("", 6872, Url.Action("Buy", "Payment", new {editionId = edition.Id, editionPaymentType = EditionPaymentType.NewRegistration, subscriptionStartType = (int) SubscriptionStartType.Paid}), 6872, 174, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(7047, 43, true);
            WriteLiteral(">\r\n                                        ");
            EndContext();
            BeginContext(7091, 11, false);
#line 112 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                                   Write(L("BuyNow"));

#line default
#line hidden
            EndContext();
            BeginContext(7102, 44, true);
            WriteLiteral("\r\n                                    </a>\r\n");
            EndContext();
#line 114 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"
                                }
                            }

#line default
#line hidden
            BeginContext(7212, 60, true);
            WriteLiteral("                        </div>\r\n                    </div>\r\n");
            EndContext();
#line 118 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Views\TenantRegistration\SelectEdition.cshtml"

                    i++;
                }

#line default
#line hidden
            BeginContext(7319, 54, true);
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GSoft.AbpZeroTemplate.Web.Models.TenantRegistration.EditionsSelectViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
