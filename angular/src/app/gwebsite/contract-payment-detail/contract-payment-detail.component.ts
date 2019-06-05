import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild, Input, Output,EventEmitter } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { ContractPaymentDetailServiceProxy, ContractPaymentDetailInput, ContractInput } from '@shared/service-proxies/service-proxies';
import {CreateOrEditContractPaymentDetailModalComponent} from './create-or-edit-contract-payment-detail-modal.component'

@Component({
    selector: 'contractPaymentDetailComponent',
    templateUrl: './contract-payment-detail.component.html',
    animations: [appModuleAnimation()]
})
export class ContractPaymentDetailComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('CRUpaymentModal') CRUpaymentModal: CreateOrEditContractPaymentDetailModalComponent;
    // @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditProductModalComponent;

    // ContractPaymentDetails : ContractPaymentDetailInput[];
    @Input('contractInput') contractInput:ContractInput
    @Input()totalPriceInput:number;
    @Output() newItemAdded = new EventEmitter();
    /**
     * tạo các biến dể filters
     */
   
    constructor(
        injector: Injector,
        // private _ContractPaymentDetailService: ContractPaymentDetailServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);

    }

    /**
     * Hàm xử lý trước khi View được init
     */
    ngOnInit(): void {
    }

    /**
     * Hàm xử lý sau khi View được init
     */
    ngAfterViewInit(): void {
         this.contractInput.totalPrice = 0;
    }

    addPaymentToList(item) {
        this.newItemAdded.emit(item)
      

        
    }
    
    reloadPage(){
        
    }
    onChangeTotalPrice(e) {

    }
    /**
     * Hàm get danh sách ContractPaymentDetail
     * @param event
     */



    init(): void {
      
    }



    // applyFilters(): void {
    //     //truyền params lên url thông qua router
    //     this.reloadList(this.contractId, null);

    //     if (this.paginator.getPage() !== 0) {
    //         this.paginator.changePage(0);
    //         return;
    //     }
    // }

    onDeleteItem(item) {
        console.log(item)
      let newArr=  this.contractInput.contractPaymentDetails.filter(e => e.id != item.id)
      this.contractInput.contractPaymentDetails=[...newArr]
        this.contractInput.totalPrice -= item.price
        if (this.contractInput.totalPrice < 0) this.contractInput.totalPrice = 0
        console.log(this.contractInput.contractPaymentDetails)
    }
    changeTotalPrice(item) {
        if (this.contractInput && this.contractInput.contractPaymentDetails && this.contractInput.contractPaymentDetails.length > 0) {
            let totalPrice = this.contractInput.contractPaymentDetails.reduce((total, item) => total + item.price, 0)
            this.contractInput.totalPrice = totalPrice
        }
    }
    //hàm show view create MenuClient
    createContractPaymentDetail() {
        this.CRUpaymentModal.show();
    }



    
    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
