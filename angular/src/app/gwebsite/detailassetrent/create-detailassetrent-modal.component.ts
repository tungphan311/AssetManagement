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
    DetailAssetRentServiceProxy,
    DetailAssetRentInput
} from "@shared/service-proxies/service-proxies";

@Component({
    selector: "createDetailAssetRentModal",
    templateUrl: "./create-detailassetrent-modal.component.html"
})
export class CreateDetailAssetRentModalComponent extends AppComponentBase {
    @ViewChild("createOrEditModal") modal: ModalDirective;
    @ViewChild("detailAssetRentCombobox") detailAssetRentCombobox: ElementRef;
    @ViewChild("iconCombobox") iconCombobox: ElementRef;
    @ViewChild("dateInput") dateInput: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    detailassetrent: DetailAssetRentInput = new DetailAssetRentInput();

    constructor(
        injector: Injector,
        private _detailAssetRentService: DetailAssetRentServiceProxy
    ) {
        super(injector);
    }

    // tslint:disable-next-line:use-life-cycle-interface
    ngAfterViewInit(): void {
        let t = this;
        $(this.dateInput.nativeElement)
            .datetimepicker({
                locale: abp.localization.currentLanguage.name,
                format: "L"
            })
            .on("dp.change", function(_e: any) {
                t.detailassetrent.dayPay = $(t.dateInput.nativeElement)
                    .val()
                    .toString();
            });
    }

    show(detailAssetRentId?: number | null | undefined): void {
        this.saving = false;

        this._detailAssetRentService
            .getDetailAssetRentForEdit(detailAssetRentId)
            .subscribe(result => {
                this.detailassetrent = result;
                this.modal.show();
            });
    }

    save(): void {
        let input = this.detailassetrent;
        this.saving = true;
        this._detailAssetRentService
            .createOrEditDetailAssetRent(input)
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
