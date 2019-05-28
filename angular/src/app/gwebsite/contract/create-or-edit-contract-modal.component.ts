import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { ContractServiceProxy, ContractInput } from '@shared/service-proxies/service-proxies';
//import { conventionServiceProxy, conventionInput,conventionInputStatus } from '@shared/service-proxies/service-proxies';
@Component({
    selector: 'createOrEditContractModal',
    templateUrl: './create-or-edit-contract-modal.component.html'
})
export class CreateOrEditContractModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('contractCombobox') contractCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    contract: ContractInput = new ContractInput();


    constructor(
        injector: Injector,
        private _contractService: ContractServiceProxy
        
    ) {
        super(injector);
    }

    ngOnInit(){
       console.log('onInit')
     }

    show(contractId?: number | null | undefined): void {
        this.saving = false;

        this._contractService.getContractForEdit(contractId).subscribe(result => {
            this.contract = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.contract   ;
        this.saving = true;
        this._contractService.createOrEditContract(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
