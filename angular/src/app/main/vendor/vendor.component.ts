import { ViewVendorModalComponent } from './view-vendor-modal.component';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { VendorServiceProxy } from '@shared/service-proxies/service-proxies';
import { VendorTypeServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditVendorModalComponent } from './create-or-edit-vendor-modal.component';

@Component({
    templateUrl: './vendor.component.html',
    animations: [appModuleAnimation()]
})
export class VendorComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditVendorModalComponent;
    @ViewChild('viewVendorModal') viewVendorModal: ViewVendorModalComponent;

    /**
     * tạo các biến dể filters
     */
    vendorCode: string;
    vendorName: string;
    vendorTypeID: number;
    vendorIsActive: string;

    // list vendortype
    vendortypeList = [];

    constructor(
        injector: Injector,
        private _vendorService: VendorServiceProxy,
        private _vendortypeService: VendorTypeServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);
    }

    /**
     * Hàm xử lý trước khi View được init
     */
    ngOnInit(): void {
        //load list vendortype
        this._vendortypeService.getVendorTypesByFilter(null, null, null, null, 99, 0,
        ).subscribe(result => {
            this.vendortypeList = result.items;
        });
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
     * Hàm get danh sách Vendor
     * @param event
     */
    getVendors(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null,null,0,null, event);

    }

    reloadList(vendorCode, vendorName, vendorTypeID, vendorIsActive, event ?: LazyLoadEvent) {
        this._vendorService.getVendorsByFilter(vendorCode, vendorName, vendorTypeID, vendorIsActive,
            this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    deleteVendor(id): void {
        this._vendorService.deleteVendor(id).subscribe(() => {
            this.reloadPage();
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.vendorCode = params['code'] || '';
            this.vendorName = params['name'] || '';
            this.vendorTypeID = params['typeID'] || 0;
            this.vendorIsActive = params['isActive'] || '';
            this.reloadList(this.vendorCode, this.vendorName, this.vendorTypeID, this.vendorIsActive, null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.vendorCode, this.vendorName, this.vendorTypeID, this.vendorIsActive, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    //hàm show view create MenuClient
    createVendor() {
        this.createOrEditModal.show();
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }

    getVendorTypeName(TypeID): String {
        for (let vendortype of this.vendortypeList) {
            if (vendortype.id==TypeID) {
                return vendortype.name;
            }
        }
        return "";
    }
}
