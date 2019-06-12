import { Component, ViewChild, ElementRef, Output, EventEmitter, Injector } from "@angular/core";
import { AppComponentBase } from "@shared/common/app-component-base";
import { ModalDirective } from "ngx-bootstrap";
import { Table } from "primeng/table";
import { Paginator } from "primeng/primeng";
import { POServiceProxy, POInput, ContractServiceProxy, VendorServiceProxy, ContractPaymentDto, ContractPaymentInput, POPaymentInput } from "@shared/service-proxies/service-proxies";
import { SelectContractModalComponent } from './select-contract-modal.component';
import { appModuleAnimation } from "@shared/animations/routerTransition";
import { AddMerchandiseToPOComponent } from "./add-merchandise-to-po.component";
import { AddVendorModalComponent } from "./add-vendor-modal.component";

@Component({
    selector: 'createOrEditPOModal',
    templateUrl: './create-or-edit-po-modal.component.html',
    animations: [appModuleAnimation()]
})

export class CreateOrEditPOModalComponent extends AppComponentBase {
    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('merchandiseCombobox') merchandiseCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('selectContractModal') selectContractModal: SelectContractModalComponent;
    @ViewChild('addMerchandiseToPO') addMerchandiseToPO: AddMerchandiseToPOComponent;
    @ViewChild('addVendorModal') addVendorModal: AddVendorModalComponent;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;
    po: POInput = new POInput();
    contractID: string='';
    contractNote: string;
    vendorID: number;
    vendorCode: string;
    vendorName: string;
    vendorAddress: string;
    listPaymentDetail: POPaymentInput[]=[];
    merchandises = [];
    paymentIndex: number;

    constructor(
        injector: Injector,
        private _poService: POServiceProxy,
        private _contractService: ContractServiceProxy,
        private _vendorService: VendorServiceProxy
    ) {
        super(injector);
    }

    emptyAll():void{
        this.po = new POInput();
        this.contractID = '';
        this.contractNote = '';
        this.vendorID = 0;
        this.vendorCode = '';
        this.vendorName = '';
        this.vendorAddress = '';
        this.paymentIndex = 1;
    }

    show(id?: number | null | undefined): void {
        this.saving = false;
        this.emptyAll();
        this._poService.getPOForEdit(id).subscribe(result => {
            this.po = result;

            if (result.payments!=null)
            {
                result.payments.forEach(item => {
                    var momen = require('moment');
                    var day = momen(item.paymentDate);
                    var tz = day.utcOffset();
                    day.add(tz, 'm');
                    item.paymentDate = day.format('YYYY-MM-DD');
                });

                this.listPaymentDetail = result.payments;

                this.paymentIndex = result.payments.length + 1;
            }

            this.modal.show();
        })
    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }

    reloadContract(contractID:number): void {
        if (contractID!=0){
            this.po.contractID = contractID;
            this._contractService.getContractForView(contractID).subscribe(result=>
                {                  
                    this.contractID = result.contractID;
                    this.contractNote = result.note;
                    this.vendorID = result.vendorID;
                    if (this.vendorID!=0&&this.vendorID!=null&&this.vendorID!=undefined)
                        this._vendorService.getVendorForView(this.vendorID).subscribe(result=>{
                        this.vendorCode = result.code;
                        this.vendorName = result.name;
                        this.vendorAddress=result.address;
                    })
                })
        }
    }

    addMerchandise() {
        this.addMerchandiseToPO.show();
    }

    reloadMerchandise():void{

    }

    save(): void {

    }
    addPaymentDetail(): void{
            var payment = new POPaymentInput();
            payment.batch = this.paymentIndex;
            payment.percent = 0;
            payment.amount = 0;
            payment.note = "";
    
            var moment3 = require('moment');
            var date = moment3(payment.paymentDate);
            var tz = date.utcOffset();
            date.add(tz, 'm');
            payment.paymentDate = date.format('YYYY-MM-DD');
    
            this.listPaymentDetail.push(payment);
            this.paymentIndex += 1;
    }
    removePaymentDetail():void{
        if (this.listPaymentDetail.length>0)
        {
            this.listPaymentDetail.pop();
            this.paymentIndex+=-1;
        }
    }
    reloadVendor(vendorID:number): void {
        if (vendorID!=0)
        {
            this.vendorID = vendorID;
            this._vendorService.getVendorForView(vendorID).subscribe(result=>{
                this.vendorCode = result.code;
                this.vendorName = result.name;
                this.vendorAddress=result.address;
            })
        }

    }
}
