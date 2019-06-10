import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MenuClientComponent } from '@app/gwebsite/menu-client/menu-client.component';
import { DemoModelComponent } from './demo-model/demo-model.component';
import { CustomerComponent } from './customer/customer.component';
import { ProductComponent } from './product/product.component';
import { ProjectComponent } from './project/project.component';
import { BidComponent } from './bid/bid.component';
import { ProviderComponent } from './provider/provider.component';
import { ContractComponent, } from './contract/contract.component';
import {CreateOrEditContractModalComponent} from './contract/create-or-edit-contract-modal.component';
import{ProductContractComponent} from './product-contract/product-contract.component';
import {PurchaseOrderComponent} from './purchase-order/purchase-order.component'
import {CreateOrEditProductContractModalComponent} from './product-contract/create-or-edit-product-contract-modal.component'
import { CreateOrEditPurchaseOrderComponent } from './purchase-order/purchase-order-create-or-edit.component';
import { PurchaseOrderSearchComponent } from './purchase-order/purchase-order-search.component';
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
                        path: 'product', component: ProductComponent,
                        data: { permission: 'Pages.Administration.Product' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'project', component: ProjectComponent,
                        data: { permission: 'Pages.Administration.Project' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'bid', component: BidComponent,
                        data: { permission: 'Pages.Administration.Bid' }
                    },
                ]
            },
            {
                path: '',
                children: [
                    {
                        path: 'contract', component: ContractComponent,
                        data: { permission: 'Pages.Administration.Contract' },
                        children:[
                            {
                                path: 'createcontract', component: CreateOrEditContractModalComponent,
                                data: { permission: 'Pages.Administration.Contract.Create' },
                            }
                        ]
                    },
                ]
            },

            {
                path:'',
                children:[
                    {
                        path:'product-contract',component:ProductContractComponent,
                        data:{permission:'Pages.Administration.ProductContract'}
                    }
                ]
            },
		
			 {
                path: '',
                children: [
                    {
                        path: 'provider', component: ProviderComponent,
                        data: { permission: 'Pages.Administration.Provider' }
                    },
                ]
            },   
            {
                path: '',
                children: [
                    {
                        path: 'purchase-order', component: PurchaseOrderComponent,
                        data: { permission: 'Pages.Administration.PurchaseOrder' },
                        children:[
                            {
                                path:'create',component:CreateOrEditPurchaseOrderComponent,
                                data:{permission:'Pages.Administration.PurchaseOrder.Create'}
                            },
                            {
                                path:'edit/:id',component:CreateOrEditPurchaseOrderComponent,
                                data:{permission:'Pages.Administration.PurchaseOrder.Edit'}
                            },
                            {
                                path:'',component:PurchaseOrderSearchComponent,
                                data:{permission:'Pages.Administration.PurchaseOrder'}
                            }
                        ]
                    },
                ]
            },   
		   			
        ])
        
    ],
    exports: [
        RouterModule
    ]
})
export class GWebsiteRoutingModule { }
