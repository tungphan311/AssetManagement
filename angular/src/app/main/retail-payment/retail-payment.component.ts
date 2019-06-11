import { Component, Injector, ViewChild, AfterViewInit, OnInit } from "@angular/core";
import { appModuleAnimation } from "@shared/animations/routerTransition";
import { AppComponentBase } from "@shared/common/app-component-base";
import { AssignmentTableServiceProxy, MerchandiseServiceProxy, VendorServiceProxy, RetailServiceProxy, RetailPaymentServiceProxy, ContractPaymentInput, RetailPaymentInput } from "@shared/service-proxies/service-proxies";
import { ActivatedRoute, Params } from "@angular/router";

import { Table } from "primeng/table";
import { Paginator, LazyLoadEvent } from "primeng/primeng";
import { CreateOrEditRetailPaymentModalComponent } from "./create-or-edit-retail-payment-modal.component";

@Component({
    templateUrl: './retail-payment.component.html',
    animations: [appModuleAnimation()]
})

export class RetailPaymentComponent extends AppComponentBase  {
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditRetailPaymentModalComponent

    // tao bien de filter
    RetailID: string
    MerchID: string
    VendorID: string

    index = 1;

    listRetailPayment =[]

    // list 

    constructor(
        injector: Injector,
        private _retailPaymentService: RetailPaymentServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);
    }

    // ngAfterViewInit(): void {
    //     setTimeout(() => {
    //         this.init();
    //     });
    // }
    deleteRetail(id): void {
        this._retailPaymentService.deleteRetailPayment(id).subscribe(() => {
            this.reloadPage();
        })
    }

    ngOnInit(): void {
        //load list assignmenttable
        this._retailPaymentService.getRetailPaymentsByFilter(null,99,0);
    }

    getRetail(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */


        this.reloadList(event);
    }

        /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }

    reloadList(event ?: LazyLoadEvent) {
        this._retailPaymentService.getRetailPaymentsByFilter(
            this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items; 
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    // init(): void {
    //     this._activatedRoute.params.subscribe((params: Params) => {
    //         this.MerchID = params['merchID'] || 0;
    //         this.VendorID= params['vendorID'] || 0;
    //         this.reloadList(this.MerchID,this.VendorID,null);

    //     });

    // }
    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    createRetail() : void {
         this.createOrEditModal.show();

        // var payment: ContractPaymentInput = new ContractPaymentInput();
        // payment.batch = this.index;
        // payment.percent = 0;
        // payment.amount = 0;
        // payment.note = "";

        // var moment3 = require('moment');
        // var date = moment3(payment.paymentDate);
        // var tz = date.utcOffset();
        // date.add(tz, 'm');
        // payment.paymentDate = date.format('YYYY-MM-DD');

        // this.listRetailPayment.push(payment);
        // this.index += 1;
        // let input: RetailPaymentInput = new RetailPaymentInput();
        // input.paymentDate= moment3(payment.paymentDate);
        // input.quantity=payment.amount;
        // input.note=""

        // this._retailPaymentService.createOrEditRetailPayment(input);


    }

}
