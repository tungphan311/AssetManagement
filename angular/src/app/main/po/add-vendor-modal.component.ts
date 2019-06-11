
import { Component, ElementRef, Injector, ViewChild, Output, EventEmitter } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { ModalDirective } from 'ngx-bootstrap';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { VendorServiceProxy,VendorTypeServiceProxy, VendorTypeDto } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'addVendorModal',
    templateUrl: './add-vendor-modal.component.html'
})

export class AddVendorModalComponent extends AppComponentBase {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('addVendorModal') addVendorModal: ModalDirective;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;
    /**
     * tạo các biến dể filters
     */
    vendorCode:string;
    vendorName:string;
    vendorTypeId:number;

    listVendorType: VendorTypeDto[] = [];

    constructor(
        injector: Injector,
        private _vendorService: VendorServiceProxy,
        private _vendorTypeService: VendorTypeServiceProxy
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
        this.reloadList(null, null, 0, event);

    }

    reloadList(vendorCode, vendorName, vendorTypeId, event?: LazyLoadEvent) {
        this._vendorService.getVendorsByFilter(vendorCode,vendorName,vendorTypeId,"True", this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
        this._vendorTypeService.getVendorTypesByFilter(null,null,null,null,999,0).subscribe(result=>{
            this.listVendorType = result.items;
        })    
    }
    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.vendorCode, this.vendorName, this.vendorTypeId, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
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
        this.addVendorModal.show();
    }

    save(vendorID:number): void {
        this.saving = true;
        this.close(vendorID);          
    }
    getVendorTypeName(vendorID:number):string{
        this.listVendorType.filter(x=>x.id=vendorID).forEach(type=>{
            return type.name;
        })
        return "";
    }
    close(vendorID?:number|0): void {
        this.addVendorModal.hide();
        this.modalSave.emit(vendorID);
    }
}
