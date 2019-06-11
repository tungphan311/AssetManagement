
import { Component, ElementRef, Injector, ViewChild, Output, EventEmitter } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { ModalDirective } from 'ngx-bootstrap';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { ContractServiceProxy,BidServiceProxy,VendorServiceProxy,BidDto,VendorDto } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'selectContractModal',
    templateUrl: './select-contract-modal.component.html'
})

export class SelectContractModalComponent extends AppComponentBase {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('selectContractModal') selectContractModal: ModalDirective;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    


    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;
    /**
     * tạo các biến dể filters
     */
    contractID: string;
    contractName: string;
    contractDate: string;
    bidID: number;
    vendorID: number;
    listBid: BidDto[] = []
    listVendor: VendorDto[] = []

    constructor(
        injector: Injector,
        private _contractService: ContractServiceProxy,
        private _bidService: BidServiceProxy,
        private _vendorService: VendorServiceProxy
    ) {
        super(injector);
    }

    getContracts(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */
        this.reloadList(null, null, null, 0, 0, event);

    }

    reloadList(contractId, contractName, contractDate, bidID,vendorID, event?: LazyLoadEvent) {
        this._contractService.getContractsByFilter(contractId,contractName,contractDate,bidID,vendorID, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
        this._bidService.getBidsByFilter(null, null, null, null, 'All', 0, null, 999, 0).subscribe(result => {
            this.listBid = result.items;
        });

        this._vendorService.getVendorsByFilter(null, null, 0, null, null, 999, 0).subscribe(result => {
            this.listVendor = result.items;
        })
    }
    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.contractID, this.contractName, this.contractDate,this.bidID,this.vendorID, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }
    getVendorName(id: number): any {
        for (const item of this.listBid) {
            if (item.id == id) {
                for (const vendor of this.listVendor) {
                    if (vendor.id == item.bidderID) {
                        return vendor.name;
                    }
                }
            }
        }
        return "Chưa có nhà cung cấp";
    }
    getBidNameFromId(id: number): any {
        for(const item of this.listBid) {
            if (item.id == id) {
                return item.name;
            }
        }
        return "Chưa có mã gói thầu";
    }
    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    dateFormat(date): string {
        var moment = require('moment');
        //add timezone vào time
        var _date = moment(date);
        var tz = _date.utcOffset(); //lấy timezone đv phút
        _date.add(tz, 'm'); //add phút
        return _date.format('DD/MM/YYYY');
    }
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
    show(): void {
        this.saving = false;
        this.selectContractModal.show();
    }

    save(contractID:number): void {
        this.saving = true;
        this.close(contractID);          
    }

    close(contractID?:number|0): void {
        this.selectContractModal.hide();
        this.modalSave.emit(contractID);
    }
}
