import {
    Component,
    ElementRef,
    EventEmitter,
    Injector,
    Output,
    ViewChild
} from "@angular/core";
import { AppComponentBase } from "@shared/common/app-component-base";
import { ModalDirective } from "ngx-bootstrap";
import {
    AssetRentServiceProxy,
    AssetRentInput
} from "@shared/service-proxies/service-proxies";

@Component({
    selector: "createAssetRentModal",
    templateUrl: "./create-assetrent-modal.component.html"
})
export class CreateAssetRentModalComponent extends AppComponentBase {
    @ViewChild("createOrEditModal") modal: ModalDirective;
    @ViewChild("assetRentCombobox") assetRentCombobox: ElementRef;
    @ViewChild("iconCombobox") iconCombobox: ElementRef;
    @ViewChild("dateInput") dateInput: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    assetrent: AssetRentInput = new AssetRentInput();

    constructor(
        injector: Injector,
        private _assetRentService: AssetRentServiceProxy
    ) {
        super(injector);
    }

    show(assetRentId?: number | null | undefined): void {
        this.saving = false;

        this._assetRentService
            .getAssetRentForEdit(assetRentId)
            .subscribe(result => {
                this.assetrent = result;
                this.modal.show();
            });
    }

    save(): void {
        let input = this.assetrent;
        this.saving = true;
        this._assetRentService
            .createOrEditAssetRent(input)
            .subscribe(result => {
                this.notify.info(this.l("SavedSuccessfully"));
                this.close();
            });
    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
