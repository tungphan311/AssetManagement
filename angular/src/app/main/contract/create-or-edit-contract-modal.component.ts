import { Component, Injector, ViewChild, ElementRef, Output, EventEmitter } from "@angular/core";
import { AppComponentBase } from "@shared/common/app-component-base";
import { ModalDirective } from "ngx-bootstrap";
import { Table } from "primeng/table";
import { Paginator, LazyLoadEvent } from "primeng/primeng";
import { ContractInput, ContractServiceProxy, ContractDetailServiceProxy } from "@shared/service-proxies/service-proxies";
import { AddContractDetailModalComponent } from "./add-contract-detail-modal-component";

@Component({
    selector: 'createOrEditContractModal',
    templateUrl: './create-or-edit-contract-modal.component.html'
})

export class CreateOrEditContractModalComponent extends AppComponentBase {
    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('contractCombobox') contractCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('addContractDetailModal') addContractDetailModal: AddContractDetailModalComponent;

    /**
    * @Output dùng để public event cho component khác xử lý
    */
   @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

   saving = false;

   listContractDetail = []

    contract: ContractInput = new ContractInput();

    constructor(
        injector: Injector,
        private _contractService: ContractServiceProxy,
        private _contractDetailService: ContractDetailServiceProxy
    ) {
        super(injector);
    }

    show(contractId?: number | null | undefined): void {
        this.saving = false;

        this._contractService.getContractForEdit(contractId).subscribe(result => {
            this.contract = result;
            this.modal.show();
        })

        this.reloadListContractDetail(0, null);
    }

    getContractDetails(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this.reloadListContractDetail(0, event);
    }   

    reloadListContractDetail(contractDetailID, event: LazyLoadEvent) {
        this._contractDetailService.getContractDetailsByFilter(contractDetailID,
            this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        })
    }

    addContractDetail() {
        this.addContractDetailModal.show();
    }

    save(): void {
        let input = this.contract;
        this.saving = true;
        this._contractService.createOrEditContract(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })
    }
    
    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}