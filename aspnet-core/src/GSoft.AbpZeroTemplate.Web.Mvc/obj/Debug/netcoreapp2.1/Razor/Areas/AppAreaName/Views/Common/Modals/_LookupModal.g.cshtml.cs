#pragma checksum "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Common\Modals\_LookupModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e74cc7588a77c7d12600bca02c7b3158ae4b3887"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_AppAreaName_Views_Common_Modals__LookupModal), @"mvc.1.0.view", @"/Areas/AppAreaName/Views/Common/Modals/_LookupModal.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/AppAreaName/Views/Common/Modals/_LookupModal.cshtml", typeof(AspNetCore.Areas_AppAreaName_Views_Common_Modals__LookupModal))]
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
#line 1 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Common\Modals\_LookupModal.cshtml"
using GSoft.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Common.Modals;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e74cc7588a77c7d12600bca02c7b3158ae4b3887", @"/Areas/AppAreaName/Views/Common/Modals/_LookupModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47b1e16907496b203fba5485cd552517620edae5", @"/Areas/AppAreaName/Views/_ViewImports.cshtml")]
    public class Areas_AppAreaName_Views_Common_Modals__LookupModal : GSoft.AbpZeroTemplate.Web.Views.AbpZeroTemplateRazorPage<LookupModalViewModel>
    {
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(102, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(105, 135, false);
#line 4 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Common\Modals\_LookupModal.cshtml"
Write(Html.Partial("~/Areas/AppAreaName/Views/Common/Modals/_ModalHeader.cshtml", new ModalHeaderViewModel(Model.Title ?? L("SelectAnItem"))));

#line default
#line hidden
            EndContext();
            BeginContext(240, 34, true);
            WriteLiteral("\r\n\r\n<div class=\"modal-body\">\r\n    ");
            EndContext();
            BeginContext(274, 417, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "36bd9d6d436f4d61b5f2bc6eae91c080", async() => {
                BeginContext(280, 112, true);
                WriteLiteral("\r\n        <div class=\"input-group margin-bottom-10\">\r\n            <input class=\"form-control lookup-filter-text\"");
                EndContext();
                BeginWriteAttribute("placeholder", " placeholder=\"", 392, "\"", 430, 1);
#line 9 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Common\Modals\_LookupModal.cshtml"
WriteAttributeValue("", 406, L("SearchWithThreeDot"), 406, 24, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(431, 170, true);
                WriteLiteral(" type=\"text\">\r\n            <span class=\"input-group-btn\">\r\n                <button class=\"btn btn-primary lookup-filter-button\" type=\"submit\"><i class=\"flaticon-search-1\"");
                EndContext();
                BeginWriteAttribute("aria-label", " aria-label=\"", 601, "\"", 626, 1);
#line 11 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Common\Modals\_LookupModal.cshtml"
WriteAttributeValue("", 614, L("Search"), 614, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(627, 57, true);
                WriteLiteral("></i></button>\r\n            </span>\r\n        </div>\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(691, 171, true);
            WriteLiteral("\r\n    \r\n    <table class=\"lookup-modal-table display table table-striped table-bordered table-hover dt-responsive nowrap\">\r\n        <thead>\r\n        <tr>\r\n            <th>");
            EndContext();
            BeginContext(863, 11, false);
#line 19 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Common\Modals\_LookupModal.cshtml"
           Write(L("Select"));

#line default
#line hidden
            EndContext();
            BeginContext(874, 23, true);
            WriteLiteral("</th>\r\n            <th>");
            EndContext();
            BeginContext(898, 9, false);
#line 20 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Common\Modals\_LookupModal.cshtml"
           Write(L("Name"));

#line default
#line hidden
            EndContext();
            BeginContext(907, 172, true);
            WriteLiteral("</th>\r\n        </tr>\r\n        </thead>\r\n    </table>\r\n</div>\r\n\r\n<div class=\"modal-footer\">\r\n    <button type=\"button\" class=\"btn default close-button\" data-dismiss=\"modal\">");
            EndContext();
            BeginContext(1080, 11, false);
#line 27 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Common\Modals\_LookupModal.cshtml"
                                                                           Write(L("Cancel"));

#line default
#line hidden
            EndContext();
            BeginContext(1091, 17, true);
            WriteLiteral("</button>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LookupModalViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591