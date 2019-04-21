import {
    AssetRentForView,
    AssetRentServiceProxy
} from "../../../shared/service-proxies/service-proxies";
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { ModalDirective } from "ngx-bootstrap";

@Component({
    selector: "viewAssetRentModal",
    templateUrl: "./view-assetrent-modal.component.html"
})
export class ViewAssetRentModalComponent extends AppComponentBase {
    assetRent: AssetRentForView = new AssetRentForView();
    @ViewChild("viewModal") modal: ModalDirective;

    constructor(
        injector: Injector,
        private _assetRentService: AssetRentServiceProxy
    ) {
        super(injector);
    }

    show(assetId?: number | null | undefined): void {
        this._assetRentService
            .getAssetRenttForView(assetId)
            .subscribe(result => {
                this.assetRent = result;
                this.modal.show();
            });
    }

    close(): void {
        this.modal.hide();
    }
}
