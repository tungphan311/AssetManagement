import { ProductCategoryForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { ProductCategoryServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewProductCategoryModal',
    templateUrl: './view-productcategory-modal.component.html'
})

export class ViewProductCategoryModalComponent extends AppComponentBase {

    productCategory : ProductCategoryForViewDto = new ProductCategoryForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _productCategoryService: ProductCategoryServiceProxy
    ) {
        super(injector);
    }

    show(productCategoryId?: number | null | undefined): void {
        this._productCategoryService.getProductCategoryForView(productCategoryId).subscribe(result => {
            this.productCategory = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}