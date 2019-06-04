import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { TSThueServiceProxy, TSThueInput } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditTSThueModal',
    templateUrl: './create-or-edit-tsthue-modal.component.html'
})
export class CreateOrEditTSThueModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('tsthueCombobox') tsthueCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    tsthue: TSThueInput = new TSThueInput();

    constructor(
        injector: Injector,
        private _tsthueService: TSThueServiceProxy
    ) {
        super(injector);
    }

    show(tsthueId?: number | null | undefined): void {
        this.saving = false;


        this._tsthueService.getTSThueForEdit(tsthueId).subscribe(result => {
            this.tsthue = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.tsthue;
        this.saving = true;
        this._tsthueService.createOrEditTSThue(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
