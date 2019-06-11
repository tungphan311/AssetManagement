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
    ) {
        super(injector);
    }

    /**
     * Hàm xử lý trước khi View được init
     */
    ngOnInit(): void {
        console.log('activated route: '+this._activatedRoute.snapshot.url)
    }

    /**
     * Hàm xử lý sau khi View được init
     */
    ngAfterViewInit(): void {        
    }
    
    reloadList(purchaseOrderName, event?: LazyLoadEvent) {
        this._purchaseOrderService.getPurchaseOrdersByFilter(this.purchaseOrderName, this.primengTableHelper.getSorting(this.dataTable),
        this.primengTableHelper.getMaxResultCount(this.paginator, event),
        this.primengTableHelper.getSkipCount(this.paginator, event),
    ).subscribe(result => {
        this.primengTableHelper.totalRecordsCount = result.totalCount;
        this.primengTableHelper.records = result.items;
        this.primengTableHelper.hideLoadingIndicator();
    });
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.purchaseOrderName = params['name'] || '';
            this.reloadList(this.purchaseOrderName, null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.purchaseOrderName, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }
     getPurchaseOrders(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null, event);

    }
    deletePurchaseOrder(id){
        this._purchaseOrderService.deletePurchaseOrder(id).subscribe(() => {
            this.reloadPage();
        })
    }

    editPurchaseOrder(id){
        this.router.navigate(['../edit',id]).then(()=>{
            //emit
        })
    }
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');

    }
    
    
}