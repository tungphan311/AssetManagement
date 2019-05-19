import { Component, ViewChild, Injector, ElementRef, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { DonViServiceProxy, DonViXuatTaiSanInput, TaiSanDto, DonViDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { finalize } from 'rxjs/operators';

@Component({
    selector: 'XuatTaiSanModal',
    templateUrl: './XuatTaiSan-modal.component.html'
})
export class XuatTaiSanModalComponent extends AppComponentBase {

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    @ViewChild('modal') modal: ModalDirective;
    @ViewChild('donViNhan') donViNhan: ElementRef;
    @ViewChild('taiSanXuat') taiSanXuat: ElementRef;

    input: DonViXuatTaiSanInput = null;
    don_vi_nhan: DonViDto[] = null;
    tai_san_trong_kho: TaiSanDto[] = null;

    active: boolean = false;
    saving: boolean = false;

    constructor(
        injector: Injector,
        private _Service: DonViServiceProxy
    ) {
        super(injector);
    }

    show(don_vi): void {
        this.active = true;
        this.input = new DonViXuatTaiSanInput();
        this._Service.taiSanTrongKho(don_vi.id).subscribe(result => { this.tai_san_trong_kho = result });
        this._Service.getDonViCon(don_vi.id).subscribe(result => { this.don_vi_nhan = result; this.don_vi_nhan.splice(0, 0, don_vi); });
        this.input.donViXuatId = don_vi.id;
        this.modal.show();
    }

    save(): void {
        this.saving = true;
        this._Service.donViXuatTaiSan(this.input)
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