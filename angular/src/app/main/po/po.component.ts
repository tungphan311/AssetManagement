import { AppComponentBase } from "@shared/common/app-component-base";
import { Injector, Component, ViewChild, AfterViewInit, OnInit } from "@angular/core";
import { appModuleAnimation } from "@shared/animations/routerTransition";
import { Table } from "primeng/table";
import { Paginator, LazyLoadEvent } from "primeng/primeng";
import { POServiceProxy } from "@shared/service-proxies/service-proxies";
import { ActivatedRoute, Params } from "@angular/router";
import { CreateOrEditPOModalComponent } from "./create-or-edit-po-modal.component";

@Component({
    templateUrl: './po.component.html',
    animations: [appModuleAnimation()]
})

export class POCOmponent extends AppComponentBase implements AfterViewInit, OnInit {
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditPOModalComponent;

    POId: string;
    orderName: string;
    contractID: string;
    vendorId: string;
    type: string;

    constructor(
        injector: Injector,
        private _poService: POServiceProxy,
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

    getPOs(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null, null, null, null, "in", event);
    }

    reloadList(POId, orderName, contractID, vendorId, type, event?: LazyLoadEvent) {
        this._poService.getPOByFilter(POId, orderName, contractID, vendorId, type, 
            this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        })
    }

    init(): void {
        this._activatedRoute.params.subscribe((params: Params) => {
            this.POId = params['pOID'] || '';
            this.orderName = params['orderName'] || '';
            this.contractID = params['contractID'] || '';
            this.vendorId = params['vendorID'] || '';
            this.type = params['type'] || 'in';

            this.reloadList(this.POId, this.orderName, this.contractID, this.vendorId, this.type, null);
        });
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.POId,this.orderName, this.contractID, this.vendorId, this.type, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    createPO() {
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