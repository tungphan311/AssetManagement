import { Component, ViewChild, ElementRef, Output, EventEmitter, Injector } from "@angular/core";
import { AppComponentBase } from "@shared/common/app-component-base";
import { ModalDirective } from "ngx-bootstrap";
import { Table } from "primeng/table";
import { Paginator, LazyLoadEvent } from "primeng/primeng";
import { MerchandiseServiceProxy, ContractDetailInput, ContractDetailServiceProxy } from "@shared/service-proxies/service-proxies";

@Component({
    selector: 'addContractDetailModal',
    templateUrl: './add-contract-detail-modal-component.html'
})

export class AddContractDetailModalComponent extends AppComponentBase {
    @ViewChild('addContractDetailModal') addContractModal: ModalDirective;
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

   merID: string
   merName: string
   typeID: number

   id = 0
   contractDetail: ContractDetailInput = new ContractDetailInput()

   listMerType = []
   listMerchandises = []
   listContractDetail = []

   savingId: boolean[] = []

   constructor(
       injector: Injector,
       private _merchandiseService: MerchandiseServiceProxy,
       private _contractDetailService: ContractDetailServiceProxy
   ) {
        super(injector);
   }

   getMerchandises(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        this.reloadList(null, null, 0, null);
   }

   test(id: number) {
       this.savingId[id - 1] = !this.savingId[id - 1];
   }

   reloadList(merID, merName, typeID, event: LazyLoadEvent) {
       this._merchandiseService.getMerchandiseByFilter(merID, 
            merName, typeID, 0, null, 
            this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.listMerchandises = result.items;
            this.primengTableHelper.hideLoadingIndicator();
            this.savingId.length = result.items.length;
            this.savingId.fill(false);
        });

        // for (const item of this.listContractDetail) {
        //     this._contractDetailService.deleteContractDetail(item.id).subscribe(result => {
        //         this.notify.info(this.l('SaveSuccessfully'));
        //     })
        // }
   }

   applyFilters(): void {
       this.reloadList(this.merID, this.merName, this.typeID, null);

       if (this.paginator.getPage() !== 0) {
           this.paginator.changePage(0);
           return;
       }
   }

   show(): void {
       this.saving = false;

       this._contractDetailService.getContractDetailsByFilter(0, null, 999, 0).subscribe(result => {
            this.listContractDetail = result.items;
        });

       this.addContractModal.show();
   }

   save(): void {
        this.saving = true;

        for (const iterator of this.listMerchandises) {
            if (this.savingId[this.id] == true) {
                this.contractDetail.merchID = iterator.id;
                this.contractDetail.merCode = iterator.code;
                this.contractDetail.merName = iterator.name;
                this.contractDetail.quantity = 1;
                this.contractDetail.price = iterator.price;
                this.contractDetail.note = "";
                this._contractDetailService.createOrEditContractDetail(this.contractDetail).subscribe(result => {
                    this.notify.info(this.l('SavedSuccessfully'));
                })
            }
            this.id = this.id + 1;
        }

        this.close()
    }

    close(): void {
        console.log(this.savingId);
        this.addContractModal.hide();
        this.modalSaves.emit(null);
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}