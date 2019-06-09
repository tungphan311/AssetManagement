import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild, AfterViewInit, OnInit,Input } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import {  PurchaseProductDetailInput, ContractInput, ProductProviderInput, PurchaseOrderInput } from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'purchase-product-detail-component',
    templateUrl: './purchase-product-detail.component.html'
    
})
export class PurchaseProductDetailComponent extends AppComponentBase implements AfterViewInit, OnInit {


    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('purchaseProductDetailCombobox') PurchaseProductDetailCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    @Input() purchaseOrderRecieved:PurchaseOrderInput[]
    


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

}