import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { MerchandiseInput, MerchandiseServiceProxy, ComboboxItemDto, MerchandiseTypeServiceProxy, VendorTypeServiceProxy, VendorServiceProxy } from '@shared/service-proxies/service-proxies';
import { Table } from 'primeng/components/table/table';
import { Paginator } from 'primeng/components/paginator/paginator';
import { LazyLoadEvent } from 'primeng/primeng';
import { WebApiServiceProxy } from '@shared/service-proxies/webapi.service';

@Component({
    selector: 'createOrEditMerchandiseModal',
    templateUrl: './create-or-edit-merchandise-modal.component.html'
})

export class CreateOrEditMerchandiseModalComponent extends AppComponentBase {
    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('merchandiseCombobox') merchandiseCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;

    /**
    * @Output dùng để public event cho component khác xử lý
    */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    merchandise: MerchandiseInput = new MerchandiseInput();

    merchandiseTypes = []
    typeVender = []

    constructor(
        injector: Injector,
        private _merchandiseService: MerchandiseServiceProxy,
        private _merTypeService: MerchandiseTypeServiceProxy,
        private _vendorService: VendorServiceProxy
    ) {
        super(injector);
    }

    show(merchandiseId?: number | null | undefined): void {
        this.saving = false;

        this._merchandiseService.getMerchandiseForEdit(merchandiseId).subscribe(result => {
            this.merchandise = result;
            this.modal.show();
        })

        this._merTypeService.getMerchandiseByFilter(null, null, null, null, 999, 0).subscribe(result => {
            this.merchandiseTypes = result.items
        })

        this._vendorService.getVendorsByFilter(null, null, 0, null, null, 999, 0).subscribe(result => {
            this.typeVender = result.items
        })
    }

    save(): void {
        let input = this.merchandise;
        this.saving = true;
        this._merchandiseService.createOrEditMerchandise(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
