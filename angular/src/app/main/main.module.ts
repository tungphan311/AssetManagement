import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppCommonModule } from '@app/shared/common/app-common.module';
import { UtilsModule } from '@shared/utils/utils.module';
import { CountoModule } from 'angular2-counto';
import { EasyPieChartModule } from 'ng2modules-easypiechart';
import { ModalModule, PopoverModule, TabsModule, TooltipModule } from 'ngx-bootstrap';
import { FileUploadModule } from 'ng2-file-upload';
import { AutoCompleteModule, EditorModule, FileUploadModule as PrimeNgFileUploadModule, InputMaskModule, PaginatorModule } from 'primeng/primeng';
import { TableModule } from 'primeng/table';
import { DashboardComponent } from './dashboard/dashboard.component'; 
import { MainRoutingModule } from './main-routing.module';

import { MerchandiseComponent } from './merchandise/merchandise.component';

import { AssignmentTableComponent } from './assignment-table/assignment-table.component';
import { CreateMerchandiseModalComponent } from './merchandise/create-merchandise-modal.component'

import { VendorComponent } from './vendor/vendor.component';
import { ViewVendorModalComponent } from './vendor/view-vendor-modal.component';
import { CreateOrEditVendorModalComponent } from './vendor/create-or-edit-vendor-modal.component';
import { VendorServiceProxy } from './../../shared/service-proxies/service-proxies';

import { VendorTypeComponent } from './vendortype/vendortype.component';
import { ViewVendorTypeModalComponent } from './vendortype/view-vendortype-modal.component';
import { CreateOrEditVendorTypeModalComponent } from './vendortype/create-or-edit-vendortype-modal.component';
import { VendorTypeServiceProxy } from './../../shared/service-proxies/service-proxies';
@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ModalModule,
        TabsModule,
        TooltipModule,
        AppCommonModule,
        UtilsModule,
        MainRoutingModule,
        CountoModule,
        EasyPieChartModule,
        FileUploadModule,
        ModalModule.forRoot(),
        TabsModule.forRoot(),
        TooltipModule.forRoot(),
        PopoverModule.forRoot(),
        TableModule,
        PaginatorModule,
        PrimeNgFileUploadModule,
        AutoCompleteModule,
        EditorModule,
        InputMaskModule
    ],
    declarations: [
        DashboardComponent,
        MerchandiseComponent,
        VendorComponent, CreateOrEditVendorModalComponent, ViewVendorModalComponent,
        AssignmentTableComponent,
        CreateMerchandiseModalComponent,
        VendorTypeComponent, CreateOrEditVendorTypeModalComponent, ViewVendorTypeModalComponent,
    ],
    providers: [
        VendorServiceProxy,
        VendorTypeServiceProxy    
    ]
})
export class MainModule { }
