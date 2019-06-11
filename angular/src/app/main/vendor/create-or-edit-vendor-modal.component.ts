import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { VendorServiceProxy, VendorInput, VendorTypeServiceProxy } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditVendorModal',
    templateUrl: './create-or-edit-vendor-modal.component.html'
})
export class CreateOrEditVendorModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('vendorCombobox') vendorCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    vendor: VendorInput = new VendorInput();

    vendortypeList: any[];

    constructor(
        injector: Injector,
        private _vendorService: VendorServiceProxy,
        private _vendortypeService: VendorTypeServiceProxy

    ) {
        super(injector);
    }

    show(vendorId?: number | null | undefined): void {
        this.saving = false;

        //load list vendortype
        this._vendortypeService.getVendorTypesByFilter(null, null, null, null, 99, 0,
        ).subscribe(result => {
            this.vendortypeList = result.items;
        });
        this.vendor.typeID = 0;
        this._vendorService.getVendorForEdit(vendorId).subscribe(result => {
            this.vendor = result;
            if (this.vendor.typeID==null||this.vendor.typeID==undefined)
                this.vendor.typeID=0;
            this.modal.show();
        })
    }

    save(): void {
        let input = this.vendor;
        input.merchandises = [];
        this.saving = true;
        this._vendorService.createOrEditVendor(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
