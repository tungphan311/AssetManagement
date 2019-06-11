import { CustomerServiceProxy, VehicleServiceProxy, AssetServiceProxy, AttachedDeviceServiceProxy, VehicleOperationServiceProxy, RoadChargesServiceProxy, VehicleRegistryServiceProxy, VehicleInsurranceServiceProxy, VehicleMaintenanceServiceProxy, VehicleRepairServiceProxy, VehicleModelServiceProxy } from './../../shared/service-proxies/service-proxies';
import { ViewDemoModelModalComponent } from './demo-model/view-demo-model-modal.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AppCommonModule } from '@app/shared/common/app-common.module';
import { UtilsModule } from '@shared/utils/utils.module';
import { FileUploadModule } from 'ng2-file-upload';
import { ModalModule, PopoverModule, TabsModule, TooltipModule } from 'ngx-bootstrap';
import { AutoCompleteModule, EditorModule, FileUploadModule as PrimeNgFileUploadModule, InputMaskModule, PaginatorModule } from 'primeng/primeng';
import { TableModule } from 'primeng/table';
import { GWebsiteRoutingModule } from './gwebsite-routing.module';

import { MenuClientComponent, CreateOrEditMenuClientModalComponent } from './index';
import { DemoModelComponent } from './demo-model/demo-model.component';
import { CreateOrEditDemoModelModalComponent } from './demo-model/create-or-edit-demo-model-modal.component';
import { DemoModelServiceProxy } from '@shared/service-proxies/service-proxies';

import { AssetComponent } from './asset/asset.component';
import { ViewAssetModalComponent } from './asset/view-asset-modal.component';
import { CreateOrEditAssetModalComponent } from './asset/create-or-edit-asset-modal.component';

import { CreateOrEditAttachedDeviceModalComponent } from './vehicle-info/create-or-edit-attacheddevice-modal.component';

import { CustomerComponent } from './customer/customer.component';
import { ViewCustomerModalComponent } from './customer/view-customer-modal.component';
import { CreateOrEditCustomerModalComponent } from './customer/create-or-edit-customer-modal.component';

import { VehicleInfoComponent } from './vehicle-info/vehicleinfo.component';
import { SelectAssetIdModalComponent } from './select-asset/select-assetid-modal.component';

import { VehicleComponent } from './vehicle.1/vehicle.component';
import { ViewVehicleModalComponent } from './vehicle.1/view-vehicle-modal.component';
import { CreateOrEditVehicleModalComponent} from './vehicle.1/create-or-edit-vehicle-modal.component';

import { VehicleOperationComponent } from './vehicle-operation/vehicle-operation.component';
import { SelectVehicleModalComponent } from './select-vehicle/select-vehicle-modal.component';

import { RoadChargesComponent } from './road-charges/road-charges.component';

import { VehicleRegistryComponent } from './vehicle-registry/vehicle-registry.component';

import { VehicleInsurranceComponent } from './vehicle-insurrance/vehicle-insurrance.component'

import { VehicleMaintenanceComponent } from './vehicle-maintenance/vehicle-maintenance.component'

import { VehicleRepairComponent } from './vehicle-repair/vehicle-repair.component'
import { CreateOrEditVehicleRepairModalComponent } from './vehicle-repair/create-or-edit-repair-update-modal.component'

import { CreateOrEditVehicleModelModalComponent } from './vehicle-model/create-or-edit-vehicle-model-modal.component'
import { VehicleModelComponent } from './vehicle-model/vehicle-model.component'
import { ViewVehicleModelModalComponent } from './vehicle-model/view-vehicle-model-modal.component'

import { SelectVehicleModelModalComponent } from './select-vehicle-model/select-vehicle-model-modal.component';


@NgModule({
    imports: [
        FormsModule,
        CommonModule,
        FileUploadModule,
        ModalModule.forRoot(),
        TabsModule.forRoot(),
        TooltipModule.forRoot(),
        PopoverModule.forRoot(),
        GWebsiteRoutingModule,
        UtilsModule,
        AppCommonModule,
        TableModule,
        PaginatorModule,
        PrimeNgFileUploadModule,
        AutoCompleteModule,
        EditorModule,
        InputMaskModule
    ],
    declarations: [
        MenuClientComponent, CreateOrEditMenuClientModalComponent,
        DemoModelComponent, CreateOrEditDemoModelModalComponent, ViewDemoModelModalComponent,
        AssetComponent, CreateOrEditAssetModalComponent, ViewAssetModalComponent,
        CreateOrEditAttachedDeviceModalComponent, 
        CustomerComponent, CreateOrEditCustomerModalComponent, ViewCustomerModalComponent,
        VehicleInfoComponent, SelectAssetIdModalComponent,
        VehicleComponent, CreateOrEditVehicleModalComponent, ViewVehicleModalComponent,
        VehicleOperationComponent, SelectVehicleModalComponent,
        RoadChargesComponent,
        VehicleRegistryComponent,
        VehicleInsurranceComponent,
        VehicleMaintenanceComponent,
        VehicleRepairComponent, CreateOrEditVehicleRepairModalComponent,
        CreateOrEditVehicleModelModalComponent, VehicleModelComponent, ViewVehicleModelModalComponent,
        SelectVehicleModelModalComponent,

    ],
    providers: [
        DemoModelServiceProxy,
        CustomerServiceProxy,
        VehicleServiceProxy,
        AssetServiceProxy,
        AttachedDeviceServiceProxy,
        VehicleOperationServiceProxy,
        RoadChargesServiceProxy,
        VehicleRegistryServiceProxy,
        VehicleInsurranceServiceProxy,
        VehicleMaintenanceServiceProxy,
        VehicleRepairServiceProxy,
        VehicleModelServiceProxy,
    ]
})
export class GWebsiteModule { }
