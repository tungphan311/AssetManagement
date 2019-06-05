import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { ProductServiceProxy, ProductInput } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditProductModal',
    templateUrl: './create-or-edit-product-modal.component.html'
})
export class CreateOrEditProductModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('productCombobox') productCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    product: ProductInput = new ProductInput();

    constructor(
        injector: Injector,
        private _productService: ProductServiceProxy
    ) {
        super(injector);
    }

    show(productId?: number | null | undefined): void {
        this.saving = false;


        this._productService.getProductForEdit(productId).subscribe(result => {
            this.product = result;
            this.modal.show();            
        })
    }

    save(): void {
        let input = this.product;
        this.saving = true;
        this._productService.createOrEditProduct(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
