import { CustomerServiceProxy } from "./../../shared/service-proxies/service-proxies";
import { ViewDemoModelModalComponent } from "./demo-model/view-demo-model-modal.component";
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { AppCommonModule } from "@app/shared/common/app-common.module";
import { UtilsModule } from "@shared/utils/utils.module";
import { FileUploadModule } from "ng2-file-upload";
import {
    ModalModule,
    PopoverModule,
    TabsModule,
    TooltipModule
} from "ngx-bootstrap";
import {
    AutoCompleteModule,
    EditorModule,
    FileUploadModule as PrimeNgFileUploadModule,
    InputMaskModule,
    PaginatorModule
} from "primeng/primeng";
import { TableModule } from "primeng/table";
import { GWebsiteRoutingModule } from "./gwebsite-routing.module";

import {
    MenuClientComponent,
    CreateOrEditMenuClientModalComponent
} from "./index";
import { DemoModelComponent } from "./demo-model/demo-model.component";
import { CreateOrEditDemoModelModalComponent } from "./demo-model/create-or-edit-demo-model-modal.component";
import { DemoModelServiceProxy } from "@shared/service-proxies/service-proxies";
import { CustomerComponent } from "./customer/customer.component";
import { AssetComponent } from "./asset/asset.component";
import { ViewAssetModalComponent } from "./asset/view-asset-modal.component";
import { CreateOrEditAssetModalComponent } from "./asset/creat-or-edit-asset-modal.component";
import { ViewCustomerModalComponent } from "./customer/view-customer-modal.component";
import { CreateOrEditCustomerModalComponent } from "./customer/create-or-edit-customer-modal.component";
import { CreateAssetRentModalComponent } from "./assetrent/create-assetrent-modal.component";
import { ViewAssetRentModalComponent } from "./assetrent/view-assetrent-modal.component";
import { AssetRentComponent } from "./assetrent/assetrent.component";
import { CreateDetailAssetRentModalComponent } from "./detailassetrent/create-detailassetrent-modal.component";
import { ViewDetailAssetRentModalComponent } from "./detailassetrent/view-detailassetrent-modal.component";
import { DetailAssetRentComponent } from "./detailassetrent/detailassetrent.component";

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
        MenuClientComponent,
        CreateOrEditMenuClientModalComponent,
        DemoModelComponent,
        CreateOrEditDemoModelModalComponent,
        ViewDemoModelModalComponent,
        CustomerComponent,
        CreateOrEditCustomerModalComponent,
        ViewCustomerModalComponent,
        AssetComponent,
        ViewAssetModalComponent,
        CreateOrEditAssetModalComponent,
        CreateAssetRentModalComponent,
        AssetRentComponent,
        ViewAssetRentModalComponent,
        CreateDetailAssetRentModalComponent,
        DetailAssetRentComponent,
        ViewDetailAssetRentModalComponent
    ],
    providers: [DemoModelServiceProxy]
})
export class GWebsiteModule {}
