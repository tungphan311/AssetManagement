import {
    DetailAssetRentForView,
    DetailAssetRentServiceProxy
} from "../../../shared/service-proxies/service-proxies";
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { ModalDirective } from "ngx-bootstrap";

@Component({
    selector: "viewDetailAssetRentModal",
    templateUrl: "./view-detailassetrent-modal.component.html"
})
export class ViewDetailAssetRentModalComponent extends AppComponentBase {
    detailAssetRent: DetailAssetRentForView = new DetailAssetRentForView();
    @ViewChild("viewModal") modal: ModalDirective;

    constructor(
        injector: Injector,
        private _detailAssetRentService: DetailAssetRentServiceProxy
    ) {
        super(injector);
    }

    show(detailAssetRentId?: number | null | undefined): void {
        this._detailAssetRentService
            .getDetailAssetRenttForView(detailAssetRentId)
            .subscribe(result => {
                this.detailAssetRent = result;
                this.modal.show();
            });
    }

    close(): void {
        this.modal.hide();
    }
}
