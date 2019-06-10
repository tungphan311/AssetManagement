import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild, AfterViewInit, OnInit, Input } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { PurchasePaymentHistoryInput, ContractInput, ProductProviderInput, PurchaseOrderInput } from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'purchase-payment-history-component',
    templateUrl: './purchase-payment-history.component.html'

})
export class PurchasePaymentHistoryComponent extends AppComponentBase implements AfterViewInit, OnInit {


    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('purchasePaymentHistoryCombobox') PurchasePaymentHistoryCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() onDeleteElement: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    @Input() purchaseOrderRecieved: PurchaseOrderInput
    paymentList: PurchasePaymentHistoryInput[]


    constructor(
        injector: Injector,
        //private _purchasePaymentHistoryService: PurchasePaymentHistoryServiceProxy

    ) {
        super(injector);
    }
    ngOnInit(): void {

    }
    ngAfterViewInit(): void {

    }

    addNewPayment() {      
       
        let newArr = this.purchaseOrderRecieved.purchasePaymentHistories ? this.purchaseOrderRecieved.purchasePaymentHistories : []
        let item = new PurchasePaymentHistoryInput()        
        this.purchaseOrderRecieved.purchasePaymentHistories = [...newArr, item]

        // this.primengTableHelper.totalRecordsCount = this.purchaseOrderRecieved.totalMoneyPaid;
        // this.primengTableHelper.records = this.purchaseOrderRecieved.purchasePaymentHistories;
    }
    deletePayment(object){
       let index = this.purchaseOrderRecieved.purchasePaymentHistories.indexOf(object)
       if (index !== -1) {
        this.purchaseOrderRecieved.purchasePaymentHistories.splice(index, 1);
      }       
      this.calculateTotalPaidMoney()

      this.onDeleteElement.emit(this.purchaseOrderRecieved.purchasePaymentHistories)
      
    }

calculateTotalPaidMoney(){
    let totalMoneyPaid = this.purchaseOrderRecieved.purchasePaymentHistories.reduce((total,item)=>total+item.price,0)            
    if(!totalMoneyPaid) totalMoneyPaid=0
    this.purchaseOrderRecieved.totalMoneyPaid=totalMoneyPaid
  this.primengTableHelper.totalRecordsCount = this.purchaseOrderRecieved.totalMoneyPaid;

}

    updatePrice(payment,e){
        let percent = e.target.value
        if(percent<=0 ) return


        if(payment){
            payment.percent = percent
            payment.price=payment.percent*this.purchaseOrderRecieved.totalPrice/100
        }
        this.calculateTotalPaidMoney()
    }

    updatePercent(){

        this.calculateTotalPaidMoney()
    }
    /**
    * Tạo pipe thay vì tạo từng hàm truncate như thế này
    * @param text
    */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');

    }
}