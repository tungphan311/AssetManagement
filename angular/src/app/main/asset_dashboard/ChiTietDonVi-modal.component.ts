import { Component, ViewChild, Injector, ElementRef, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { DonViServiceProxy, UnitTaiSanDto, TaiSanDto} from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { finalize } from 'rxjs/operators';

@Component({
    selector: 'ChiTietDonViModal',
    templateUrl: './ChiTietDonVi-modal.component.html'
})
export class ChiTietDonViModalComponent extends AppComponentBase {

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
    @ViewChild('modal') modal: ModalDirective;

    unit: UnitTaiSanDto = new UnitTaiSanDto();

    tai_san_hu_hong: TaiSanDto[] = [];
    tai_san_su_dung: TaiSanDto[] = [];
    tai_san_trong_kho: TaiSanDto[] = [];

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
        this._Service.taiSanTheoTrangThai(unit.id, 1).subscribe(result => { this.tai_san_su_dung = result });
        this._Service.taiSanTheoTrangThai(unit.id, 0).subscribe(result => { this.tai_san_trong_kho = result });
        this.modal.show();
        // if(this.appSession.user.userName == "admin")
        //     this.input.tenDonVi = "DonViChinh";
    }

    close(): void {
        this.modal.hide();
        this.active = false;
    }
}