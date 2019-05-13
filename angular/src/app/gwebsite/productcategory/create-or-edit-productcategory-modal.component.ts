import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { ProductCategoryServiceProxy, ProductCategoryInput } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'createOrEditProductCategoryModal',
    templateUrl: './create-or-edit-productcategory-modal.component.html'
})
export class CreateOrEditProductCategoryModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('productcategoryCombobox') productcategoryCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    productCategory: ProductCategoryInput = new ProductCategoryInput();

    constructor(
        injector: Injector,
        private _productCategoryService: ProductCategoryServiceProxy
    ) {
        super(injector);
    }

    show(productCategoryId?: number | null | undefined): void {
        this.saving = false;


        this._productCategoryService.getProductCategoryForEdit(productCategoryId).subscribe(result => {
            this.productCategory = result;
            this.modal.show();

        })
    }

    save(): void {
        let input = this.productCategory;
        this.saving = true;
        this._productCategoryService.createOrEditProductCategory(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
