import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { AttachedDeviceServiceProxy, AttachedDeviceInput } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditAttachedDeviceModal',
    templateUrl: './create-or-edit-attacheddevice-modal.component.html'
})
export class CreateOrEditAttachedDeviceModalComponent extends AppComponentBase {


    @ViewChild('createOrEditAttachedDeviceModal') modal: ModalDirective;
    @ViewChild('attachedDeviceCombobox') attachedDeviceCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    attachedDevice: AttachedDeviceInput = new AttachedDeviceInput();

    constructor(
        injector: Injector,
        private _attachedDeviceService: AttachedDeviceServiceProxy
    ) {
        super(injector);
    }

    show(attachedDeviceId?: number | null | undefined, plateNumber?: string | null | undefined): void {
        this.saving = false;

        this._attachedDeviceService.getAttachedDeviceForEdit(attachedDeviceId).subscribe(result => {
            this.attachedDevice = result;
            this.attachedDevice.plateNumber = plateNumber;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.attachedDevice;
        this.saving = true;
        this._attachedDeviceService.createOrEditAttachedDevice(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
