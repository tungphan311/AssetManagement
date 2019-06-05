import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { ProductContractServiceProxy, ProductContractInput } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditProductContractModal',
    templateUrl: './create-or-edit-product-contract-modal.component.html'
})
export class CreateOrEditProductContractModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('productContractCombobox') productContractCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;
  

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    productContract: ProductContractInput = new ProductContractInput();

    constructor(
        injector: Injector,
        private _productContractService: ProductContractServiceProxy
    ) {
        super(injector);
    }

    show(productContractId?: number | null | undefined): void {
        this.saving = false;


        this._productContractService.getProductContractForEdit(productContractId).subscribe(result => {
            this.productContract = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.productContract;
        this.saving = true;
        this._productContractService.createOrEditProductContract(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
