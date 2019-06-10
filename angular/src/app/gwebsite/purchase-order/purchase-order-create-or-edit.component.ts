import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { PurchaseOrderServiceProxy, PurchaseOrderInput, ContractInput, ProductProviderInput, ProviderInput } from '@shared/service-proxies/service-proxies';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'createOrEditPurchaseOrder',
    templateUrl: './purchase-order-create-or-edit.component.html',
    "styles": [
        '../purchase-order.css',
        "styles.css"
    ],
})
export class CreateOrEditPurchaseOrderComponent extends AppComponentBase implements AfterViewInit, OnInit {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('purchaseOrderCombobox') PurchaseOrderCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    purchaseOrder: PurchaseOrderInput = new PurchaseOrderInput();


    constructor(
        injector: Injector,
        private router: Router,  private route:ActivatedRoute,
        private _purchaseOrderService: PurchaseOrderServiceProxy

    ) {
        super(injector);
    }
    ngOnInit(): void {

        if(this.route){
            let id = this.route.snapshot.params['id']
            if(id){
                this._purchaseOrderService.getPurchaseOrderForEdit(id).subscribe(result => {
                     console.log(result)
                        let tempData = result
                        if(tempData.contract==undefined){
                            tempData.contract=new ContractInput()
                        }
                        if(tempData.provider==undefined){                            
                            tempData.provider=new ProviderInput()
                        }
                        //console.log(tempData)
                        this.purchaseOrder= tempData
                //   if(this.purchaseOrder.contract.code==undefined) this.purchaseOrder.contract.code=""                   
                })
                
            }
        }
      

        if (this.purchaseOrder.contract == null || this.purchaseOrder.contract == undefined)
            this.purchaseOrder.contract = new ContractInput
        if (this.purchaseOrder.provider == null || this.purchaseOrder.provider == undefined)
            this.purchaseOrder.provider = new ProviderInput
        if (this.purchaseOrder.purchaseProductDetails == null
            || this.purchaseOrder.purchaseProductDetails == undefined
            || this.purchaseOrder.purchaseProductDetails.length == 0) {
            this.purchaseOrder.totalPrice = 0
        }
        if (this.purchaseOrder.purchasePaymentHistories == null
            || this.purchaseOrder.purchasePaymentHistories == undefined
            || this.purchaseOrder.purchasePaymentHistories.length == 0) {
            this.purchaseOrder.totalMoneyPaid = 0
        }

        console.log(this.purchaseOrder)
        
    }
    ngAfterViewInit(): void {

    }
    testDataDisplay(arr) {

    }
    updateProductTotalPrice(price){
        this.purchaseOrder.totalPrice=price
    }
    save() {
        this._purchaseOrderService.createOrEditPurchaseOrder(this.purchaseOrder).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            //this.router.navigate([''],{relativeTo:this.route})
            console.log(this.purchaseOrder)
        })
    }
}