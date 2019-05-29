import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { BidderServiceProxy,BidderInput,VendorServiceProxy } from '@shared/service-proxies/service-proxies';
import { SelectVendorModalComponent } from './select-vendor-modal.component';
import { appModuleAnimation } from "@shared/animations/routerTransition";

@Component({
    selector: 'addBidderModal',
    templateUrl: './add-bidder-modal-component.html',
    animations: [appModuleAnimation()]
})
export class AddBidderModal extends AppComponentBase {

    @ViewChild('addModal') addModal: ModalDirective;
    @ViewChild('bidderCombobox') bidderCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;
    @ViewChild('selectVendorModal') selectVendorModal: SelectVendorModalComponent;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave1: EventEmitter<any> = new EventEmitter<any>();

    saving = false;
    bidderName: string;
    bidderCode: string;

    vendorName: string;
    vendorCode: string;

    bidder: BidderInput = new BidderInput();

    constructor(
        injector: Injector,
        private _bidderService:BidderServiceProxy,
        private _vendorService:VendorServiceProxy
    ) {
        super(injector);
    }

    show(bidderInput:BidderInput): void {
        this.saving = false;
        this.bidder = bidderInput;  
        if (this.bidder.applyDay!=null)
            {
                var moment=require('moment');
                var _applyDay = moment(this.bidder.applyDay);
                var tz = _applyDay.utcOffset(); 
                _applyDay.add(tz, 'm');
                this.bidder.applyDay = _applyDay.format('YYYY-MM-DD');
            }
        if (this.bidder.guaranteeExpired!=null)
            {
                var moment=require('moment');
                var _guaranteeExpired = moment(this.bidder.guaranteeExpired);
                var tz = _guaranteeExpired.utcOffset(); 
                _guaranteeExpired.add(tz, 'm');
                this.bidder.guaranteeExpired = _guaranteeExpired.format('YYYY-MM-DD');
            }
        this.vendorCode="";
        this.vendorName="";
        if(this.bidder.vendorId!=0&&this.bidder.vendorId!=null&&this.bidder.vendorId!=undefined)
        {
            this.updateVendorCode(this.bidder.vendorId);
            this.updateVendorName(this.bidder.vendorId)
        }
        this.addModal.show();    
    }

    save(): void {
        this.saving = true;
        this.close(this.bidder);
    }
    updateVendorCode(vendorID:number):void{
            this._vendorService.getVendorForView(vendorID).subscribe(result => {
                this.vendorCode = result.code;        
            })
    }
    updateVendorName(vendorID:number):void{
            this._vendorService.getVendorForView(vendorID).subscribe(result => {
                this.vendorName = result.name;        
            })
    }
    reloadVendor(vendorID:number): void {
        if (vendorID!=0){
        this.bidder.vendorId = vendorID;
        this.updateVendorCode(vendorID);
        this.updateVendorName(vendorID);
        }
        else
        {
            this.vendorCode = "";
            this.vendorName = "";
        }
    }
    close(bidder?:BidderInput): void {
        this.addModal.hide();
        if(bidder!=null&&bidder!=undefined){
        this.modalSave1.emit(bidder);
        
        }
        else
        this.modalSave1.emit(null);
    }
}
