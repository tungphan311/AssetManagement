import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { VendorTypeServiceProxy, VendorTypeInput } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditVendorTypeModal',
    templateUrl: './create-or-edit-vendortype-modal.component.html'
})
export class CreateOrEditVendorTypeModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('vendortypeCombobox') vendortypeCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    vendortype: VendorTypeInput = new VendorTypeInput();

    constructor(
        injector: Injector,
        private _vendortypeService: VendorTypeServiceProxy
    ) {
        super(injector);
    }

    show(vendortypeId?: number | null | undefined): void {
        this.saving = false;


        this._vendortypeService.getVendorTypeForEdit(vendortypeId).subscribe(result => {
            this.vendortype = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.vendortype;
        this.saving = true;
        this._vendortypeService.createOrEditVendorType(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
