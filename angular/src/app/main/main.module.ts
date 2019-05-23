import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppCommonModule } from '@app/shared/common/app-common.module';
import { UtilsModule } from '@shared/utils/utils.module';
import { CountoModule } from 'angular2-counto';
import { EasyPieChartModule } from 'ng2modules-easypiechart';
import { ModalModule, PopoverModule, TabsModule, TooltipModule } from 'ngx-bootstrap';
import { FileUploadModule } from 'ng2-file-upload';
import { AutoCompleteModule, EditorModule, FileUploadModule as PrimeNgFileUploadModule, InputMaskModule, PaginatorModule, DataTableModule } from 'primeng/primeng';
import { TableModule } from 'primeng/table';
import { DashboardComponent } from './dashboard/dashboard.component'; 
import { MainRoutingModule } from './main-routing.module';
import { MerchandiseComponent } from './merchandise/merchandise.component';
import { VendorComponent } from './vendor/vendor.component';
import { ViewVendorModalComponent } from './vendor/view-vendor-modal.component';
import { CreateOrEditVendorModalComponent } from './vendor/create-or-edit-vendor-modal.component';
import { VendorTypeComponent } from './vendortype/vendortype.component';
import { ViewVendorTypeModalComponent } from './vendortype/view-vendortype-modal.component';
import { CreateOrEditVendorTypeModalComponent } from './vendortype/create-or-edit-vendortype-modal.component';
import { CreateOrEditMerchandiseModalComponent } from './merchandise/create-or-edit-merchandise-modal.component';
import { ViewMerchandiseModalComponent } from './merchandise/view-merchandise-modal.component';
import { MerchandiseTypeComponent } from './merchandise-type/merchandise-type.component';
import { CreateOrEditMerchandiseTypeModalComponent } from './merchandise-type/create-or-edit-merchandise-type-modal.component';
import { ViewMerchandiseTypeModalComponent } from './merchandise-type/view-merchandise-type-modal.component';
import { CreateMerchandiseModalComponent } from './vendor/create-merchandise-modal.component';
import { ContractComponent } from './contract/contract.component';
import { CreateOrEditContractModalComponent } from './contract/create-or-edit-contract-modal.component';
import { ViewContractModalComponent } from './contract/view-contract-modal.component';
import { ProjectComponent } from './project/project.component';
import { ViewProjectModalComponent } from './project/view-project-modal.component';
import { CreateOrEditProjectModalComponent } from './project/create-or-edit-project-modal.component';
import { AssignmentTableComponent } from './assignment-table/assignment-table.component';
import { ViewAssignmentTableModalComponent } from './assignment-table/view-assignment-table-modal.component';
import { CreateOrEditAssignmentTableModalComponent } from './assignment-table/create-or-edit-assignment-table-modal.component';
import { AddContractDetailModalComponent } from './contract/add-contract-detail-modal-component';
import { BidComponent } from './bid/bid.component';
import { ViewBidModalComponent } from './bid/view-bid-modal.component';
import { CreateOrEditBidModalComponent } from './bid/create-or-edit-bid-modal.component';

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
        InputMaskModule,
        DataTableModule,
        PaginatorModule
    ],
    declarations: [
        DashboardComponent,
        MerchandiseComponent, CreateOrEditMerchandiseModalComponent, ViewMerchandiseModalComponent,
        MerchandiseTypeComponent, CreateOrEditMerchandiseTypeModalComponent, ViewMerchandiseTypeModalComponent,
        VendorComponent, CreateOrEditVendorModalComponent, ViewVendorModalComponent,
        ContractComponent, CreateOrEditContractModalComponent, ViewContractModalComponent,
        AddContractDetailModalComponent,
        VendorTypeComponent, CreateOrEditVendorTypeModalComponent, ViewVendorTypeModalComponent,
        ProjectComponent, CreateOrEditProjectModalComponent, ViewProjectModalComponent,
        BidComponent, CreateOrEditBidModalComponent, ViewBidModalComponent,
        AssignmentTableComponent, 
        CreateMerchandiseModalComponent,
    ],
    providers: [
        
    ]
})
export class MainModule { }
