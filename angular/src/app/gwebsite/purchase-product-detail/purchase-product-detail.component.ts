import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild, AfterViewInit, OnInit, Input } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { PurchaseProductDetailInput, ContractInput, ProductProviderInput, PurchaseOrderInput } from '@shared/service-proxies/service-proxies';
import { PurchaseProductSelectionModalComponent } from './purchase-product-selection-modal.component';

@Component({
    selector: 'purchase-product-detail-component',
    templateUrl: './purchase-product-detail.component.html',
    styles: [`
    .input-inside-table {     
      width: 100%;
    }
  `]

})
export class PurchaseProductDetailComponent extends AppComponentBase implements AfterViewInit, OnInit {


    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('purchaseProductDetailCombobox') PurchaseProductDetailCombobox: ElementRef;
    @ViewChild('purchaseProductSelectionModal') purchaseProductSelectionModal: PurchaseProductSelectionModalComponent;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() updateTotalPrice: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    @Input() purchaseOrderRecieved: PurchaseOrderInput



    constructor(
        injector: Injector,
        //private _purchaseProductDetailService: PurchaseProductDetailServiceProxy

    ) {
        super(injector);
    }
    ngOnInit(): void {

    }
    ngAfterViewInit(): void {

    }

    deleteDetail(object) {
        let index = this.purchaseOrderRecieved.purchaseProductDetails.indexOf(object)
        if (index !== -1) {
            this.purchaseOrderRecieved.purchaseProductDetails.splice(index, 1);
        }

        this.calculateSumTotalPrice()


    }

    calculateSumTotalPrice() {
        let totalProductPrice = this.purchaseOrderRecieved.purchaseProductDetails.reduce((total, item) => total + item.price, 0)
        if (!totalProductPrice) totalProductPrice = 0
        this.purchaseOrderRecieved.totalPrice = totalProductPrice
        //this.primengTableHelper.totalRecordsCount = this.purchaseOrderRecieved.totalPrice;
        this.updateTotalPrice.emit(totalProductPrice)
    }

    updateAmount(item, event) {
        let amount = (event.target.value)
        if (amount <= 0 || amount == undefined) {amount = 1;}
        item.amount = amount

        item.price = amount * item.price
      
        this.calculateSumTotalPrice()
    }
    /**
    * Tạo pipe thay vì tạo từng hàm truncate như thế này
    * @param text
    */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');

    }

    show() {
        this.purchaseProductSelectionModal.show();
    }

}