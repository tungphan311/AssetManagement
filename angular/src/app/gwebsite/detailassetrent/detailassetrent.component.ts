import { ViewDetailAssetRentModalComponent } from "./view-detailassetrent-modal.component";
import {
    AfterViewInit,
    Component,
    Injector,
    OnInit,
    ViewChild
} from "@angular/core";
import { ActivatedRoute, Params } from "@angular/router";
import { appModuleAnimation } from "@shared/animations/routerTransition";
import { AppComponentBase } from "@shared/common/app-component-base";
import * as _ from "lodash";
import { LazyLoadEvent } from "primeng/components/common/lazyloadevent";
import { Paginator } from "primeng/components/paginator/paginator";
import { Table } from "primeng/components/table/table";
import { DetailAssetRentServiceProxy } from "@shared/service-proxies/service-proxies";
import { CreateDetailAssetRentModalComponent } from "./create-detailassetrent-modal.component";
@Component({
    templateUrl: "./detailassetrent.component.html",
    animations: [appModuleAnimation()]
})
export class DetailAssetRentComponent extends AppComponentBase
    implements AfterViewInit, OnInit {
    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild("dataTable") dataTable: Table;
    @ViewChild("paginator") paginator: Paginator;
    @ViewChild("createOrEditModal")
    createOrEditModal: CreateDetailAssetRentModalComponent;
    @ViewChild("viewDetailAssetRentModal")
    viewAssetModal: ViewDetailAssetRentModalComponent;

    /**
     * tạo các biến dể filters
     */
    nameAsset: string;
    rentBy: string;

    constructor(
        injector: Injector,
        private _detailAssetRentService: DetailAssetRentServiceProxy,
        private _activatedRoute: ActivatedRoute
    ) {
        super(injector);
    }

    /**
     * Hàm xử lý trước khi View được init
     */
    ngOnInit(): void {}

    /**
     * Hàm xử lý sau khi View được init
     */
    ngAfterViewInit(): void {
        setTimeout(() => {
            this.init();
        });
    }

    /**
     * Hàm get danh sách DetailAssetRent
     * @param event
     */
    getDetailAsssetsRent(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null, event);
    }

    reloadList(nameAsset, rentBy, event?: LazyLoadEvent) {
        this._detailAssetRentService
            .getDetailAssetRentByFilter(
                nameAsset,
                rentBy,
                this.primengTableHelper.getSorting(this.dataTable),
                this.primengTableHelper.getMaxResultCount(
                    this.paginator,
                    event
                ),
                this.primengTableHelper.getSkipCount(this.paginator, event)
            )
            .subscribe(result => {
                this.primengTableHelper.totalRecordsCount = result.totalCount;
                this.primengTableHelper.records = result.items;
                this.primengTableHelper.hideLoadingIndicator();
            });
    }

    deleteDetailAssetRent(id: number): void {
        this._detailAssetRentService.deleteDetailAssetRent(id).subscribe(() => {
            this.reloadPage();
        });
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.nameAsset = params["nameAsset"] || "";
            this.reloadList(this.nameAsset, null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.nameAsset, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    //hàm show view create MenuClient
    createDetailAssetRent() {
        this.createOrEditModal.show();
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, "...");
    }
}
