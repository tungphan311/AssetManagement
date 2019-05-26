import { Component, Injector, ViewChild } from "@angular/core";
import { AppComponentBase } from "@shared/common/app-component-base";
import { MerchandiseServiceProxy, VendorServiceProxy, AssignmentTableServiceProxy, AssignmentTableForViewDto } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from "ngx-bootstrap";

@Component({
    selector: 'viewAssignmentTableModal',
    templateUrl: './view-assignment-table-modal.component.html'
})

export class ViewAssignmentTableModalComponent extends AppComponentBase {

    assignmentTable : AssignmentTableForViewDto = new AssignmentTableForViewDto();
    @ViewChild('viewAssignmentModal') modal: ModalDirective;

    vendorlist=[];
    merchlist=[];


    constructor(
        injector: Injector,
        private _merchandiseService: MerchandiseServiceProxy,
        private _vendorService: VendorServiceProxy,
        private _assignmentTableService: AssignmentTableServiceProxy
    ) {
        super(injector);
    }
    show(assignmentTableID?: number | null | undefined): void {
        this._assignmentTableService.getAssignmentTableForEdit(assignmentTableID).subscribe(result => {
            this.assignmentTable = result;
            this.modal.show();
        })

        this._merchandiseService.getMerchandiseByFilter(null,null,0,0,null,null,99,0).subscribe(result => {
            this.merchlist=result.items
        })
        this._vendorService.getVendorsByFilter(null,null,0,null,null,99,0).subscribe(result =>{
            this.vendorlist=result.items
        })
    }

    getMerchName(id: number): any {
        for (const iterator of this.merchlist) {
            if (iterator.id === id) {
                return iterator.name;
            }
        }
    }

    getVendorName(id: number): any {
        for (const iterator of this.vendorlist) {
            if (iterator.id == id) {
                return iterator.name;
            }
        }
    }
    close() : void{
        this.modal.hide();
    }
}
