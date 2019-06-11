import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MenuClientComponent } from '@app/gwebsite/menu-client/menu-client.component';
import { DemoModelComponent } from './demo-model/demo-model.component';
import { CustomerComponent } from './customer/customer.component';
import { AssetComponent } from './asset/asset.component'
import { VehicleInfoComponent} from './vehicle-info/vehicleinfo.component';
import { VehicleComponent} from './vehicle.1/vehicle.component';
import { VehicleOperationComponent } from './vehicle-operation/vehicle-operation.component'
import { RoadChargesComponent } from './road-charges/road-charges.component'
import { VehicleRegistryComponent } from './vehicle-registry/vehicle-registry.component';
import { VehicleInsurranceComponent } from './vehicle-insurrance/vehicle-insurrance.component';
import { VehicleMaintenanceComponent } from './vehicle-maintenance/vehicle-maintenance.component'
import { VehicleRepairComponent } from './vehicle-repair/vehicle-repair.component'
import { VehicleModelComponent } from './vehicle-model/vehicle-model.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                children: [
                    {
                        path: 'menu-client', component: MenuClientComponent,
                        data: { permission: 'Pages.Administration.MenuClient' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'demo-model', component: DemoModelComponent,
                        data: { permission: 'Pages.Administration.DemoModel' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'customer', component: CustomerComponent,
                        data: { permission: 'Pages.Administration.Customer' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'asset', component: AssetComponent,
                        data: { permission: 'Pages.Administration.Asset' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'vehicle-model', component: VehicleModelComponent,
                        data: { permission: 'Pages.Administration.VehicleModel' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'vehicle-info', component: VehicleInfoComponent,
                        data: { permission: 'Pages.Administration.Vehicle' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'vehicle-operation', component: VehicleOperationComponent,
                        data: { permission: 'Pages.Administration.VehicleOperation' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'road-charges', component: RoadChargesComponent,
                        data: { permission: 'Pages.Administration.RoadCharges' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'vehicle-registry', component: VehicleRegistryComponent,
                        data: { permission: 'Pages.Administration.VehicleRegistry' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'vehicle-insurrance', component: VehicleInsurranceComponent,
                        data: { permission: 'Pages.Administration.VehicleInsurrance' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'vehicle-maintenance', component: VehicleMaintenanceComponent,
                        data: { permission: 'Pages.Administration.VehicleMaintenance' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'vehicle-repair', component: VehicleRepairComponent,
                        data: { permission: 'Pages.Administration.VehicleRepair' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'vehicle', component: VehicleComponent,
                        data: { permission: 'Pages.Administration.Vehicle' }
                    },
                ]
            }
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class GWebsiteRoutingModule { }
