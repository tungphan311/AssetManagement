import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MerchandiseComponent } from './merchandise/merchandise.component';
import { VendorComponent } from './vendor/vendor.component';
import { VendorTypeComponent } from './vendortype/vendortype.component';
import { MerchandiseTypeComponent } from './merchandise-type/merchandise-type.component';
import { ContractComponent } from './contract/contract.component';
import { AssignmentTableComponent } from './assignment-table/assignment-table.component';
import { ProjectComponent } from './project/project.component';
import { BidComponent } from './bid/bid.component';
import { POCOmponent } from './po/po.component';
import { FileUploadComponent } from './contract/file-upload.component';
import { RetailComponent } from './retail/retail.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                children: [
                    { 
                        path: 'dashboard', component: DashboardComponent, 
                        data: { 
                            permission: 'Pages.Tenant.Dashboard' 
                        } 
                    },
                    { 
                        path: 'merchandise', component: MerchandiseComponent, 
                        data: { 
                            permission: 'Pages.Administration.Merchandise' 
                        } 
                    },
                    { 
                        path: 'merchandise-type', component: MerchandiseTypeComponent, 
                        data: { 
                            permission: 'Pages.Administration.MerchandiseType' 
                        } 
                    },
                    { 
                        path: 'vendor', component: VendorComponent, 
                        data: { 
                            permission: 'Pages.Administration.Vendor' 
                        } 
                    },
                    { 
                        path: 'vendortype', component: VendorTypeComponent, 
                        data: { 
                            permission: 'Pages.Administration.VendorType' 
                        } 
                    },
                    { 
                        path: 'project', component: ProjectComponent, 
                        data: { 
                            permission: 'Pages.Administration.Project' 
                        } 
                    },
                    { 
                        path: 'bid', component: BidComponent, 
                        data: { 
                            permission: 'Pages.Administration.Bid' 
                        }
                    },
                    { 
                        path: 'contract', component: ContractComponent,
                        data: {
                            permission: 'Pages.Administration.Contract'
                        },
                    },
                    {
                        path: 'retail', component: RetailComponent,
                        
                    },
                    {
                        path: 'assignment-table', component: AssignmentTableComponent,
                        data: {
                            permission: 'Pages.Administration.AssignmentTable'
                        },
                    },
                    {
                        path: 'PO', component: POCOmponent,
                        data: {
                            permission: 'Pages.Administration.PO'
                        }
                    },
                ]
            }
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class MainRoutingModule { }
