import { Component, ViewChild, Injector, ElementRef, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { DonViServiceProxy, DonViDto, TaiSanDto} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { finalize } from 'rxjs/operators';

@Component({
    selector: 'ChiTietDonViModal',
    templateUrl: './ChiTietDonVi-modal.component.html'
})
export class ChiTietDonViModalComponent extends AppComponentBase {

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
    @ViewChild('modal') modal: ModalDirective;

    donvi: DonViDto = new DonViDto();

    tai_san_hu_hong: TaiSanDto[] = [];
    tai_san_su_dung: TaiSanDto[] = [];
    tai_san_trong_kho: TaiSanDto[] = [];

    active: boolean = false;
    saving: boolean = false;

    constructor(
        injector: Injector,
        private _personService: DonViServiceProxy
    ) {
        super(injector);
    }

    show(don_vi): void {
        this.active = true;
        this.donvi = don_vi;
        this._personService.taiSanSuDung(don_vi.id).subscribe(result => { this.tai_san_su_dung = result});
        this._personService.taiSanTrongKho(don_vi.id).subscribe(result => { this.tai_san_trong_kho = result});
        this.modal.show();
        // if(this.appSession.user.userName == "admin")
        //     this.input.tenDonVi = "DonViChinh";
    }

    close(): void {
        this.modal.hide();
        this.active = false;
    }
}