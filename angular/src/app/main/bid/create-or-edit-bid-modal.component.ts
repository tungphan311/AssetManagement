import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { BidServiceProxy, BidInput, ProjectServiceProxy } from '@shared/service-proxies/service-proxies';
import { SelectProjectModalComponent } from './select-project-modal.component';
import * as moment from 'moment';
import { projection } from '@angular/core/src/render3/instructions';
import { variable } from '@angular/compiler/src/output/output_ast';

@Component({
    selector: 'createOrEditBidModal',
    templateUrl: './create-or-edit-bid-modal.component.html'
})
export class CreateOrEditBidModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('bidCombobox') bidCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    @ViewChild('selectProjectModal') selectProjectModal: SelectProjectModalComponent;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;
    projectCode: string;

    bid: BidInput = new BidInput();

    constructor(
        injector: Injector,
        private _bidService: BidServiceProxy,
        private _projectService: ProjectServiceProxy
    ) {
        super(injector);
    }

    show(bidId?: number | null | undefined): void {
        this.saving = false;
        this.projectCode = "";

        this._bidService.getBidForEdit(bidId).subscribe(result => {
            this.bid = result;
            this.bid.biddingForm = this.bid.biddingForm || 'Đấu thầu';
            var moment = require('moment');     
            //projectCode
            this.projectCode = this.getProjectCode(this.bid.projectId);
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
            this.modal.show();

        })
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
    save(): void {
        let input = this.bid;
        var moment = require('moment');
        input.beginDay = moment(input.beginDay);
        input.startReceivingRecords = moment(input.startReceivingRecords);
        input.endReceivingRecords = moment(input.endReceivingRecords);
        this.saving = true;
        this._bidService.createOrEditBid(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
