import { CustomerServiceProxy, ContractPaymentDetailServiceProxy, PurchaseOrderServiceProxy } from './../../shared/service-proxies/service-proxies';
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
import { CustomerComponent } from './customer/customer.component';
import { ViewCustomerModalComponent } from './customer/view-customer-modal.component';
import { CreateOrEditCustomerModalComponent } from './customer/create-or-edit-customer-modal.component';

import { ProductServiceProxy } from '@shared/service-proxies/service-proxies';
import { ProductComponent } from './product/product.component';
import { ViewProductModalComponent } from './product/view-product-modal.component';
import { CreateOrEditProductModalComponent } from './product/create-or-edit-product-modal.component';

import { ProjectServiceProxy } from '@shared/service-proxies/service-proxies';
import { ProjectComponent } from './project/project.component';
import { ViewProjectModalComponent } from './project/view-project-modal.component';
import { CreateOrEditProjectModalComponent } from './project/create-or-edit-project-modal.component';

import { BidServiceProxy } from '@shared/service-proxies/service-proxies';
import { BidComponent } from './bid/bid.component';
import { ViewBidModalComponent } from './bid/view-bid-modal.component';
import { CreateOrEditBidModalComponent } from './bid/create-or-edit-bid-modal.component';

import { ProviderServiceProxy } from '@shared/service-proxies/service-proxies';
import { ProviderComponent } from './provider/provider.component';
import { ViewProviderModalComponent } from './provider/view-provider-modal.component';
import { CreateOrEditProviderModalComponent } from './provider/create-or-edit-provider-modal.component';

import { ContractServiceProxy } from '@shared/service-proxies/service-proxies';
import { ContractComponent } from './contract/contract.component';
import { ViewContractModalComponent } from './contract/view-contract-modal.component';
import { CreateOrEditContractModalComponent } from './contract/create-or-edit-contract-modal.component';

import { ProductContractServiceProxy } from '@shared/service-proxies/service-proxies';
import { ProductContractComponent } from './product-contract/product-contract.component';
import { CreateOrEditProductContractModalComponent } from './product-contract/create-or-edit-product-contract-modal.component';
import {ProductContractItemComponent} from './product-contract/product-contract-item.component'
import {ProductForSelectComponent} from './product/product-for-select.component'

import {ContractPaymentDetailComponent} from './contract-payment-detail/contract-payment-detail.component'
import {ContractPaymentDetailItem} from './contract-payment-detail/contract-payment-detail-item.component'
import {CreateOrEditContractPaymentDetailModalComponent} from './contract-payment-detail/create-or-edit-contract-payment-detail-modal.component'

import {PurchaseOrderComponent} from './purchase-order/purchase-order.component'
import {CreateOrEditPurchaseOrderComponent} from './purchase-order/purchase-order-create-or-edit.component'
import {PurchaseOrderSearchComponent} from './purchase-order/purchase-order-search.component'
import { PurchaseProductDetailComponent } from './purchase-product-detail/purchase-product-detail.component';

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
        CustomerComponent, CreateOrEditCustomerModalComponent, ViewCustomerModalComponent,
        ProductComponent, CreateOrEditProductModalComponent, ViewProductModalComponent, ProductForSelectComponent,
        ProjectComponent, CreateOrEditProjectModalComponent, ViewProjectModalComponent,
        BidComponent, CreateOrEditBidModalComponent, ViewBidModalComponent,

        ProviderComponent, CreateOrEditProviderModalComponent, ViewProviderModalComponent,
        ContractComponent, CreateOrEditContractModalComponent, ViewContractModalComponent,
        ProductContractComponent, CreateOrEditProductContractModalComponent,ProductContractItemComponent,
        ContractPaymentDetailComponent,ContractPaymentDetailItem,CreateOrEditContractPaymentDetailModalComponent,

        PurchaseOrderComponent,CreateOrEditPurchaseOrderComponent,PurchaseOrderSearchComponent,
        
        PurchaseProductDetailComponent

    ],
    providers: [
        DemoModelServiceProxy,
        CustomerServiceProxy,
        ProductServiceProxy,
        ProjectServiceProxy,
        BidServiceProxy,
		ProviderServiceProxy,
        ContractServiceProxy,
        ProductContractServiceProxy,
        ContractPaymentDetailServiceProxy,
        PurchaseOrderServiceProxy
    ]
})
export class GWebsiteModule { }
