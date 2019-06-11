import { PermissionCheckerService } from "@abp/auth/permission-checker.service";
import { Injectable } from "@angular/core";
import { AppMenu } from "./app-menu";
import { AppMenuItem } from "./app-menu-item";

@Injectable()
export class AppNavigationService {
    constructor(private _permissionService: PermissionCheckerService) {}

    getMenu(): AppMenu {
        return new AppMenu('MainMenu', 'MainMenu', [
            new AppMenuItem('Dashboard', 'Pages.Administration.Host.Dashboard', 'flaticon-line-graph', '/app/admin/hostDashboard'),
            new AppMenuItem('Dashboard', 'Pages.Tenant.Dashboard', 'flaticon-line-graph', '/app/main/dashboard'),
            new AppMenuItem('Tenants', 'Pages.Tenants', 'flaticon-list-3', '/app/admin/tenants'),
            new AppMenuItem('Editions', 'Pages.Editions', 'flaticon-app', '/app/admin/editions'),
            new AppMenuItem('Administration', '', 'flaticon-interface-8', '', [
                new AppMenuItem('MenuClient', 'Pages.Administration.MenuClient', 'flaticon-menu-1', '/app/gwebsite/menu-client'),
                new AppMenuItem('DemoModel', 'Pages.Administration.DemoModel', 'flaticon-menu-1', '/app/gwebsite/demo-model'),
                new AppMenuItem('Customer', 'Pages.Administration.Customer', 'flaticon-menu-1', '/app/gwebsite/customer'),
                new AppMenuItem("Asset", "Pages.Administration.Asset", "flaticon-menu-1", "/app/gwebsite/asset"),
                new AppMenuItem("AssetRent", "Pages.Administration.AssetRent", "flaticon-menu-1", "/app/gwebsite/assetrent"),
                new AppMenuItem("DetailAssetRent", "Pages.Administration.DetailAssetRent", "flaticon-menu-1", "/app/gwebsite/detailassetrent"),
                new AppMenuItem('QLTS từ khi khai sinh đến thanh lý', 'Pages.Administration.Asset5', 'flaticon-menu-1', '/app/gwebsite/asset5'),
                new AppMenuItem('Vehicle', 'Pages.Administration.Vehicle', 'flaticon-menu-1', '/app/gwebsite/vehicle')
            ]),
            new AppMenuItem("Systems", "", "flaticon-layers", "", [
                new AppMenuItem(
                    "OrganizationUnits",
                    "Pages.Administration.OrganizationUnits",
                    "flaticon-map",
                    "/app/admin/organization-units"
                ),
                new AppMenuItem(
                    "Roles",
                    "Pages.Administration.Roles",
                    "flaticon-suitcase",
                    "/app/admin/roles"
                ),
                new AppMenuItem(
                    "Users",
                    "Pages.Administration.Users",
                    "flaticon-users",
                    "/app/admin/users"
                ),
                new AppMenuItem(
                    "Languages",
                    "Pages.Administration.Languages",
                    "flaticon-tabs",
                    "/app/admin/languages"
                ),
                new AppMenuItem(
                    "AuditLogs",
                    "Pages.Administration.AuditLogs",
                    "flaticon-folder-1",
                    "/app/admin/auditLogs"
                ),
                new AppMenuItem(
                    "Maintenance",
                    "Pages.Administration.Host.Maintenance",
                    "flaticon-lock",
                    "/app/admin/maintenance"
                ),
                new AppMenuItem(
                    "Subscription",
                    "Pages.Administration.Tenant.SubscriptionManagement",
                    "flaticon-refresh",
                    "/app/admin/subscription-management"
                ),
                new AppMenuItem(
                    "VisualSettings",
                    "Pages.Administration.UiCustomization",
                    "flaticon-medical",
                    "/app/admin/ui-customization"
                ),
                new AppMenuItem(
                    "Settings",
                    "Pages.Administration.Host.Settings",
                    "flaticon-settings",
                    "/app/admin/hostSettings"
                ),
                new AppMenuItem(
                    "Settings",
                    "Pages.Administration.Tenant.Settings",
                    "flaticon-settings",
                    "/app/admin/tenantSettings"
                )
            ]),
            new AppMenuItem('DemoUiComponents', 'Pages.DemoUiComponents', 'flaticon-shapes', '/app/admin/demo-ui-components'),
            new AppMenuItem('Purchasing', '', 'flaticon-cart', '', [
                new AppMenuItem('Vendor', null, 'flaticon-users', '/app/main/vendor'),
                new AppMenuItem('VendorType', null, 'flaticon-users', '/app/main/vendortype'),
                new AppMenuItem('Merchandise', 'Pages.Administration.Merchandise', 'flaticon-business', '/app/main/merchandise'),
                new AppMenuItem('MerchandiseType', 'Pages.Administration.MerchandiseType', 'flaticon-business', '/app/main/merchandise-type'),
                new AppMenuItem('Contract', 'Pages.Administration.Contract', 'flaticon-file-1', '/app/main/contract'),
                new AppMenuItem('Retail', null, 'flaticon-list-1', '/app/main/retail'), 
                new AppMenuItem('AssignmentTable', 'Pages.Administration.AssignmentTable', 'flaticon2-contract', '/app/main/assignment-table'),
                new AppMenuItem('Project', 'Pages.Administration.Project', 'flaticon-folder', '/app/main/project'),
                new AppMenuItem('Bid', 'Pages.Administration.Bid', 'flaticon-folder', '/app/main/bid'),
                new AppMenuItem('PO', 'Pages.Administration.PO', 'flaticon-business', '/app/main/PO')
            ]),
            new AppMenuItem("DemoUiComponents", "Pages.DemoUiComponents", "flaticon-shapes", "/app/admin/demo-ui-components")
        ]);
    }

    checkChildMenuItemPermission(menuItem): boolean {
        for (let i = 0; i < menuItem.items.length; i++) {
            let subMenuItem = menuItem.items[i];

            if (
                subMenuItem.permissionName &&
                this._permissionService.isGranted(subMenuItem.permissionName)
            ) {
                return true;
            }

            if (subMenuItem.items && subMenuItem.items.length) {
                return this.checkChildMenuItemPermission(subMenuItem);
            } else if (!subMenuItem.permissionName) {
                return true;
            }
        }

        return false;
    }
}
