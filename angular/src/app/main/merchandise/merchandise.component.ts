import { Component, AfterViewInit, OnInit, ViewChild, Injector } from "@angular/core";
import { appModuleAnimation } from "@shared/animations/routerTransition";
import { AppComponentBase } from "@shared/common/app-component-base";
import { Table } from "primeng/components/table/table";
import { Paginator } from "primeng/components/paginator/paginator";
import { MerchandiseServiceProxy, MerchandiseTypeServiceProxy, VendorTypeServiceProxy, VendorServiceProxy } from "@shared/service-proxies/service-proxies";
import { ActivatedRoute, Params } from "@angular/router";
import { LazyLoadEvent } from "primeng/components/common/lazyloadevent";
import { CreateOrEditMerchandiseModalComponent } from "./create-or-edit-merchandise-modal.component";
import { ViewMerchandiseModalComponent } from "./view-merchandise-modal.component";
import { WebApiServiceProxy } from "@shared/service-proxies/webapi.service";
import { MerchandiseTypeComponent } from "../merchandise-type/merchandise-type.component";
import { retry } from "rxjs/operators";

@Component({
    templateUrl: './merchandise.component.html',
    animations: [appModuleAnimation()]
})

export class MerchandiseComponent extends AppComponentBase implements AfterViewInit, OnInit {
    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditMerchandiseModalComponent;
    @ViewChild('viewMerchandiseModal') viewMerchandiseModal: ViewMerchandiseModalComponent;
    @ViewChild('merchandiseType') merchandiseType: MerchandiseTypeComponent;

    /**
     * tạo các biến dể filters
     */
    merchandiseName: string
    merchandiseCode: string
    merchandiseTypeID: number
    merchandiseTypeVender: number
    merchandiseIsActive: string

    merType = []
    typeVender = []
    
    constructor(
        injector: Injector,
        private _merchandiseService: MerchandiseServiceProxy,
        private _merTypeService: MerchandiseTypeServiceProxy,
        private _vendorService: VendorServiceProxy,
        private _activatedRoute: ActivatedRoute,
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

    /**
     * Hàm get danh sách Merchandise
     * @param event
     */
    getMerchandises(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null, null, 0, 0, null, event);
    }

    getTypeNames(id: number): any {
        for (const iterator of this.merType) {
            if (iterator.id === id) {
                return iterator.name;
            }
        }
    }

    getTypeVenderNames(id: number): any {
        for (const iterator of this.typeVender) {
            if (iterator.id == id) {
                return iterator.name;
            }
        }
    }

    reloadList(merchandiseCode, merchandiseName, merchandiseTypeID: number, merchandiseTypeVender, merchandiseIsActive, event?: LazyLoadEvent) {
        this._merchandiseService.getMerchandiseByFilter(merchandiseCode, 
            merchandiseName, merchandiseTypeID, merchandiseTypeVender, merchandiseIsActive, 
            this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });

        this._merTypeService.getMerchandiseByFilter(null, null, null, null, 999, 0).subscribe(result => {
            this.merType = result.items
        })

        this._vendorService.getVendorsByFilter(null,null,0,null, null, 999, 0).subscribe(result => {
            this.typeVender = result.items
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.merchandiseCode = params['code'] || '';
            this.merchandiseName = params['name'] || '';
            this.merchandiseTypeID = params['typeID'] || 0;
            this.merchandiseTypeVender = params['typeVender'] || 0;
            this.merchandiseIsActive = params[String('isActive')] || '';
            this.reloadList(this.merchandiseCode,this.merchandiseName, this.merchandiseTypeID, this.merchandiseTypeVender, this.merchandiseIsActive, null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    deleteMerchandise(id): void {
        this._merchandiseService.deleteMerchandise(id).subscribe(() => {
            this.reloadPage();
        })
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.merchandiseCode,this.merchandiseName, this.merchandiseTypeID, this.merchandiseTypeVender, this.merchandiseIsActive, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    //hàm show view create MenuClient
    createMerchandise() {
        this.createOrEditModal.show();
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}

