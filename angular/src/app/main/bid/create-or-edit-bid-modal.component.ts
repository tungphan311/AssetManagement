import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { BidServiceProxy, BidInput } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditBidModal',
    templateUrl: './create-or-edit-bid-modal.component.html'
})
export class CreateOrEditBidModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('bidCombobox') bidCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    bid: BidInput = new BidInput();

    constructor(
        injector: Injector,
        private _bidService: BidServiceProxy
    ) {
        super(injector);
    }

    show(bidId?: number | null | undefined): void {
        this.saving = false;


        this._bidService.getBidForEdit(bidId).subscribe(result => {
            this.bid = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.bid;
        var moment = require('moment');
        input.beginDay = moment(input.beginDay);
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
