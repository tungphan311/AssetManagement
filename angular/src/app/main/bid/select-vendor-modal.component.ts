
import { Component, ElementRef, Injector, ViewChild, Output, EventEmitter } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { ModalDirective } from 'ngx-bootstrap';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { VendorServiceProxy, VendorInput } from '@shared/service-proxies/service-proxies';


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
    isSelectAll=false;
    selectedIDs=[1];
    
    listVendor= [{"vendor":new VendorInput(),"isSelected":false}];

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
        this._vendorService.getVendorsByFilter(vendorId,vendorName,0,"True", this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            //lọc vendor chưa được chọn trước
            if (this.selectedIDs.length>0){             
                result.items = result.items.filter(x=>this.selectedIDs.filter(y=>y==x.id).length==0);}
            //--
            //lưu list selected
            let selectedIDs = new Array<number>();
            for (const item of result.items){
                if (this.listVendor.filter(x=>x.vendor.id==item.id).filter(x=>x.isSelected).length>0)
                    selectedIDs.push(item.id);
            }         
            while (this.listVendor.length>0){
                this.listVendor.pop();
            }
            for (const item of result.items){
                let obj ={
                    vendor:item,
                    isSelected:false
                }
                //track để giữ lại tíck cho vendor
                if (selectedIDs.filter(x=>x==obj.vendor.id).length>0)
                    obj.isSelected=true;
                //--
                this.listVendor.push(obj);
            }
            this.checkAll();
            this.primengTableHelper.totalRecordsCount = result.items.length;
            this.primengTableHelper.records = this.listVendor;          
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
    selectAll(): void {
        for (const record of this.primengTableHelper.records){
            record.isSelected = this.isSelectAll;
        }
    }
    checkAll(): void{
        for (var vendor of this.listVendor){
            if (!vendor.isSelected)
                {
                    this.isSelectAll = false;
                    return;
                }
        }
        this.isSelectAll = true;
        return;
    }
    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
    show(selectedIDs:number[]): void {
        this.saving = false;
        while (this.selectedIDs.length>0)
            this.selectedIDs.pop();
        for (const id of selectedIDs)        
            this.selectedIDs.push(id);
        this.getVendors();
        this.selectVendorModal.show();
    }

    save(): void {
        this.saving = true;
        let selectedIDs = new Array<number>();
        for (const vendor of this.listVendor){
            if (vendor.isSelected){
                selectedIDs.push(vendor.vendor.id);
            }
        }
        if (selectedIDs.length>0)
            this.close(selectedIDs); 
        else
            this.close(0);         
    }

    close(selectedIDs?:number[]|0): void {
        this.selectVendorModal.hide();
        this.modalSave.emit(selectedIDs);
    }
}
