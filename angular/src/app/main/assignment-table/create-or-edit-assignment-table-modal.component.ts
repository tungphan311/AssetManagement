import { Component, Injector, ViewChild, ElementRef, Output, EventEmitter } from "@angular/core";
import { AppComponentBase } from "@shared/common/app-component-base";
import { ModalDirective } from "ngx-bootstrap";
import { AssignmentTableInput, AssignmentTableServiceProxy, VendorServiceProxy, MerchandiseServiceProxy } from "@shared/service-proxies/service-proxies";

@Component({
    selector: 'createOrEditAssignmentTableModal',
    templateUrl: './create-or-edit-assignment-table-modal.component.html'
})

export class CreateOrEditAssignmentTableModalComponent extends AppComponentBase {
    
    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('merchCombobox') merchCombobox: ElementRef;
    @ViewChild('vendorCombobox') vendorCombobox: ElementRef;
    
    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving=false;

    assignmentTable: AssignmentTableInput = new AssignmentTableInput();


    constructor(
        injector: Injector,
        private _assignmentTableService: AssignmentTableServiceProxy,
        private _vendorService: VendorServiceProxy,
        private _merchandiseService: MerchandiseServiceProxy
    ) {
        super(injector);
    }
    show(assignmentTableID?: number | null| undefined): void {
        this.saving=false;
        this._assignmentTableService.getAssignmentTableForEdit(assignmentTableID).subscribe(result => {
            this.assignmentTable = result;
            this.modal.show();
        })
        
    }

    save(): void {
        let input = this.assignmentTable;
        this.saving = true;
        this._assignmentTableService.createOrEditAssignmentTable(input).subscribe(result =>{
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })
    }
    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
