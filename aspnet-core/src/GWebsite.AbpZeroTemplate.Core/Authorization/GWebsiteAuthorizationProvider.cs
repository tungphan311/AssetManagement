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

            var productProvider = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_ProductProvider, L("ProductProvider"));
            productProvider.CreateChildPermission(GWebsitePermissions.Pages_Administration_ProductProvider_Create, L("CreatingNewProductProvider"));
            productProvider.CreateChildPermission(GWebsitePermissions.Pages_Administration_ProductProvider_Edit, L("EditingProductProvider"));
            productProvider.CreateChildPermission(GWebsitePermissions.Pages_Administration_ProductProvider_Delete, L("DeletingProductProvider"));


            var provider = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Provider, L("Provider"));
            provider.CreateChildPermission(GWebsitePermissions.Pages_Administration_Provider_Create, L("CreatingNewProvider"));
            provider.CreateChildPermission(GWebsitePermissions.Pages_Administration_Provider_Edit, L("EditingProvider"));
            provider.CreateChildPermission(GWebsitePermissions.Pages_Administration_Provider_Delete, L("DeletingProvider"));

            var project = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Project, L("Project"));
            project.CreateChildPermission(GWebsitePermissions.Pages_Administration_Project_Create, L("CreatingNewProject"));
            project.CreateChildPermission(GWebsitePermissions.Pages_Administration_Project_Edit, L("EditingProject"));
            project.CreateChildPermission(GWebsitePermissions.Pages_Administration_Project_Delete, L("DeletingProject"));

            var bid = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Bid, L("Bid"));
            bid.CreateChildPermission(GWebsitePermissions.Pages_Administration_Bid_Create, L("CreatingNewBid"));
            bid.CreateChildPermission(GWebsitePermissions.Pages_Administration_Bid_Edit, L("EditingBid"));
            bid.CreateChildPermission(GWebsitePermissions.Pages_Administration_Bid_Delete, L("DeletingBid"));

            var bidDetail = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_BidDetail, L("BidDetail"));
            bidDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_BidDetail_Create, L("CreatingNewBidDetail"));
            bidDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_BidDetail_Edit, L("EditingBidDetail"));
            bidDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_BidDetail_Delete, L("DeletingBidDetail"));

            var contract = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Contract, L("Contract"));
            contract.CreateChildPermission(GWebsitePermissions.Pages_Administration_Contract_Create, L("CreatingNewContract"));
            contract.CreateChildPermission(GWebsitePermissions.Pages_Administration_Contract_Edit, L("EditingContract"));
            contract.CreateChildPermission(GWebsitePermissions.Pages_Administration_Contract_Delete, L("DeletingContract"));

            var contractPaymentDetail = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_ContractPaymentDetail, L("ContractPaymentDetail"));
            contractPaymentDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_ContractPaymentDetail_Create, L("CreatingNewContractPaymentDetail"));
            contractPaymentDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_ContractPaymentDetail_Edit, L("EditingContractPaymentDetail"));
            contractPaymentDetail.CreateChildPermission(GWebsitePermissions.Pages_Administration_ContractPaymentDetail_Delete, L("DeletingContractPaymentDetail"));

            var productContract = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_ProductContract, L("ProductContract"));
            productContract.CreateChildPermission(GWebsitePermissions.Pages_Administration_ProductContract_Create, L("CreatingNewProductContract"));
            productContract.CreateChildPermission(GWebsitePermissions.Pages_Administration_ProductContract_Edit, L("EditingProductContract"));
            productContract.CreateChildPermission(GWebsitePermissions.Pages_Administration_ProductContract_Delete, L("DeletingProductContract"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpZeroTemplateConsts.LocalizationSourceName);
        }
    }
}
