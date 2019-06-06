import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild, Input } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { ContractPaymentDetailServiceProxy, ContractPaymentDetailInput, ContractPaymentDetailDto, ContractInput } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditContractPaymentDetailModal',
    templateUrl: './create-or-edit-contract-payment-detail-modal.component.html'
})
export class CreateOrEditContractPaymentDetailModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('ContractPaymentDetailCombobox') ContractPaymentDetailCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
   @Input()totalProductPriceInput:number;

    saving = false;

    contractPaymentDetail: ContractPaymentDetailInput = new ContractPaymentDetailInput();


    constructor(
        injector: Injector,
        private _ContractPaymentDetailService: ContractPaymentDetailServiceProxy

    ) {
        super(injector);
    }

    calculateMoneyByPercent(){
        console.log(this.totalProductPriceInput)
        this.contractPaymentDetail.price= this.totalProductPriceInput?this.totalProductPriceInput*this.contractPaymentDetail.percent/100:0
    }
    show(contractPaymentDetailId?: number | null | undefined): void {
        this.saving = false;


        this._ContractPaymentDetailService.getContractPaymentDetailForEdit(contractPaymentDetailId).subscribe(result => {
            this.contractPaymentDetail = result;
            this.contractPaymentDetail.id=contractPaymentDetailId

        })
       
        this.modal.show();
    }

    save(): void {
        let input = this.contractPaymentDetail;
        console.log(input)
       
        this.saving = true;
       
        if (input!=undefined&&input!=null){
          this.modalSave.emit(input)
        }
           
        
        //this.notify.info(this.l('SavedSuccessfully'));
        this.close();
    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }

}

