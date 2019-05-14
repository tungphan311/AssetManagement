using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using GSoft.AbpZeroTemplate;

namespace GWebsite.AbpZeroTemplate.Core.Authorization
{
    /// <summary>
    /// Application's authorization provider.
    /// Defines permissions for the application.
    /// See <see cref="AppPermissions"/> for all permission names.
    /// </summary>
    public class GWebsiteAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

        public GWebsiteAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public GWebsiteAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //COMMON PERMISSIONS (FOR BOTH OF TENANTS AND HOST)

            var pages = context.GetPermissionOrNull(GWebsitePermissions.Pages) ?? context.CreatePermission(GWebsitePermissions.Pages, L("Pages"));
            var gwebsite = pages.CreateChildPermission(GWebsitePermissions.Pages_Administration_GWebsite, L("GWebsite"));

            var menuClient = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_MenuClient, L("MenuClient"));
            menuClient.CreateChildPermission(GWebsitePermissions.Pages_Administration_MenuClient_Create, L("CreatingNewMenuClient"));
            menuClient.CreateChildPermission(GWebsitePermissions.Pages_Administration_MenuClient_Edit, L("EditingMenuClient"));
            menuClient.CreateChildPermission(GWebsitePermissions.Pages_Administration_MenuClient_Delete, L("DeletingMenuClient"));

            var demoModel = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_DemoModel, L("DemoModel"));
            demoModel.CreateChildPermission(GWebsitePermissions.Pages_Administration_DemoModel_Create, L("CreatingNewDemoModel"));
            demoModel.CreateChildPermission(GWebsitePermissions.Pages_Administration_DemoModel_Edit, L("EditingDemoModel"));
            demoModel.CreateChildPermission(GWebsitePermissions.Pages_Administration_DemoModel_Delete, L("DeletingDemoModel"));

            var customer = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer, L("Customer"));
            customer.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer_Create, L("CreatingNewCustomer"));
            customer.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer_Edit, L("EditingCustomer"));
            customer.CreateChildPermission(GWebsitePermissions.Pages_Administration_Customer_Delete, L("DeletingCustomer"));

            var product = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Product, L("Product"));
            product.CreateChildPermission(GWebsitePermissions.Pages_Administration_Product_Create, L("CreatingNewProduct"));
            product.CreateChildPermission(GWebsitePermissions.Pages_Administration_Product_Edit, L("EditingProduct"));
            product.CreateChildPermission(GWebsitePermissions.Pages_Administration_Product_Delete, L("DeletingProduct"));

            var productDetail = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_ProductDetail, L("ProductDetail"));
            productDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_ProductDetail_Create, L("CreatingNewProductDetail"));
            productDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_ProductDetail_Edit, L("EditingProductDetail"));
            productDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_ProductDetail_Delete, L("DeletingProductDetail"));

            var productCategory = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_ProductCategory, L("ProductCategory"));
            productCategory.CreateChildPermission(GWebsitePermissions.Pages_Administration_ProductCategory_Create, L("CreatingNewProductCategory"));
            productCategory.CreateChildPermission(GWebsitePermissions.Pages_Administration_ProductCategory_Edit, L("EditingProductCategory"));
            productCategory.CreateChildPermission(GWebsitePermissions.Pages_Administration_ProductCategory_Delete, L("DeletingProductCategory"));

            var provider = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Provider, L("Provider"));
            provider.CreateChildPermission(GWebsitePermissions.Pages_Administration_Provider_Create, L("CreatingNewProvider"));
            provider.CreateChildPermission(GWebsitePermissions.Pages_Administration_Provider_Edit, L("EditingProvider"));
            provider.CreateChildPermission(GWebsitePermissions.Pages_Administration_Provider_Delete, L("DeletingProvider"));

            var project = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Project, L("Project"));
            project.CreateChildPermission(GWebsitePermissions.Pages_Administration_Project_Create, L("CreatingNewProject"));
            project.CreateChildPermission(GWebsitePermissions.Pages_Administration_Project_Edit, L("EditingProject"));
            project.CreateChildPermission(GWebsitePermissions.Pages_Administration_Project_Delete, L("DeletingProject"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpZeroTemplateConsts.LocalizationSourceName);
        }
    }
}
