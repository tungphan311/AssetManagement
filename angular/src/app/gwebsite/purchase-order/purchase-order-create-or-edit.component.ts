import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { PurchaseOrderServiceProxy, PurchaseOrderInput, ContractInput, ProductProviderInput, ProviderInput } from '@shared/service-proxies/service-proxies';

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
        private _purchaseOrderService: PurchaseOrderServiceProxy

    ) {
        super(injector);
    }
    ngOnInit(): void {
        if (this.purchaseOrder.contract == null || this.purchaseOrder.contract == undefined)
            this.purchaseOrder.contract = new ContractInput
        if (this.purchaseOrder.provider == null || this.purchaseOrder.provider == undefined)
            this.purchaseOrder.provider = new ProviderInput
    }
    ngAfterViewInit(): void {
       
    }

}