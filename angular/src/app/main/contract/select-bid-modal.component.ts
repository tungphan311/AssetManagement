import { Component, ViewChild, Injector, Output, EventEmitter, AfterViewInit, OnInit } from "@angular/core";
import { AppComponentBase } from "@shared/common/app-component-base";
import { ModalDirective } from "ngx-bootstrap";
import { DataTable, Paginator, LazyLoadEvent } from "primeng/primeng";
import { BidServiceProxy, VendorServiceProxy } from "@shared/service-proxies/service-proxies";
import { Table } from "primeng/table";
import { ActivatedRoute, Params } from "@angular/router";


@Component({
    selector: 'selectBidModal',
    templateUrl: './select-bid-modal.component.html'
})

export class SelectBidModalComponent extends AppComponentBase implements AfterViewInit, OnInit {
    
    @ViewChild('selectBidModal') selectBidModal: ModalDirective;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
    
    saving = false;

    bidId: string;
    category: string;
    biddingForm: "All";
    beginDay: string;
    endDay: string;
    bidderId: string;

    constructor(
        injector: Injector,
        private _bidService: BidServiceProxy,
        private _vendorService: VendorServiceProxy,
        private _activatedRoute: ActivatedRoute
    ) {
        super(injector);
    }

    ngAfterViewInit(): void {
        setTimeout(() => {
            this.init();
        });
    }

    ngOnInit(): void {

    }

    show(): void {
        this.saving = false;
        this.selectBidModal.show();
    }

    getBids(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */
        this.reloadList(null, null, null, null, "All", null, event);
    }

    reloadList(bidId, category, beginDay, endDay, biddingForm, bidderId, event?: LazyLoadEvent) {
        this._bidService.getBidsByFilter(bidId, 
            category, beginDay, endDay, biddingForm, 0, 
            this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            // if (bidderId != null) {
            //     //lọc theo mã đơn vị trúng thầu
            //     this._vendorService.getVendorsByFilter(bidderId,null,0,null,null,999,0).subscribe(vendorResult=>{
            //         result.items = result.items.filter(x=>vendorResult.items.filter(y=>y.id==x.bidderID).length>0)
            //         this.primengTableHelper.totalRecordsCount = result.items.length;
            //         this.primengTableHelper.records = result.items;
            //         this.primengTableHelper.hideLoadingIndicator();
            //     });
            // }
            // else {
            //     this.primengTableHelper.totalRecordsCount = result.totalCount;
            //     this.primengTableHelper.records = result.items;
            //     this.primengTableHelper.hideLoadingIndicator();
            // } 
            
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.bidId = params['name'] || '';
            this.category = params['category'] || '';
            this.beginDay = params['start'] || '';
            this.endDay = params['end'] || '';
            this.biddingForm = params['form'] || 'All';
            this.bidderId = params['vendorcode'] || '';
            this.reloadList(this.bidId,this.category,this.beginDay,this.endDay,this.biddingForm,this.bidderId, null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    dateFormat(date): string {
        var moment = require('moment');
        //add timezone vào time :/ với cách éo thể nào ngu hơn đc =))
        var _date = moment(date);
        var tz = _date.utcOffset(); //lấy timezone đv phút
        _date.add(tz, 'm'); //add phút
        return _date.format('DD/MM/YYYY');
    }

    applyFilters(): void {
        this.reloadList(this.bidId,this.category,this.beginDay,this.endDay,this.biddingForm,this.bidderId, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }

    save(bidId: number): void {
        this.saving = true;
        this.close(bidId);          
    }

    close(bidId?: number | 0): void {
        this.selectBidModal.hide();
        this.modalSave.emit(bidId);
    }
}