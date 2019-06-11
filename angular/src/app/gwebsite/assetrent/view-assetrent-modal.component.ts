import {
    AssetRentServiceProxy,
    DetailAssetRentForView,
    DetailAssetRentServiceProxy,
    DetailAssetRentInput
} from "../../../shared/service-proxies/service-proxies";
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { ModalDirective } from "ngx-bootstrap";
import { LazyLoadEvent, Paginator } from "primeng/primeng";
import { Table } from "primeng/components/table/table";
import { CreateDetailAssetRentModalComponent } from "./create-detailassetrent-modal.component";

@Component({
    selector: "viewAssetRentModal",
    templateUrl: "./view-assetrent-modal.component.html"
})
export class ViewAssetRentModalComponent extends AppComponentBase {
    @ViewChild("dataTable") dataTable: Table;
    @ViewChild("paginator") paginator: Paginator;
    @ViewChild("viewModal") modal: ModalDirective;
    @ViewChild("createOrEditModal")
    createOrEditModal: CreateDetailAssetRentModalComponent;

    constructor(
        injector: Injector,
        private _assetRentService: AssetRentServiceProxy,
        private _detailAssetRentService: DetailAssetRentServiceProxy
    ) {
        super(injector);
    }
    id: number;
    reloadList(assetRentId, event?: LazyLoadEvent) {
        this._detailAssetRentService
            .getDetailAssetRentByFilterId(
                assetRentId,
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
        this._detailAssetRentService
            .deleteDetailAssetRent(id)
            .subscribe(() => this.reloadPage());
    }

    show(assetRentId?: number | null | undefined): void {
        this.id = assetRentId;
        console.log(this.id);
        this.reloadList(assetRentId, null);
        this.modal.show();
    }
    createDetailAssetRent(): void {
        this.createOrEditModal.show(this.id);
    }

    reloadPage(): void {
        this.reloadList(this.id, null);
        this.modal.show();
    }
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, "...");
    }
    close(): void {
        this.modal.hide();
    }
}
