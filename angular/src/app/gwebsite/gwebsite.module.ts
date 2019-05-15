import { CustomerServiceProxy } from './../../shared/service-proxies/service-proxies';
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

import { ProductCategoryServiceProxy } from '@shared/service-proxies/service-proxies';
import { ProductCategoryComponent } from './productcategory/productcategory.component';
import { ViewProductCategoryModalComponent } from './productcategory/view-productcategory-modal.component';
import { CreateOrEditProductCategoryModalComponent } from './productcategory/create-or-edit-productcategory-modal.component';

import { ProjectServiceProxy } from '@shared/service-proxies/service-proxies';
import { ProjectComponent } from './project/project.component';
import { ViewProjectModalComponent } from './project/view-project-modal.component';
import { CreateOrEditProjectModalComponent } from './project/create-or-edit-project-modal.component';
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
        ProductComponent, CreateOrEditProductModalComponent, ViewProductModalComponent,
        ProductCategoryComponent, CreateOrEditProductCategoryModalComponent, ViewProductCategoryModalComponent,
        ProjectComponent, CreateOrEditProjectModalComponent, ViewProjectModalComponent
    ],
    providers: [
        DemoModelServiceProxy,
        CustomerServiceProxy,
        ProductServiceProxy,
        ProductCategoryServiceProxy,   
        ProjectServiceProxy
    ]
})
export class GWebsiteModule { }
