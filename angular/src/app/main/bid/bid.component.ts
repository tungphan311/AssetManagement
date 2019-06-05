import { ViewBidModalComponent } from './view-bid-modal.component';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { BidServiceProxy,VendorServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditBidModalComponent } from './create-or-edit-bid-modal.component';

@Component({
    templateUrl: './bid.component.html',
    animations: [appModuleAnimation()]
})
export class BidComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditBidModalComponent;
    @ViewChild('viewBidModal') viewBidModal: ViewBidModalComponent;

    /**
     * tạo các biến dể filters
     */
    bidName: string;
    bidCategory: string;
    bidStart: string;
    bidEnd: string;
    bidForm: "All";
    bidVendorCode: string;

    constructor(
        injector: Injector,
        private _bidService: BidServiceProxy,
        private _vendorService: VendorServiceProxy,
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
        setTimeout(() => {
            this.init();
        });
    }

    /**
     * Hàm get danh sách Bid
     * @param event
     */
    getBids(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null,null,null,null,'All',null, event);

    }

    reloadList(bidName,bidCategory,bidStart,bidEnd,bidForm,bidVendorCode, event?: LazyLoadEvent) {
        this._bidService.getBidsByFilter(bidName,bidCategory,bidStart,bidEnd,bidForm,0, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            if(bidVendorCode!=null&&bidVendorCode!='')
            {
                //lọc theo mã đơn vị trúng thầu
                this._vendorService.getVendorsByFilter(bidVendorCode,null,0,null,null,999,0).subscribe(vendorResult=>{
                    result.items = result.items.filter(x=>vendorResult.items.filter(y=>y.id==x.bidderID).length>0)
                    this.primengTableHelper.totalRecordsCount = result.items.length;
                    this.primengTableHelper.records = result.items;
                    this.primengTableHelper.hideLoadingIndicator();
                })
            }
            else{
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
            }
        });
    }

    deleteBid(id): void {
        this._bidService.deleteBid(id).subscribe(() => {
            this.reloadPage();
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.bidName = params['name'] || '';
            this.bidCategory = params['category'] || '';
            this.bidStart=params['start']||'';
            this.bidEnd=params['end']||'';
            this.bidForm=params['form']||'All';
            this.bidVendorCode = params['vendorcode']||'';
            this.reloadList(this.bidName,this.bidCategory,this.bidStart,this.bidEnd,this.bidForm,this.bidVendorCode, null)
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.bidName,this.bidCategory,this.bidStart,this.bidEnd,this.bidForm,this.bidVendorCode, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    //hàm show view create MenuClient
    createBid() {
        this.createOrEditModal.show();
    }
    dateFormat(date): string {
        var moment = require('moment');
        var _date = moment(date);
        var tz = _date.utcOffset();
        _date.add(tz, 'm');
        return _date.format('DD/MM/YYYY');
    }
    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
