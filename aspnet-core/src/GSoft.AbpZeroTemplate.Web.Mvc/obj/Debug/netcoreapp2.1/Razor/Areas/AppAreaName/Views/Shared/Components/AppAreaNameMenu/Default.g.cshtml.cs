#pragma checksum "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Shared\Components\AppAreaNameMenu\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "56a216b318b7651cba34c6b1a5c22b81006338db"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_AppAreaName_Views_Shared_Components_AppAreaNameMenu_Default), @"mvc.1.0.view", @"/Areas/AppAreaName/Views/Shared/Components/AppAreaNameMenu/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/AppAreaName/Views/Shared/Components/AppAreaNameMenu/Default.cshtml", typeof(AspNetCore.Areas_AppAreaName_Views_Shared_Components_AppAreaNameMenu_Default))]
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
#line 1 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Shared\Components\AppAreaNameMenu\Default.cshtml"
using GSoft.AbpZeroTemplate.Web.Areas.AppAreaName.Models.Layout;

#line default
#line hidden
#line 2 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Shared\Components\AppAreaNameMenu\Default.cshtml"
using GSoft.AbpZeroTemplate.Web.Areas.AppAreaName.Views.Shared.Components.AppAreaNameSideBar;

#line default
#line hidden
#line 3 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Shared\Components\AppAreaNameMenu\Default.cshtml"
using GSoft.AbpZeroTemplate.Web.Theme;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56a216b318b7651cba34c6b1a5c22b81006338db", @"/Areas/AppAreaName/Views/Shared/Components/AppAreaNameMenu/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47b1e16907496b203fba5485cd552517620edae5", @"/Areas/AppAreaName/Views/_ViewImports.cshtml")]
    public class Areas_AppAreaName_Views_Shared_Components_AppAreaNameMenu_Default : GSoft.AbpZeroTemplate.Web.Views.AbpZeroTemplateRazorPage<MenuViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(278, 20, true);
            WriteLiteral("<nav id=\"m_ver_menu\"");
            EndContext();
            BeginWriteAttribute("aria-label", "\r\n     aria-label=\"", 298, "\"", 331, 1);
#line 10 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Shared\Components\AppAreaNameMenu\Default.cshtml"
WriteAttributeValue("", 317, L("LeftMenu"), 317, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("class", "\r\n     class=\"", 332, "\"", 723, 6);
            WriteAttributeValue("", 346, "m-aside-menu", 346, 12, true);
            WriteAttributeValue("  \r\n            ", 358, "m-aside-menu--skin-", 374, 35, true);
#line 12 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Shared\Components\AppAreaNameMenu\Default.cshtml"
WriteAttributeValue("", 393, UiThemeCustomizer.LeftAsideAsideSkin, 393, 37, false);

#line default
#line hidden
            WriteAttributeValue(" \r\n            ", 430, "m-aside-menu--submenu-skin-", 445, 42, true);
#line 13 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Shared\Components\AppAreaNameMenu\Default.cshtml"
WriteAttributeValue("", 472, UiThemeCustomizer.LeftAsideDropdownSubmenuSkin == "inherit" ? UiThemeCustomizer.LeftAsideAsideSkin: UiThemeCustomizer.LeftAsideDropdownSubmenuSkin, 472, 149, false);

#line default
#line hidden
#line 13 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Shared\Components\AppAreaNameMenu\Default.cshtml"
WriteAttributeValue(" \r\n            ", 621, UiThemeCustomizer.LeftAsideSubmenuToggle == "dropdown" ? "m-aside-menu--dropdown":"", 636, 87, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(724, 39, true);
            WriteLiteral("\r\n     data-menu-vertical=\"true\"\r\n     ");
            EndContext();
            BeginContext(765, 87, false);
#line 16 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Shared\Components\AppAreaNameMenu\Default.cshtml"
 Write(UiThemeCustomizer.LeftAsideSubmenuToggle == "dropdown" ? "data-menu-dropdown=true" : "");

#line default
#line hidden
            EndContext();
            BeginContext(853, 8, true);
            WriteLiteral(" \r\n     ");
            EndContext();
            BeginContext(863, 98, false);
#line 17 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Shared\Components\AppAreaNameMenu\Default.cshtml"
 Write(UiThemeCustomizer.LeftAsideFixedAside ? "data-menu-scrollable=true" : "data-menu-scrollable=false");

#line default
#line hidden
            EndContext();
            BeginContext(962, 43, true);
            WriteLiteral(" data-menu-dropdown-timeout=\"500\">\r\n    <ul");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1005, "\"", 1120, 3);
            WriteAttributeValue("", 1013, "m-menu__nav", 1013, 11, true);
#line 18 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Shared\Components\AppAreaNameMenu\Default.cshtml"
WriteAttributeValue("  ", 1024, UiThemeCustomizer.LeftAsideDropdownSubmenuArrow ? "m-menu__nav--dropdown-submenu-arrow":"", 1026, 93, false);

#line default
#line hidden
            WriteAttributeValue(" ", 1119, "", 1120, 1, true);
            EndWriteAttribute();
            BeginContext(1121, 25, true);
            WriteLiteral(" \r\n        role=\"menubar\"");
            EndContext();
            BeginWriteAttribute("aria-label", " \r\n        aria-label=\"", 1146, "\"", 1183, 1);
#line 20 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Shared\Components\AppAreaNameMenu\Default.cshtml"
WriteAttributeValue("", 1169, L("LeftMenu"), 1169, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1184, 3, true);
            WriteLiteral(">\r\n");
            EndContext();
#line 21 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Shared\Components\AppAreaNameMenu\Default.cshtml"
         for (var i = 0; i < Model.Menu.Items.Count; i++)
        {
            var menuItem = Model.Menu.Items[i];
            

#line default
#line hidden
            BeginContext(1319, 279, false);
#line 24 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Shared\Components\AppAreaNameMenu\Default.cshtml"
       Write(Html.Partial("Components/AppAreaNameMenu/_UserMenuItem", new UserMenuItemViewModel
            {
                MenuItem = menuItem,
                MenuItemIndex = i,
                RootLevel = true,
                CurrentPageName = Model.CurrentPageName
            }));

#line default
#line hidden
            EndContext();
#line 30 "F:\Dev\AssetManagement\aspnet-core\src\GSoft.AbpZeroTemplate.Web.Mvc\Areas\AppAreaName\Views\Shared\Components\AppAreaNameMenu\Default.cshtml"
              
        }

#line default
#line hidden
            BeginContext(1611, 17, true);
            WriteLiteral("    </ul>\r\n</nav>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IUiThemeCustomizer UiThemeCustomizer { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MenuViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591