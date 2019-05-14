import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MerchandiseComponent } from './merchandise/merchandise.component';
import { VendorComponent } from './vendor/vendor.component';
import { VendorTypeComponent } from './vendortype/vendortype.component';
import { MerchandiseTypeComponent } from './merchandise-type/merchandise-type.component';
import { ContractComponent } from './contract/contract.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                children: [
                    { path: 'dashboard', component: DashboardComponent, data: { permission: 'Pages.Tenant.Dashboard' } },
                    { path: 'merchandise', component: MerchandiseComponent, data: { permission: 'Pages.Administration.Merchandise' } },
                    { path: 'merchandise-type', component: MerchandiseTypeComponent, data: { permission: 'Pages.Administration.MerchandiseType' } },
                    { path: 'vendor', component: VendorComponent, data: { permission: 'Pages.Administration.Vendor' } },
                    { path: 'vendortype', component: VendorTypeComponent, data: { permission: 'Pages.Administration.VendorType' } },
                    { 
                        path: 'contract', component: ContractComponent,
                        data: {
                            permission: 'Pages.Administration.Contract'
                        },
                    }
                ]
            }
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class MainRoutingModule { }
