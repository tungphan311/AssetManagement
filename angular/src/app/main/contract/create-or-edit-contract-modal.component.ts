import { Component, Injector, ViewChild, ElementRef, Output, EventEmitter } from "@angular/core";
import { AppComponentBase } from "@shared/common/app-component-base";
import { ModalDirective } from "ngx-bootstrap";
import { Table } from "primeng/table";
import { Paginator, LazyLoadEvent } from "primeng/primeng";
import { ContractInput, ContractServiceProxy, ContractDetailServiceProxy, BidServiceProxy, BidForViewDto, VendorServiceProxy, VendorForViewDto, ContractDetailInput, ContractDetailDto } from "@shared/service-proxies/service-proxies";
import { AddContractDetailModalComponent } from "./add-contract-detail-modal-component";
import { SelectBidModalComponent } from "./select-bid-modal.component";
import { HttpClient, HttpRequest, HttpEventType } from "@angular/common/http";

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
    @ViewChild('selectBidModal') selectBidModal: SelectBidModalComponent;

    /**
    * @Output dùng để public event cho component khác xử lý
    */
   @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

   saving = false;
   contractId?: number | null | undefined;
   bidName: string;
   bidderId: number;
   bidderCode: string;
   bidderName: string;
   bidderPhone: string;
   bidderAddress: string;
   bidderContact: string;

   progress: number;
   mess: string;

   totalPrice = 0;

   fileToUpLoad: File = null;
   
   listContractDetail = [];
   listMerchandiseID: number[] = [];

    contract: ContractInput = new ContractInput();
    products: ContractDetailInput[] = [];
    contractDetails: ContractDetailDto[] = [];

    constructor(
        injector: Injector,
        private _contractService: ContractServiceProxy,
        private _contractDetailService: ContractDetailServiceProxy,
        private _bidService: BidServiceProxy,
        private _vendorService: VendorServiceProxy,
        private http: HttpClient
    ) {
        super(injector);
    }

    show(contractId?: number | null | undefined): void {
        this.saving = false;
        this.contractId = contractId;

        this._contractService.getContractForEdit(contractId).subscribe(result => {
            this.contract = result;

            if (contractId == null || contractId == undefined) {
                this.contract.products = [];
            }

            var moment = require('moment');
            var date = moment(result.deliveryTime);
            var tz = date.utcOffset();
            date.add(tz, 'm');
            this.contract.deliveryTime = date.format('YYYY-MM-DD');

            var moment2 = require('moment');
            var contractWarrantyExpireDate = moment2(result.contractWarrantyExpireDate);
            var tz = contractWarrantyExpireDate.utcOffset();
            contractWarrantyExpireDate.add(tz, 'm');
            this.contract.contractWarrantyExpireDate = contractWarrantyExpireDate.format('YYYY-MM-DD');

            var moment3 = require('moment');
            var warrantyGuaranteeExpireDate = moment3(result.warrantyGuaranteeExpireDate);
            var tz = warrantyGuaranteeExpireDate.utcOffset();
            warrantyGuaranteeExpireDate.add(tz, 'm');
            this.contract.warrantyGuaranteeExpireDate = warrantyGuaranteeExpireDate.format('YYYY-MM-DD');

            this.reloadBid(result.briefcaseID);

            this.modal.show();
        })

        this.reloadListContractDetail(contractId, null);
    }

    upload(files) {
        if (files.length == 0) {
            return;
        }

        const formData = new FormData();

        for (let file of files) {
            formData.append(file.name, file);
        }

        const uploadReq = new HttpRequest('POST', `api/upload`, formData, {
            reportProgress: true,
        });

        this.http.request(uploadReq).subscribe(event => {
            if (event.type === HttpEventType.UploadProgress) {
                this.progress = Math.round(100 * event.loaded / event.total);
            }
            else if (event.type === HttpEventType.Response) {
                this.mess = event.body.toString();
            }
        });
    }

    getListMerchandises() {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this.passToProducts();

        this.loadListMerchandise();
    }

    passToProducts() {
        console.log(this.contract.products);
        this.addContractDetailModal.listMerID.forEach(element => {
            let input: ContractDetailInput = new ContractDetailInput();
            input.merchID = element.id;
            input.merCode = element.code;
            input.merName = element.name;
            input.quantity = 1;
            input.price = element.price;
            //input.total = input.quantity * input.price;
            input.note = "";

            this.contract.products.push(input);
        });

        this.addContractDetailModal.listMerID.length = 0;
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

        this.reloadListContractDetail(this.contractId, event);
    }   

    reloadListContractDetail(contractDetailID, event: LazyLoadEvent) {
        this._contractDetailService.getContractDetailsByFilter(contractDetailID,
            this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.items.length;
            this.primengTableHelper.records = result.items;
            this.contractDetails = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        })
    }

    addContractDetail() {
        this.addContractDetailModal.show();
    }

    save(): void {
        let input = this.contract;
        input.products = this.primengTableHelper.records;
        
        var moment = require('moment');
        input.deliveryTime = moment(input.deliveryTime);
        input.contractWarrantyExpireDate = moment(input.contractWarrantyExpireDate);
        input.warrantyGuaranteeExpireDate = moment(input.warrantyGuaranteeExpireDate);

        this.saving = true;

        this.addContractDetailModal.listMerchandises.forEach(item => {
            item.isAddContract = false;
        })
        
        this.addContractDetailModal.isSelectAll = false;

        this.emptyField();

        this._contractService.createOrEditContract(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })
    }
    
    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    reloadBid(bidId: number): void {
        if (bidId != 0){
            this.contract.briefcaseID = bidId;
             
            this._bidService.getBidForView(bidId).subscribe(result => {
                this.bidName = result.name;
                this.bidderId = result.bidderID;

                this._vendorService.getVendorForView(result.bidderID).subscribe(vendor => {
                    this.bidderCode = vendor.code;
                    this.bidderName = vendor.name;
                    this.bidderPhone = vendor.phoneNumber;
                    this.bidderAddress = vendor.address;
                    this.bidderContact = vendor.contact;
                });
            });     
        }
        else
        {
            this.emptyField();
        }
    }

    emptyField(): void {
        this.bidName = "";
        this.bidderCode = "";
        this.bidderName = "";
        this.bidderPhone = "";
        this.bidderAddress = "";
        this.bidderContact = "";
    }

    // isExist(id: number): boolean {
    //     this.contractDetails.forEach(item => {
    //         if (item.merchID == id) {
    //             return true;
    //         }
    //     })

    //     return false;
    // }

    // deleteContract(id: number) {
    //     // this.addContractDetailModal.listMerID = this.addContractDetailModal.listMerID.filter(x => x.id != id);
    //         this.contract.products = this.contract.products.filter(x => x.id != id);
    //         this.loadListMerchandise();  
    // }

    handleFileInput(files: FileList) {
        this.fileToUpLoad = files.item(0);
    }

    close(): void {
        this.emptyField();
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