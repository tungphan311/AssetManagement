import { Component, ViewChild, Injector, ElementRef, Output, EventEmitter } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { DonViServiceProxy, CreateDonViInput, DonViDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/common/app-component-base';
import { finalize } from 'rxjs/operators';

@Component({
    selector: 'ThemDonViModal',
    templateUrl: './ThemDonVi-modal.component.html'
})
export class ThemDonViModalComponent extends AppComponentBase {

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    @ViewChild('modal') modal: ModalDirective;
    @ViewChild('ten_don_vi_input') ten_don_vi_input: ElementRef;

    don_vi_co_san: DonViDto[] = null;
    input: CreateDonViInput = null;

    active: boolean = false;
    saving: boolean = false;

    constructor(
        injector: Injector,
        private _Service: DonViServiceProxy
    ) {
        super(injector);
    }

    show(): void {
        this.active = true;
        this.input = new CreateDonViInput(); 
        this._Service.getDonVi("").subscribe(result => { this.don_vi_co_san = result; });
        this.modal.show();
    }

    save(): void {
        this.saving = true;
        this._Service.createDonVi(this.input)
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

    onShown(): void {
        this.ten_don_vi_input.nativeElement.focus();
    }

    close(): void {
        this.modal.hide();
        this.active = false;
    }
}