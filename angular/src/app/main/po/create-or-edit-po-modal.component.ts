import { Component, ViewChild, ElementRef, Output, EventEmitter, Injector } from "@angular/core";
import { AppComponentBase } from "@shared/common/app-component-base";
import { ModalDirective } from "ngx-bootstrap";
import { Table } from "primeng/table";
import { Paginator } from "primeng/primeng";
import { POServiceProxy, POInput } from "@shared/service-proxies/service-proxies";


@Component({
    selector: 'createOrEditPOModal',
    templateUrl: './create-or-edit-po-modal.component.html'
})

export class CreateOrEditPOModalComponent extends AppComponentBase {
    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('merchandiseCombobox') merchandiseCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;
    po: POInput = new POInput();

    constructor(
        injector: Injector,
        private _poService: POServiceProxy
    ) {
        super(injector);
    }

    show(id?: number | null | undefined): void {
        this.saving = false;

        this._poService.getPOForEdit(id).subscribe(result => {
            this.po = result;
            this.modal.show();
        })
    }
}