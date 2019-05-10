import { Component, ViewChild, Injector, ElementRef, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { DonViServiceProxy, DonViThemTaiSanInput } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { finalize } from 'rxjs/operators';

@Component({
    selector: 'themTaiSanModal',
    templateUrl: './ThemTaiSan-modal.component.html'
})
export class ThemTaiSanModalComponent extends AppComponentBase {

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    @ViewChild('modal') modal: ModalDirective;
    @ViewChild('taiSanThem') taiSanThem: ElementRef;

    input: DonViThemTaiSanInput = new DonViThemTaiSanInput();

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
        this.input = new DonViThemTaiSanInput();
        this.modal.show();
        this.input.tenDonVi = this.appSession.user.userName;
        if(this.appSession.user.userName == "admin")
            this.input.tenDonVi = "DonViChinh";
    }

    onShown(): void {
        this.taiSanThem.nativeElement.focus();
    }

    save(): void {
        this.saving = true;
        this._personService.themTaiSanVaoDonVi(this.input)
            .pipe(finalize(() => this.saving = false))
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
                this.modalSave.emit(this.input);
            });
    }

    close(): void {
        this.modal.hide();
        this.active = false;
    }
}