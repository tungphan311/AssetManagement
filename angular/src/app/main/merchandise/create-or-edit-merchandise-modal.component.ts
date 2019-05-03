import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { MerchandiseInput, MerchandiseServiceProxy } from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'createOrEditMerchandiseModal',
    templateUrl: './create-or-edit-merchandise-modal.component.html'
})

export class CreateOrEditMerchandiseModalComponent extends AppComponentBase {
    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('merchandiseCombobox') merchandiseCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    /**
    * @Output dùng để public event cho component khác xử lý
    */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    merchandise: MerchandiseInput = new MerchandiseInput();

    constructor(
        injector: Injector,
        private _merchandiseService: MerchandiseServiceProxy
    ) {
        super(injector);
    }

    show(merchandiseId?: number | null | undefined): void {
        this.saving = false;

        this._merchandiseService.getMerchandiseForEdit(merchandiseId).subscribe(result => {
            this.merchandise = result;
            this.modal.show();
        })
    }

    save(): void {
        let input = this.merchandise;
        this.saving = true;
        this._merchandiseService.createOrEditMerchandise(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}