import { ProductForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { ProductServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewProductModal',
    templateUrl: './view-product-modal.component.html'
})

export class ViewProductModalComponent extends AppComponentBase {

    product : ProductForViewDto = new ProductForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _productService: ProductServiceProxy
    ) {
        super(injector);
    }

    show(productId?: number | null | undefined): void {
        this._productService.getProductForView(productId).subscribe(result => {
            this.product = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}