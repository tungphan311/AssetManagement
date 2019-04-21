import { Component, Output, EventEmitter, ViewChild, ElementRef, Injector } from "@angular/core";
import { AppComponentBase } from "@shared/common/app-component-base";
import { ModalDirective } from 'ngx-bootstrap';
import { finalize } from 'rxjs/operators';
import { MerchandiseControlllerServiceProxy, CreateMerchandiseInput } from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'createMerchandiseModal',
    templateUrl: './create-merchandise-modal.component.html'
})

export class CreateMerchandiseModalComponent extends AppComponentBase {
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    @ViewChild('modal') modal: ModalDirective;
    @ViewChild('nameInput') nameInput: ElementRef;

    merchandise: CreateMerchandiseInput = new CreateMerchandiseInput();

    active: boolean = false;
    saving: boolean = false;

    constructor(
        injector: Injector,
        private _merchandiseService: MerchandiseControlllerServiceProxy
    ) {
        super(injector);
    }

    show(): void {
        this.active = true;
        this.merchandise = new CreateMerchandiseInput();
        this.modal.show();
    }

    onShow(): void {
        this.nameInput.nativeElement.focus();
    }

    save(): void {
        this.saving = true;
        this._merchandiseService.createMerchandise(this.merchandise)
            .pipe(finalize(() => this.saving = false))
            .subscribe(() => {
                this.notify.info(this.l('SaveSuccessfully'));
                this.close();
                this.modalSave.emit(this.merchandise);
            })
    }

    close(): void {
        this.modal.hide();
        this.active = false;
    }
}