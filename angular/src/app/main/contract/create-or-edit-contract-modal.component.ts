import { Component, Injector, ViewChild, ElementRef, Output, EventEmitter } from "@angular/core";
import { AppComponentBase } from "@shared/common/app-component-base";
import { ModalDirective } from "ngx-bootstrap";
import { Table } from "primeng/table";
import { Paginator, LazyLoadEvent } from "primeng/primeng";
import { ContractInput, ContractServiceProxy, ContractDetailServiceProxy, ProductInput } from "@shared/service-proxies/service-proxies";
import { AddContractDetailModalComponent } from "./add-contract-detail-modal-component";

@Component({
    selector: 'createOrEditContractModal',
    templateUrl: './create-or-edit-contract-modal.component.html',
    outputs: ['data:listMerchandises']
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
   id = 0;

   listContractDetail = []

    contract: ContractInput = new ContractInput();
    products: ProductInput[] = [];

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

            var moment = require('moment');
            var date = moment(result.deliveryTime);
            var tz = date.utcOffset();
            date.add(tz, 'm');
            this.contract.deliveryTime = date.format('YYYY-MM-DD');

            this.modal.show();
        })

        this.reloadListContractDetail(0, null);
    }

    getListMerchandises(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this.passToProducts();

        this.loadListMerchandise();
    }

    passToProducts() {
       // this.products.length = 0;

        this.addContractDetailModal.listMerID.forEach(element => {
            let input: ProductInput = new ProductInput();
            input.merchandiseID = element.id;
            input.merCode = element.code;
            input.merName = element.name;
            input.quantity = 1;
            input.price = element.price;
            input.total = input.quantity * input.price;
            input.note = "";

            this.products.push(input);
        });

        this.contract.products = this.products;
        console.log(this.contract.products);
    }

    loadListMerchandise() {
        this.primengTableHelper.totalRecordsCount = this.contract.products.length;
        this.primengTableHelper.records = this.contract.products;
        this.primengTableHelper.hideLoadingIndicator();
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
        // for (const item of this.listContractDetail) {
        //     this._contractDetailService.deleteContractDetail(item.id).subscribe(result => {
        //         //this.notify.info(this.l('SaveSuccessfully'));
        //     })
        // }
    }

    save(): void {
        let input = this.contract;
        var moment = require('moment');
        input.deliveryTime = moment(input.deliveryTime);
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