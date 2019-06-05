import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild, Input, Output, EventEmitter } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';

import { ProductContractInput } from './../../../shared/service-proxies/service-proxies'


@Component({
    selector: 'product-contract-item-component',
    templateUrl: './product-contract-item.component.html',
    animations: [appModuleAnimation()]
})
export class ProductContractItemComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;

    // @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditProductContractModalComponent;
    @Input() pcItem: ProductContractInput
    @Output() deleteElement = new EventEmitter<{}>();
    @Output() changeTotalPrice = new EventEmitter<{}>();
    /**
     * tạo các biến dể filters
     */
    @Input() contractId: number;

    constructor(
        injector: Injector,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);

    }


    onDataChange(e) {
        console.log(e.target.value)
        let quantity = e.target.value?e.target.value:1;
        this.pcItem.amount = quantity;
        this.pcItem.price = quantity*this.pcItem.product.currentPrice
       this.changeTotalPrice.emit()
    }

    onDeleteItem(){      
        this.deleteElement.emit(this.pcItem)
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
        this.changeTotalPrice.emit()
    }

    /**
     * Hàm get danh sách ProductContract
     * @param event
     */

}
