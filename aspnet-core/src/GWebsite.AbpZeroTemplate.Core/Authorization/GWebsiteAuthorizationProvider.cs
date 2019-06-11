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

            var merchandise = pages.CreateChildPermission(GWebsitePermissions.Pages_Administration_Merchandise, L("Merchandise"));
            merchandise.CreateChildPermission(GWebsitePermissions.Pages_Administration_Merchandise_Create, L("CreateNewMerchandise"));
            merchandise.CreateChildPermission(GWebsitePermissions.Pages_Administration_Merchandise_Edit, L("EditMerchandise"));
            merchandise.CreateChildPermission(GWebsitePermissions.Pages_Administration_Merchandise_Delete, L("DeleteMerchandise"));

            var merchandiseType = pages.CreateChildPermission(GWebsitePermissions.Pages_Administration_MerchandiseType, L("MerchandiseType"));
            merchandiseType.CreateChildPermission(GWebsitePermissions.Pages_Administration_MerchandiseType_Create, L("CreateNewMerchandiseType"));
            merchandiseType.CreateChildPermission(GWebsitePermissions.Pages_Administration_MerchandiseType_Edit, L("EditMerchandiseType"));
            merchandiseType.CreateChildPermission(GWebsitePermissions.Pages_Administration_MerchandiseType_Delete, L("DeleteMerchandiseType"));

            var vendor = pages.CreateChildPermission(GWebsitePermissions.Pages_Administration_Vendor, L("Vendor"));
            vendor.CreateChildPermission(GWebsitePermissions.Pages_Administration_Vendor_Create, L("CreateNewVendor"));
            vendor.CreateChildPermission(GWebsitePermissions.Pages_Administration_Vendor_Edit, L("EditingVendor"));
            vendor.CreateChildPermission(GWebsitePermissions.Pages_Administration_Vendor_Delete, L("DeletingVendor"));

            var vendortype = pages.CreateChildPermission(GWebsitePermissions.Pages_Administration_VendorType, L("VendorType"));
            vendortype.CreateChildPermission(GWebsitePermissions.Pages_Administration_VendorType_Create, L("CreateNewVendorType"));
            vendortype.CreateChildPermission(GWebsitePermissions.Pages_Administration_VendorType_Edit, L("EditingVendorType"));
            vendortype.CreateChildPermission(GWebsitePermissions.Pages_Administration_VendorType_Delete, L("DeletingVendorType"));

            var contract = pages.CreateChildPermission(GWebsitePermissions.Pages_Administration_Contract, L("Contract"));
            contract.CreateChildPermission(GWebsitePermissions.Pages_Administration_Contract_Create, L("CreateNewContract"));
            contract.CreateChildPermission(GWebsitePermissions.Pages_Administration_Contract_Edit, L("EditingContract"));
            contract.CreateChildPermission(GWebsitePermissions.Pages_Administration_Contract_Delete, L("DeletingContract"));

            var project = pages.CreateChildPermission(GWebsitePermissions.Pages_Administration_Project, L("Project"));
            project.CreateChildPermission(GWebsitePermissions.Pages_Administration_Project_Create, L("CreateNewProject"));
            project.CreateChildPermission(GWebsitePermissions.Pages_Administration_Project_Edit, L("EditingProject"));
            project.CreateChildPermission(GWebsitePermissions.Pages_Administration_Project_Delete, L("DeletingProject"));

            var assignmenttable = pages.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssignmentTable, L("AsssignmentTable"));
            project.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssignmentTable_Create, L("CreateNewAsssignmentTable"));
            project.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssignmentTable_Edit, L("EdittingAsssignmentTable"));
            project.CreateChildPermission(GWebsitePermissions.Pages_Administration_AssignmentTable_Delete, L("DeletingAsssignmentTable"));

            var bid = pages.CreateChildPermission(GWebsitePermissions.Pages_Administration_Bid, L("Bid"));
            bid.CreateChildPermission(GWebsitePermissions.Pages_Administration_Bid_Create, L("CreateNewBid"));
            bid.CreateChildPermission(GWebsitePermissions.Pages_Administration_Bid_Edit, L("EditingBid"));
            bid.CreateChildPermission(GWebsitePermissions.Pages_Administration_Bid_Delete, L("DeletingBid"));

            var bidder = pages.CreateChildPermission(GWebsitePermissions.Pages_Administration_Bidder, L("Bidder"));
            bidder.CreateChildPermission(GWebsitePermissions.Pages_Administration_Bidder_Create, L("CreateNewBidder"));
            bidder.CreateChildPermission(GWebsitePermissions.Pages_Administration_Bidder_Edit, L("EditingBidder"));
            bidder.CreateChildPermission(GWebsitePermissions.Pages_Administration_Bidder_Delete, L("DeletingBidder"));

            var PO = pages.CreateChildPermission(GWebsitePermissions.Pages_Administration_PO, L("PO"));
            PO.CreateChildPermission(GWebsitePermissions.Pages_Administration_PO_Create, L("CreateNewPO"));
            PO.CreateChildPermission(GWebsitePermissions.Pages_Administration_PO_Edit, L("EditingPO"));
            PO.CreateChildPermission(GWebsitePermissions.Pages_Administration_PO_Delete, L("DeletingPO"));

            var Retail = pages.CreateChildPermission(GWebsitePermissions.Pages_Administration_Retail, L("Retail"));
            Retail.CreateChildPermission(GWebsitePermissions.Pages_Administration_Retail_Create, L("CreateNewRetail"));
            Retail.CreateChildPermission(GWebsitePermissions.Pages_Administration_Retail_Edit, L("EditingRetail"));
            Retail.CreateChildPermission(GWebsitePermissions.Pages_Administration_Retail_Delete, L("DeletingRetail"));

            var RetailPayment = pages.CreateChildPermission(GWebsitePermissions.Pages_Administration_RetailPayment, L("RetailPayment"));
            RetailPayment.CreateChildPermission(GWebsitePermissions.Pages_Administration_RetailPayment_Create, L("CreateNewRetailPayment"));
            RetailPayment.CreateChildPermission(GWebsitePermissions.Pages_Administration_RetailPayment_Edit, L("EditingRetailPayment"));
            RetailPayment.CreateChildPermission(GWebsitePermissions.Pages_Administration_RetailPayment_Delete, L("DeletingRetailPayment"));
            var POMerchandise = pages.CreateChildPermission(GWebsitePermissions.Pages_Administration_POMerchandise, L("POMerchandisePO"));
            POMerchandise.CreateChildPermission(GWebsitePermissions.Pages_Administration_POMerchandise_Create, L("CreateNewPOMerchandise"));
            POMerchandise.CreateChildPermission(GWebsitePermissions.Pages_Administration_POMerchandise_Edit, L("EditingPOMerchandise"));
            POMerchandise.CreateChildPermission(GWebsitePermissions.Pages_Administration_POMerchandise_Delete, L("DeletingPOMerchandise"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpZeroTemplateConsts.LocalizationSourceName);
        }
    }
}
