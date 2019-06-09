import { Component, Injector, ViewChild } from "@angular/core";
import { AppComponentBase } from "@shared/common/app-component-base";
import { ContractForViewDto, ContractServiceProxy, BidServiceProxy, VendorServiceProxy, ContractDetailServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from "ngx-bootstrap";
import { LazyLoadEvent, Paginator } from "primeng/primeng";
import { Table } from "primeng/table";

@Component({
    selector: 'viewContractModal',
    templateUrl: './view-contract-modal.component.html'
})

export class ViewContractModalComponent extends AppComponentBase {
    contract: ContractForViewDto = new ContractForViewDto();
    contractId: number;

    @ViewChild('viewModal') modal: ModalDirective;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;


    bidName: string;
    bidderId: number;
    bidderCode: string;
    bidderName: string;
    bidderPhone: string;
    bidderAddress: string;
    bidderContact: string;

    constructor(
        injector: Injector,
        private _contractService: ContractServiceProxy,
        private _bidService: BidServiceProxy,
        private _vendorService: VendorServiceProxy,
        private _contractDetailService: ContractDetailServiceProxy
    ) {
        super(injector);
    }

    show(contractId: number | null | undefined): void {
        this.contractId = contractId;

        this._contractService.getContractForView(contractId).subscribe(result => {
            this.contract = result;
            this.reloadListContractDetail(contractId, null);
            this._bidService.getBidForView(result.briefcaseID).subscribe(bid => {
                this.bidName = bid.name;
                this.bidderId = bid.bidderID;
    
                this._vendorService.getVendorForView(bid.bidderID).subscribe(vendor => {
                    this.bidderCode = vendor.code;
                    this.bidderName = vendor.name;
                    this.bidderPhone = vendor.phoneNumber;
                    this.bidderAddress = vendor.address;
                    this.bidderContact = vendor.contact;
                });
            });
            this.modal.show();
        })     
    }

    getContractDetails(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        this.primengTableHelper.showLoadingIndicator();


        this.reloadListContractDetail(this.contractId, event);
    }

    reloadListContractDetail(contractDetailID, event: LazyLoadEvent) {
        this._contractDetailService.getContractDetailsByFilter(contractDetailID,
            this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            console.log(result.items);
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        })
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }

    close() : void{
        this.modal.hide();
    }
}