import {
    Component,
    ElementRef,
    EventEmitter,
    Injector,
    Output,
    ViewChild,
    OnInit
} from "@angular/core";
import { AppComponentBase } from "@shared/common/app-component-base";
import { ModalDirective } from "ngx-bootstrap";
import {
    AssetRentServiceProxy,
    AssetRentInput,
    CustomerServiceProxy,
    CustomerDto,
    AssetServiceProxy,
    AssetDto
} from "@shared/service-proxies/service-proxies";

@Component({
    selector: "createAssetRentModal",
    templateUrl: "./create-assetrent-modal.component.html"
})
export class CreateAssetRentModalComponent extends AppComponentBase
    implements OnInit {
    @ViewChild("createOrEditModal") modal: ModalDirective;
    @ViewChild("assetRentCombobox") assetRentCombobox: ElementRef;
    @ViewChild("iconCombobox") iconCombobox: ElementRef;
    @ViewChild("dateInput") dateInput: ElementRef;

    customers: CustomerDto[];
    assets: AssetDto[];

    /**
     * @Output dùng để publicHZFZ event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    assetrent: AssetRentInput = new AssetRentInput();

    ngOnInit(): void {
        this._customerService
            .getCustomersByFilter(null, null, 1000, 0)
            .subscribe(response => {
                this.customers = response.items;
            });
        this._assetService
            .getAssetByFilter(null, null, 1000, 0)
            .subscribe(response => {
                this.assets = response.items;
            });
    }

    constructor(
        injector: Injector,
        private _assetRentService: AssetRentServiceProxy,
        private _customerService: CustomerServiceProxy,
        private _assetService: AssetServiceProxy
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
            .on("dp.change", function(e) {
                t.assetrent.dateRent = $(t.dateInput.nativeElement)
                    .val()
                    .toString();
            });
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
