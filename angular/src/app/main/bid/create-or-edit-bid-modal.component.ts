import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { appModuleAnimation } from "@shared/animations/routerTransition";
import { BidServiceProxy, BidInput, ProjectServiceProxy, BidderServiceProxy, BidderDto,BidderInput,VendorServiceProxy } from '@shared/service-proxies/service-proxies';
import { SelectProjectModalComponent } from './select-project-modal.component';
import { AddBidderModal } from './add-bidder-modal-component';
import { Table } from "primeng/table";
import { Paginator, LazyLoadEvent } from "primeng/primeng";
import * as moment from 'moment';
import { projection } from '@angular/core/src/render3/instructions';
import { variable } from '@angular/compiler/src/output/output_ast';
import { bootloader } from '@angularclass/hmr';

@Component({
    selector: 'createOrEditBidModal',
    templateUrl: './create-or-edit-bid-modal.component.html',
    animations: [appModuleAnimation()]
})
export class CreateOrEditBidModalComponent extends AppComponentBase {

    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('bidCombobox') bidCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    @ViewChild('selectProjectModal') selectProjectModal: SelectProjectModalComponent;
    @ViewChild('addBidderModal') addBidderModal: AddBidderModal;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;
    projectCode: string;

    vendorName: string;
    vendorCode: string;

    selectedVendorID: number;

    bid: BidInput = new BidInput();
    bidderList=[{"isSelected":false,"bidder":new BidderInput(),"vendorName":"?","vendorCode":"?"}];
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
            
            this.primengTableHelper.totalRecordsCount = this.bidderList.length;
            this.primengTableHelper.records = this.bidderList;
            this.primengTableHelper.hideLoadingIndicator();
            //this.reloadPage();
    }

    addBidder(bidderID:number):void {
        if (bidderID!=0){
            for (const iterator of this.bidderList) {
                if (iterator.bidder.vendorId == bidderID) {
                    this.addBidderModal.show(iterator.bidder);
                    break;
                }
            }
        }
        else
        {
            let bidderInput = new BidderInput();
            bidderInput.bidID = this.bid.id;   
            this.addBidderModal.show(bidderInput); 
            
        }
    }
    addBiddertoList(bidder: BidderInput){
        if (bidder!=null)
        {
            let isExist = false;
            for(const iterator of this.bidderList){
                if (iterator.bidder.vendorId==bidder.vendorId)
                    {
                        const note = this.bidderList.find(obj=>obj.bidder.vendorId==bidder.vendorId);
                        note.bidder=bidder;
                        this.notify.info('Cập nhật DV tham gia thành công');
                        this.getBidders();
                        isExist=true;
                        return;
                    }
            }
            if (!isExist){
            this._vendorService.getVendorForView(bidder.vendorId).subscribe(result => {
                let obj = {
                    isSelected:false,
                    bidder:bidder,
                    vendorName:result.name,
                    vendorCode:result.code
                };  
            this.bidderList.push(obj);
            this.getBidders();
            this.notify.info('Thêm mới DV tham gia thành công');
            })
        }
        }
    }
    deleteBidder(bidderID:number){
        if (bidderID!=0&&bidderID!=null&&bidderID!=undefined)
        {
            for(const iterator of this.bidderList){
                if (iterator.bidder.vendorId==bidderID)
                    this.bidderList=this.bidderList.filter(obj=>obj.bidder!=iterator.bidder)
            }
        }
        this.getBidders();
    }
    bidderSelect(bidderID:number){
        this.notify.info('selecthere');

    }
    show(bidId?: number | null | undefined): void {
        this.saving = false;
        this.projectCode = "";
        //xoa rong list
        while (this.bidderList.length!=0){
            this.bidderList.pop();
        }
      //  while (this.oldBidderList.length!=0){
        //    this.oldBidderList.pop();
      //  }
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
                this._bidderService.getBiddersByFilter(bidId,null,999,0,
                ).subscribe(result => {
                    for (const iterator of result.items) {
                        let bidderInput = new BidderInput();
                        bidderInput=iterator;
                        //map bidderdto sang bidderinput
                        //bidderInput.vendorId = iterator.vendorId;
                        //bidderInput.applyDay = iterator.applyDay;
                        //bidderInput.bidID = iterator.bidID;
                        //bidderInput.certificateNumber = iterator.certificateNumber;
                        //bidderInput.guaranteeExpired = iterator.guaranteeExpired;
                        //bidderInput.guaranteeMethod = iterator.guaranteeMethod;
                        //bidderInput.id=iterator.id;
                        //bidderInput.note=iterator.note;
                        //bidderInput.offerPrice=iterator.offerPrice;
                        //---------------
                        this._vendorService.getVendorForView(bidderInput.vendorId).subscribe(result => {
                            let obj = {
                                isSelected:false,
                                bidder:bidderInput,
                                vendorName:result.name,
                                vendorCode:result.code
                            };                                    
                            this.bidderList.push(obj);
                            //let oldObj = {
                                //isSelected:false,
                              //  bidder:new BidderInput()
                            //}
                            //oldObj.bidder=obj.bidder;
                           // this.oldBidderList.push(oldObj);   
                        })
                        
                    }                  
                })
            }
        })
        this.getBidders(null);
        this.modal.show();
        
    }
    getBidderCode(bidderID:number):string{
        this.vendorCode="";
        if (bidderID!=0&&bidderID!=null&&bidderID!=undefined)
        {
            this._vendorService.getVendorForView(bidderID).subscribe(result => {
                this.vendorCode = result.code;    
                return this.vendorCode;    
            })
        }
        else return "";
        
    }
    getBidderName(bidderID:number):string{
        this.vendorName="";
        if (bidderID!=0&&bidderID!=null&&bidderID!=undefined)
        {
            this._vendorService.getVendorForView(bidderID).subscribe(result => {
                this.vendorName = result.name;    
            })
        }
        return this.vendorName;
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
    isEquivalent(a, b):boolean {
        // Create arrays of property names
        var aProps = Object.getOwnPropertyNames(a);
        var bProps = Object.getOwnPropertyNames(b);
    
        // If number of properties is different,
        // objects are not equivalent
        if (aProps.length != bProps.length) {
            return false;
        }
    
        for (var i = 0; i < aProps.length; i++) {
            var propName = aProps[i];
            if (propName=='offerPrice'){
                this.notify.info(a[propName].toString()+' = '+b[propName].toString()+'?');
            }
            // If values of same property are not equal,
            // objects are not equivalent
            if (a[propName] != b[propName]) {
                return false;
            }
        }
        // If we made it this far, objects
        // are considered equivalent
        return true;
    }
    save(): void {
        let input = this.bid;
        var moment = require('moment');
        input.beginDay = moment(input.beginDay);
        input.startReceivingRecords = moment(input.startReceivingRecords);
        input.endReceivingRecords = moment(input.endReceivingRecords);
        if(this.selectedVendorID!=0&&this.selectedVendorID!=null&&this.selectedVendorID!=undefined){
            input.bidderID=this.selectedVendorID;
        }
        this.saving = true;
        
        this._bidService.createOrEditBid(input).subscribe(result => {
            if (input.id!=0&&input.id!=null&&input.id!=undefined)
            {
                this._bidderService.getBiddersByFilter(input.id,null,999,0).subscribe(result=>{
                    for(const oldBidder of result.items)
                    {
                        let isStillExist = false;
                        for (const newBidder of this.bidderList) 
                        {
                            if (oldBidder.vendorId==newBidder.bidder.vendorId)
                                isStillExist=true;
                        }
                        if (!isStillExist){
                            this._bidderService.deleteBidder(oldBidder.id).subscribe(result=>{
                                
                            }) 
                        }
                    }
                    for (const iterator of this.bidderList) 
                    {
                            //không hiểu sao lúc so sánh list cũ với list mới nó giống nhau hoàn toàn
                            //list cũ nó tự update theo list mới?.... no idea...
                            //tạm thời bỏ cách làm này
                            //let isOld = false;
                            //for (const old of this.oldBidderList)
                            //  if (old.bidder.vendorId==iterator.bidder.vendorId&&this.isEquivalent(old.bidder,iterator.bidder))   {                
                                //    isOld = true;
                            // }
                            //if (!isOld)
                            //{
                                //cách dưới đây sida hơn vì nó update luôn những cái không thay đổi
                                if (iterator.bidder.id!=0&&iterator.bidder.id!=null&&iterator.bidder.id!=undefined)
                                {

                                }
                                else iterator.bidder.id=0;

                                iterator.bidder.bidID=input.id;
                                iterator.bidder.applyDay=moment(iterator.bidder.applyDay);
                                iterator.bidder.guaranteeExpired=moment(iterator.bidder.guaranteeExpired);
                                this._bidderService.createOrEditBidder(iterator.bidder).subscribe(result =>{

                                })
                        // }
                    } 
                })
            }
            else
            {
                //lấy bid vừa tạo ở trên, cách này chỉ dùng tạm vì không biết cách nào khác
                this._bidService.getBidsByFilter(input.name,null,null,null,null,0,null,999,0).subscribe(result=>{
                    if(result.totalCount==1){
                        for (const iterator of this.bidderList) 
                        {
                            iterator.bidder.id=0;
                            iterator.bidder.bidID=result.items[0].id;
                            iterator.bidder.applyDay=moment(iterator.bidder.applyDay);
                            iterator.bidder.guaranteeExpired=moment(iterator.bidder.guaranteeExpired);
                            this._bidderService.createOrEditBidder(iterator.bidder).subscribe(result =>{
                            })  
                        }
                    }
                })
            }
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
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
