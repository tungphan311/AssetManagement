import { Component, Injector, ViewChild, ElementRef, Output, EventEmitter } from "@angular/core";
import { AppComponentBase } from "@shared/common/app-component-base";
import { ModalDirective } from "ngx-bootstrap";
import { AssignmentTableInput, AssignmentTableServiceProxy, VendorServiceProxy, MerchandiseServiceProxy, RetailInput, RetailServiceProxy, ContractPaymentInput } from "@shared/service-proxies/service-proxies";

@Component({
    selector: 'createOrEditRetailModal',
    templateUrl: './create-or-edit-retail-modal.component.html'
})

export class CreateOrEditRetailModalComponent extends AppComponentBase {

        @ViewChild('createOrEditModal') modal: ModalDirective;
        
        /**
         * @Output dùng để public event cho component khác xử lý
         */
        @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
    
        saving=false;
        index=1;
    
        retail : RetailInput = new RetailInput();
        vendors =[]
        merchandises = []
    
        listPayment = [];
    
        constructor(
            injector: Injector,
            private _vendorService: VendorServiceProxy,
            private _merchandiseService: MerchandiseServiceProxy,
            private _retailService: RetailServiceProxy,
        ) {
            super(injector);
        }
        show(retailID?: number | null| undefined): void {
            this.saving=false;
            this._retailService.getRetailForEdit(retailID).subscribe(result => {
                this.retail = result;
                
                if (retailID == null || retailID == undefined)
                {
                    this.retail.payments = [];
                }

                this.modal.show();
            })
            this._vendorService.getVendorsByFilter(null,null,0,null,null,99,0).subscribe(result => {
                this.vendors=result.items;
                })
            this._merchandiseService.getMerchandiseByFilter(null,null,0,0,null,null,99,0).subscribe(result => {
                this.merchandises=result.items;
                }) 
            
        }
    
        save(): void {
            let input = this.retail;
            this.saving = true;
            this._retailService.createOrEditRetail(input).subscribe(result =>{
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
            })
        }
        close(): void {
            this.modal.hide();
            this.modalSave.emit(null);
        }
        addContractPayment(): void {
            var payment: ContractPaymentInput = new ContractPaymentInput();
            payment.batch = this.index;
            payment.percent = 0;
            payment.amount = 0;
            payment.note = "";
    
            var moment3 = require('moment');
            var date = moment3(payment.paymentDate);
            var tz = date.utcOffset();
            date.add(tz, 'm');
            payment.paymentDate = date.format('YYYY-MM-DD');
            
            this.listPayment.push(payment);
            
            this.index += 1;
        }
    }