import { AppComponentBase } from "@shared/common/app-component-base";
import { Component, ViewChild, ElementRef, Output, EventEmitter, Injector } from "@angular/core";
import { ModalDirective } from "ngx-bootstrap";
import { MerchandiseTypeInput, MerchandiseTypeServiceProxy } from "@shared/service-proxies/service-proxies";

@Component({
    selector: 'createOrEditMerchandiseTypeModal',
    templateUrl: './create-or-edit-merchandise-type-modal.component.html'
})

export class CreateOrEditMerchandiseTypeModalComponent extends AppComponentBase {
    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('merchandiseTypeCombobox') merchandiseTypeCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    /**
    * @Output dùng để public event cho component khác xử lý
    */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    merchandiseType: MerchandiseTypeInput = new MerchandiseTypeInput();

    constructor(
        injector: Injector,
        private _merchandiseTypeService: MerchandiseTypeServiceProxy
    ) {
        super(injector);
    }

    show(merchandiseTypeId?: number | null | undefined): void {
        this.saving = false;

        this._merchandiseTypeService.getMerchandiseTypeForEdit(merchandiseTypeId).subscribe(result => {
            this.merchandiseType = result;
            this.modal.show();
        })
    }

    save(): void {
        let input = this.merchandiseType;
        this.saving = true;
        this._merchandiseTypeService.createOrEditMerchandiseType(input).subscribe(result => {
            this.notify.info(this.l('SavingSuccessfully'));
            this.close();
        })
    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}