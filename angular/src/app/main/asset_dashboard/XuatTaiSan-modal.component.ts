import { Component, ViewChild, Injector, ElementRef, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { DonViServiceProxy, UnitXuatTaiSanInput, TaiSanDto, UnitTaiSanDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { finalize } from 'rxjs/operators';

@Component({
    selector: 'XuatTaiSanModal',
    templateUrl: './XuatTaiSan-modal.component.html'
})
export class XuatTaiSanModalComponent extends AppComponentBase {

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    @ViewChild('modal') modal: ModalDirective;
    @ViewChild('unitNhan') donViNhan: ElementRef;
    @ViewChild('taiSanXuat') taiSanXuat: ElementRef;

    input: UnitXuatTaiSanInput = null;
    unit: UnitTaiSanDto = null;
    unit_nhan: UnitTaiSanDto[] = null;
    tai_san_trong_kho: TaiSanDto[] = null;

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
        this.input = new UnitXuatTaiSanInput();
        this._Service.taiSanTheoTrangThai(unit.id, 0).subscribe(result => { this.tai_san_trong_kho = result });
        this._Service.getUnitCon(unit.code).subscribe(result => { this.unit_nhan = result; });
        this.input.unitXuatId = unit.id;
        this.modal.show();
    }

    save(): void {
        this.saving = true;
        this._Service.unitXuatTaiSan(this.input)
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