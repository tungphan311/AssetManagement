import { Component, ViewChild, Injector, ElementRef, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { DonViServiceProxy, DonViXuatTaiSanInput } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { finalize } from 'rxjs/operators';

@Component({
    selector: 'XuatTaiSanModal',
    templateUrl: './XuatTaiSan-modal.component.html'
})
export class XuatTaiSanModalComponent extends AppComponentBase {

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    @ViewChild('modal') modal: ModalDirective;

    input: DonViXuatTaiSanInput = new DonViXuatTaiSanInput();

    active: boolean = false;
    saving: boolean = false;

    constructor(
        injector: Injector,
        private _personService: DonViServiceProxy
    ) {
        super(injector);
    }

    show(): void {
        this.active = true;
        this.input = new DonViXuatTaiSanInput();
        this.modal.show();
        this.input.donViXuat = this.appSession.user.userName;
        if(this.appSession.user.userName == "admin")
            this.input.donViXuat = "DonViChinh";
        this.input.donViNhan = "donvi1";
    }

    onShown(): void {
    }

    save(): void {
        this.saving = true;
        this._personService.donViXuatTaiSan(this.input)
            .pipe(finalize(() => this.saving = false))
            .subscribe((result) => {
                if(result == true)
                    this.notify.info(this.l('SavedSuccessfully'));
                else
                    this.notify.error(this.l('FAILED'));
                this.close();
                this.modalSave.emit(this.input);
            });
    }

    close(): void {
        this.modal.hide();
        this.active = false;
    }
}