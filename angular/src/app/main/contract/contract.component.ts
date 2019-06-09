import { Component, Injector, ViewChild, AfterViewInit, OnInit } from "@angular/core";
import { appModuleAnimation } from "@shared/animations/routerTransition";
import { AppComponentBase } from "@shared/common/app-component-base";
import { Table } from "primeng/table";
import { Paginator, LazyLoadEvent } from "primeng/primeng";
import { ContractServiceProxy, BidServiceProxy, BidInput, BidDto, VendorServiceProxy, VendorDto } from "@shared/service-proxies/service-proxies";
import { ActivatedRoute, Params } from "@angular/router";
import { CreateOrEditContractModalComponent } from "./create-or-edit-contract-modal.component";
import { ViewContractModalComponent } from "./view-contract-modal.component";
import { DateTimeService } from "@app/shared/common/timing/date-time.service";

@Component({
    templateUrl: './contract.component.html',
    animations: [appModuleAnimation()] 
})

export class ContractComponent extends AppComponentBase implements AfterViewInit, OnInit {
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditContractModalComponent;
    @ViewChild('viewContractModal') viewContractModal: ViewContractModalComponent;

    // tao bien de filter
    contractID: string
    contractName: string
    deliveryTime: String
    briefCaseID: number
    vendorID: number

    listBid: BidDto[] = []
    listVendor: VendorDto[] = []

    bid: BidInput;

    constructor(
        injector: Injector,
        private _contractService: ContractServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private _bidService: BidServiceProxy,
        private _vendorService: VendorServiceProxy
    ) {
        super(injector);
    }

    ngAfterViewInit(): void {
        setTimeout(() => {
            this.init();
        });
    }    
    
    ngOnInit(): void {
        
    }

    /**
     * Hàm get danh sách Merchandise
     * @param event
     */
    getContracts(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null, null, null, 0, 0, event);
    }

    reloadList(contractID, contractName, deliveryTime, briefCaseID, vendorID, event: LazyLoadEvent) {
        this._contractService.getContractsByFilter(contractID,
            contractName, deliveryTime, briefCaseID, vendorID,
            this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });

        this._bidService.getBidsByFilter(null, null, null, null, 'All', 0, null, 999, 0).subscribe(result => {
            this.listBid = result.items;
        });

        this._vendorService.getVendorsByFilter(null, null, 0, null, null, 999, 0).subscribe(result => {
            this.listVendor = result.items;
        })
    }

    init(): void {
        this._activatedRoute.params.subscribe((params: Params) => {
            this.contractID = params['contractID'] || '';
            this.contractName = params['name'] || '';
            this.deliveryTime = params['deliveryTime'] || '';
            this.briefCaseID = params['briefcaseID'] || 0;
            this.vendorID = params['vendorID'] || 0;
            this.reloadList(this.contractID, this.contractName, this.deliveryTime , this.briefCaseID, this.vendorID, null);
        });
    }

    getBidNameFromId(id: number): any {
        for(const item of this.listBid) {
            if (item.id == id) {
                return item.name;
            }
        }
        return "Chưa có mã gói thầu";
    }

    getVendorName(id: number): any {
        for (const item of this.listBid) {
            if (item.id == id) {
                for (const vendor of this.listVendor) {
                    if (vendor.id == item.bidderID) {
                        return vendor.name;
                    }
                }
            }
        }
        return "Chưa có nhà cung cấp";
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    deleteContract(id): void {
        this._contractService.deleteContract(id).subscribe(() => {
            this.reloadPage();
        })
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.contractID, this.contractName, this.deliveryTime, this.briefCaseID, this.vendorID, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    createContract() {
        this.createOrEditModal.show();
    }

    dateFormat(date): string {
        var moment = require('moment');
        var _date = moment(date);
        var tz = _date.utcOffset();
        _date.add(tz, 'm');
        return _date.format('DD/MM/YYYY');
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}