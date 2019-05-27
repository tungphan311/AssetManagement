
import { Component, ElementRef, Injector, ViewChild, Output, EventEmitter } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { ModalDirective } from 'ngx-bootstrap';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { VendorServiceProxy } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'selectVendorModal',
    templateUrl: './select-vendor-modal.component.html'
})

export class SelectVendorModalComponent extends AppComponentBase {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('selectVendorModal') selectVendorModal: ModalDirective;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    


    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;
    /**
     * tạo các biến dể filters
     */
    vendorCode: string;
    vendorName: string;
    vendorDate: string;

    constructor(
        injector: Injector,
        private _vendorService: VendorServiceProxy
    ) {
        super(injector);
    }

    getVendors(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null,null, event);

    }

    reloadList(vendorId, vendorName, event?: LazyLoadEvent) {
        this._vendorService.getVendorsByFilter(vendorId,vendorName,0,"False", this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }
    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.vendorCode, this.vendorName, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
    show(): void {
        this.saving = false;
        this.selectVendorModal.show();
    }

    save(vendorID:number): void {
        this.saving = true;
        this.close(vendorID);          
    }

    close(vendorID?:number|0): void {
        this.selectVendorModal.hide();
        this.modalSave.emit(vendorID);
    }
}
