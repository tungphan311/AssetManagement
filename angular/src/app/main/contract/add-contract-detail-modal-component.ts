import { Component, ViewChild, ElementRef, Output, EventEmitter, Injector } from "@angular/core";
import { AppComponentBase } from "@shared/common/app-component-base";
import { ModalDirective } from "ngx-bootstrap";
import { Table } from "primeng/table";
import { Paginator } from "primeng/primeng";

@Component({
    selector: 'addContractDetailModal',
    templateUrl: './add-contract-detail-modal-component.html'
})

export class AddContractDetailModalComponent extends AppComponentBase {
    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('contractCombobox') contractCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;

    /**
    * @Output dùng để public event cho component khác xử lý
    */
   @Output() modalSaves: EventEmitter<any> = new EventEmitter<any>();

   saving = false;

   constructor(
       injector: Injector
   ) {
        super(injector);
   }

   show(): void {
       this.saving = false;
       this.modal.show();
   }

   save(): void {
        this.saving = true;
        
        this.close()
    }

    close(): void {
        this.modal.hide();
        this.modalSaves.emit(null);
    }
}