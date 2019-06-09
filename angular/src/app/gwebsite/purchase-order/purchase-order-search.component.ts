import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { PurchaseOrderServiceProxy } from '@shared/service-proxies/service-proxies';
@Component({
    templateUrl: './purchase-order-search.component.html',
    animations: [appModuleAnimation()]
})
export class PurchaseOrderSearchComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
   
    /**
     * tạo các biến dể filters
     */
    purchaseOrderName: string;

    constructor(
        injector: Injector,
        private _purchaseOrderService: PurchaseOrderServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private router:Router,
        private route:ActivatedRoute
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
    }
    
}