import { Component, Injector, ViewChild, AfterViewInit, OnInit } from "@angular/core";
import { appModuleAnimation } from "@shared/animations/routerTransition";
import { AppComponentBase } from "@shared/common/app-component-base";
import { Table } from "primeng/table";
import { Paginator, LazyLoadEvent } from "primeng/primeng";
import { AssignmentTableServiceProxy, MerchandiseServiceProxy, VendorServiceProxy } from "@shared/service-proxies/service-proxies";
import { ActivatedRoute, Params } from "@angular/router";
import { CreateOrEditAssignmentTableModalComponent } from "./create-or-edit-assignment-table-modal.component";

@Component({
    templateUrl: './assignment-table.component.html',
    animations: [appModuleAnimation()]
})

export class AssignmentTableComponent extends AppComponentBase implements AfterViewInit, OnInit {
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditAssignmentTableModalComponent

    // tao bien de filter
    assignmentTableID: string
    MerchID: string
    VendorID: string

    // list 
    assignmenttablelist = [];
    vendorlist=[];
    merchlist=[];

    constructor(
        injector: Injector,
        private _assignmentTableService: AssignmentTableServiceProxy,
        private _merchandiseService: MerchandiseServiceProxy,
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
    deleteAssignmentTable(id): void {
        this._assignmentTableService.deleteAssignmentTable(id).subscribe(() => {
            this.reloadPage();
        })
    }

    ngOnInit(): void {
        //load list assignmenttable
        this._assignmentTableService.getAssignmentTablesByFilter(0,0,null,99,0);
    }

    /**
     * Hàm get danh sách Assignment Table
     * @param event
     */
    getAssignmentTable(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */


        this.reloadList(0,0, event);
    }

        /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }

    reloadList(merchandiseID, vendorID, event ?: LazyLoadEvent) {
        this._assignmentTableService.getAssignmentTablesByFilter(merchandiseID,vendorID,
            this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
        this._merchandiseService.getMerchandiseByFilter(null,null,0,0,null,null,99,0).subscribe(result => {
            this.merchlist=result.items
        })
        this._vendorService.getVendorsByFilter(null,null,0,null,null,99,0).subscribe(result =>{
            this.vendorlist=result.items
        })
    }

    init(): void {
        this._activatedRoute.params.subscribe((params: Params) => {
            this.MerchID = params['merchID'] || 0;
            this.VendorID= params['vendorID'] || 0;
            this.reloadList(this.MerchID,this.VendorID,null);

        });

    }
    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }
    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.MerchID,this.VendorID, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }
    createAssignmentTable() : void {
         this.createOrEditModal.show();
    }
    getMerchName(id: number): any {
        for (const iterator of this.merchlist) {
            if (iterator.id === id) {
                return iterator.name;
            }
        }
    }

    getVendorName(id: number): any {
        for (const iterator of this.vendorlist) {
            if (iterator.id == id) {
                return iterator.name;
            }
        }
    }


}
