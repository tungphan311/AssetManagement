import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { appModuleAnimation } from "@shared/animations/routerTransition";
import { BidServiceProxy, BidInput, ProjectServiceProxy, BidderServiceProxy, BidderDto,BidderInput,VendorServiceProxy, PagedResultDtoOfBidDto, VendorInput } from '@shared/service-proxies/service-proxies';

import { Table } from "primeng/table";
import { Paginator, LazyLoadEvent } from "primeng/primeng";
import * as moment from 'moment';
import { projection } from '@angular/core/src/render3/instructions';
import { variable } from '@angular/compiler/src/output/output_ast';
import { bootloader } from '@angularclass/hmr';
import { observable, of as _observableOf } from 'rxjs';
import { NgForm } from '@angular/forms';

@Component({
    selector: 'viewBidModal',
    templateUrl: './view-bid-modal.component.html',
    animations: [appModuleAnimation()]
})
export class ViewBidModalComponent extends AppComponentBase {

    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('viewBidModal') viewBidModal: ModalDirective;
    @ViewChild('bidCombobox') bidCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    @ViewChild('editForm') editForm: NgForm;

    saving = false;
    projectCode: string;

    vendorName: string;
    vendorCode: string;

    selectedVendorID: number;

    bid: BidInput = new BidInput();
    bidderList=[{"bidder":new BidderInput(),"vendorName":"?","vendorCode":"?"}];
   // oldBidderList=[{"isSelected":false,"bidder":new BidderInput()}];

    constructor(
        injector: Injector,
        private _bidService: BidServiceProxy,
        private _bidderService: BidderServiceProxy,
        private _projectService: ProjectServiceProxy,
        private _vendorService: VendorServiceProxy
    ) {
        super(injector);
    }
    getBidders(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }
        this.primengTableHelper.showLoadingIndicator();

        this.reloadListBidders(event);
    }   

    reloadListBidders(event: LazyLoadEvent) {
        
    
            if (this.bidderList.length>0){
            this.primengTableHelper.totalRecordsCount = this.bidderList.length;
            this.primengTableHelper.records = this.bidderList;
            }
            else
            {
                this.primengTableHelper.totalRecordsCount = 0;
                this.primengTableHelper.records = null;
            }
            this.primengTableHelper.hideLoadingIndicator();
            //this.reloadPage();
    }



    show(bidId?: number | null | undefined): void {
        this.saving = false;
        while (this.bidderList.length>0)
            this.bidderList.pop();       
        this.projectCode = "";
        this.bid.bidders =new Array<BidderInput>();
        this._bidService.getBidForEdit(bidId).subscribe(result => {
            this.bid = result;
            this.bid.biddingForm = this.bid.biddingForm || 'Đấu thầu';
            var moment = require('moment');     
            //projectCode
            if (this.bid.projectId!=0)
            this.projectCode = this.getProjectCode(this.bid.projectId);
            //selectedBidder
            if (result.bidderID!=0&&result.bidderID!=null&&result.bidderID!=undefined)
                this.selectedVendorID=result.bidderID;
            //beginDay 
            if (result.beginDay!=null)
            {
                var _beginDay = moment(result.beginDay);
                var tz = _beginDay.utcOffset(); 
                _beginDay.add(tz, 'm');
                this.bid.beginDay = _beginDay.format('YYYY-MM-DD');
            }
            //startReceivingRecords
            if (result.startReceivingRecords!=null)
            {
            var _startReceivingRecords = moment(result.startReceivingRecords);
            var tz = _startReceivingRecords.utcOffset(); 
            _startReceivingRecords.add(tz, 'm');
            this.bid.startReceivingRecords = _startReceivingRecords.format('YYYY-MM-DD');
            }
            //endReceivingRecords 
            if (result.endReceivingRecords!=null)
            {
            var _endReceivingRecords = moment(result.endReceivingRecords);
            var tz = _endReceivingRecords.utcOffset(); 
            _endReceivingRecords.add(tz, 'm');
            this.bid.endReceivingRecords = _endReceivingRecords.format('YYYY-MM-DD');
            }
            
            //--------------------           
            if (bidId!=0&&bidId!=null&&bidId!=undefined){
                    for (const iterator of result.bidders) {                                                             
                        this._vendorService.getVendorForView(iterator.vendorId).subscribe(result => {
                            let obj = {
                                bidder:iterator,
                                vendorName:result.name,
                                vendorCode:result.code
                            }; 
                            //convert time
                            if (obj.bidder.applyDay!=null){
                                var _applyDay = moment(obj.bidder.applyDay);
                                var tz = _applyDay.utcOffset();
                                _applyDay.add(tz,'m');
                                obj.bidder.applyDay = _applyDay.format('YYYY-MM-DD');
                            } 
                            if (obj.bidder.guaranteeExpired!=null){
                                var _guaranteeExpired = moment(obj.bidder.guaranteeExpired);
                                var tz = _guaranteeExpired.utcOffset();
                                _guaranteeExpired.add(tz,'m');
                                obj.bidder.guaranteeExpired = _guaranteeExpired.format('YYYY-MM-DD');
                            }         
                            //-                             
                            this.bidderList.push(obj);
                            //code chữa cháy
                            this.getBidders(null);
                        })
                    }                  
            }
            //----
        })
        //this.getBidders(null);
        this.viewBidModal.show();
        
        
    }
    getProjectCode(projectID:number):string{
        let projectCode = "";
        let temp = this.projectCode;
        if (projectID!=0)
        {
            this._projectService.getProjectForView(projectID).subscribe(result => {
                this.projectCode = result.code;        
            })
        }
        projectCode = this.projectCode;
        this.projectCode = temp;
        return projectCode;
    }
    reloadProject(projectID:number): void {
        if (projectID!=0){
        this.bid.projectId = projectID;
        this.projectCode = this.getProjectCode(projectID);
        }
        else
        {
            this.projectCode = "";
        }
    }
         
    dateFormat(date): string {
        var moment = require('moment');
        var _date = moment(date);
        var tz = _date.utcOffset();
        _date.add(tz, 'm');
        return _date.format('DD/MM/YYYY');
    }
    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    close(): void {
        this.viewBidModal.hide();
        this.editForm.resetForm();
    }
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
