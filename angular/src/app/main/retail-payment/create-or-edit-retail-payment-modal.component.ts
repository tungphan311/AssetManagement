import { Component, Injector, ViewChild, ElementRef, Output, EventEmitter } from "@angular/core";
import { AppComponentBase } from "@shared/common/app-component-base";
import { AssignmentTableInput, AssignmentTableServiceProxy, VendorServiceProxy, MerchandiseServiceProxy, RetailInput, RetailServiceProxy, RetailPaymentInput, RetailPaymentServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from "ngx-bootstrap";

@Component({
    selector: 'createOrEditRetailPaymentModal',
    templateUrl: './create-or-edit-retail-payment-modal.component.html'
})

export class CreateOrEditRetailPaymentModalComponent extends AppComponentBase {

        @ViewChild('createOrEditModal') modal: ModalDirective;
        
        /**
         * @Output dùng để public event cho component khác xử lý
         */
        @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
    
        saving=false;
    
        retail : RetailPaymentInput = new RetailPaymentInput();
    
        listPayment = [];
    
        constructor(
            injector: Injector,
            private _retailPaymentService: RetailPaymentServiceProxy,
        ) {
            super(injector);
        }
        show(retailID?: number | null| undefined): void {
            this.saving=false;
            this._retailPaymentService.getRetailPaymentForEdit(retailID).subscribe(result => {
                this.retail = result;
                this.modal.show();
            })

            
        }
    
        save(): void {
            let input = this.retail;
            var moment = require('moment');
            input.paymentDate = moment(input.paymentDate);
            this.saving = true;
            this._retailPaymentService.createOrEditRetailPayment(input).subscribe(result =>{
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
            })
        }
        close(): void {
            this.modal.hide();
            this.modalSave.emit(null);
        }
    }