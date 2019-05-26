import { Component, ViewChild, Injector, ElementRef, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { DonViServiceProxy, UnitThemTaiSanInput, UnitTaiSanDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { finalize } from 'rxjs/operators';

@Component({
    selector: 'ThemTaiSanModal',
    templateUrl: './ThemTaiSan-modal.component.html'
})
export class ThemTaiSanModalComponent extends AppComponentBase {

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    @ViewChild('modal') modal: ModalDirective;
    @ViewChild('ten_tai_san_them') ten_tai_san_them: ElementRef;

    input: UnitThemTaiSanInput = new UnitThemTaiSanInput();
    unit: UnitTaiSanDto = new UnitTaiSanDto();

    active: boolean = false;
    saving: boolean = false;

    constructor(
        injector: Injector,
        private _Service: DonViServiceProxy
    ) {
        super(injector);
    }

    show(unit): void {
        this.active = true;
        this.unit = unit;
        this.input.unitId = this.unit.id;
        this.input.tenTaiSanThem = "";
        this.modal.show();
        
        // if(this.appSession.user.userName == "admin")
        //     this.input.tenDonVi = "DonViChinh";
    }

    onShown(): void {
        this.ten_tai_san_them.nativeElement.focus();
    }

    save(): void {
        this.saving = true;
        this._Service.unitThemTaiSan(this.input)
            .pipe(finalize(() => this.saving = false))
            .subscribe(result => {
                if(result)
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