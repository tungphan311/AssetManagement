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

            var vehicle = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Vehicle, L("Vehicle"));
            vehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_Vehicle_Create, L("CreatingNewVehicle"));
            vehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_Vehicle_Edit, L("EditingVehicle"));
            vehicle.CreateChildPermission(GWebsitePermissions.Pages_Administration_Vehicle_Delete, L("DeletingVehicle"));

            var asset = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset, L("Asset"));
            asset.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset_Create, L("CreatingNewAsset"));
            asset.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset_Edit, L("EditingAsset"));
            asset.CreateChildPermission(GWebsitePermissions.Pages_Administration_Asset_Delete, L("DeletingAsset"));

            var attachedDevice = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_AttachedDevice, L("AttachedDevice"));
            attachedDevice.CreateChildPermission(GWebsitePermissions.Pages_Administration_AttachedDevice_Create, L("CreatingNewAttachedDevice"));
            attachedDevice.CreateChildPermission(GWebsitePermissions.Pages_Administration_AttachedDevice_Edit, L("EditingAttachedDevice"));
            attachedDevice.CreateChildPermission(GWebsitePermissions.Pages_Administration_AttachedDevice_Delete, L("DeletingAttachedDevice"));

            var vehicleOperation = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_VehicleOperation, L("VehicleOperation"));
            vehicleOperation.CreateChildPermission(GWebsitePermissions.Pages_Administration_VehicleOperation_Create, L("CreatingNewVehicleOperation"));
            vehicleOperation.CreateChildPermission(GWebsitePermissions.Pages_Administration_VehicleOperation_Edit, L("EditingVehicleOperation"));
            vehicleOperation.CreateChildPermission(GWebsitePermissions.Pages_Administration_VehicleOperation_Delete, L("DeletingVehicleOperation"));

            var roadCharges = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_RoadCharges, L("RoadCharges"));
            roadCharges.CreateChildPermission(GWebsitePermissions.Pages_Administration_RoadCharges_Create, L("CreatingNewRoadCharges"));
            roadCharges.CreateChildPermission(GWebsitePermissions.Pages_Administration_RoadCharges_Edit, L("EditingRoadCharges"));
            roadCharges.CreateChildPermission(GWebsitePermissions.Pages_Administration_RoadCharges_Delete, L("DeletingRoadCharges"));

            var vehicleRegistry = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_VehicleRegistry, L("VehicleRegistry"));
            vehicleRegistry.CreateChildPermission(GWebsitePermissions.Pages_Administration_VehicleRegistry_Create, L("CreatingNewVehicleRegistry"));
            vehicleRegistry.CreateChildPermission(GWebsitePermissions.Pages_Administration_VehicleRegistry_Edit, L("EditingVehicleRegistry"));
            vehicleRegistry.CreateChildPermission(GWebsitePermissions.Pages_Administration_VehicleRegistry_Delete, L("DeletingVehicleRegistry"));

            var vehicleInsurrance = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_VehicleInsurrance, L("VehicleInsurrance"));
            vehicleInsurrance.CreateChildPermission(GWebsitePermissions.Pages_Administration_VehicleInsurrance_Create, L("CreatingNewVehicleInsurrance"));
            vehicleInsurrance.CreateChildPermission(GWebsitePermissions.Pages_Administration_VehicleInsurrance_Edit, L("EditingVehicleInsurrance"));
            vehicleInsurrance.CreateChildPermission(GWebsitePermissions.Pages_Administration_VehicleInsurrance_Delete, L("DeletingVehicleInsurrance"));

            var vehicleMaintenance = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_VehicleMaintenance, L("VehicleMaintenance"));
            vehicleMaintenance.CreateChildPermission(GWebsitePermissions.Pages_Administration_VehicleMaintenance_Create, L("CreatingNewVehicleMaintenance"));
            vehicleMaintenance.CreateChildPermission(GWebsitePermissions.Pages_Administration_VehicleMaintenance_Edit, L("EditingVehicleMaintenance"));
            vehicleMaintenance.CreateChildPermission(GWebsitePermissions.Pages_Administration_VehicleMaintenance_Delete, L("DeletingVehicleMaintenance"));

            var vehicleRepair = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_VehicleRepair, L("VehicleRepair"));
            vehicleRepair.CreateChildPermission(GWebsitePermissions.Pages_Administration_VehicleRepair_Create, L("CreatingNewVehicleRepair"));
            vehicleRepair.CreateChildPermission(GWebsitePermissions.Pages_Administration_VehicleRepair_Edit, L("EditingVehicleRepair"));
            vehicleRepair.CreateChildPermission(GWebsitePermissions.Pages_Administration_VehicleRepair_Delete, L("DeletingVehicleRepair"));

            var vehicleModel = gwebsite.CreateChildPermission(GWebsitePermissions.Pages_Administration_VehicleModel, L("VehicleModel"));
            vehicleModel.CreateChildPermission(GWebsitePermissions.Pages_Administration_VehicleModel_Create, L("CreatingNewVehicleModel"));
            vehicleModel.CreateChildPermission(GWebsitePermissions.Pages_Administration_VehicleModel_Edit, L("EditingVehicleModel"));
            vehicleModel.CreateChildPermission(GWebsitePermissions.Pages_Administration_VehicleModel_Delete, L("DeletingVehicleModel"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, AbpZeroTemplateConsts.LocalizationSourceName);
        }
    }
}
