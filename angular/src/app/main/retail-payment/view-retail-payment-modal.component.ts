import { Component, Injector, ViewChild } from "@angular/core";
import { AppComponentBase } from "@shared/common/app-component-base";
import { MerchandiseServiceProxy, VendorServiceProxy, RetailForViewDto, RetailServiceProxy, RetailPaymentServiceProxy, RetailPaymentForViewDto } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from "ngx-bootstrap";

@Component({
    selector: 'viewRetailPaymentModal',
    templateUrl: './view-retail-payment-modal.component.html'
})

export class ViewRetailPaymentModalComponent extends AppComponentBase {

    retail: RetailPaymentForViewDto = new RetailPaymentForViewDto();
    @ViewChild('viewRetailModal') modal: ModalDirective;

    vendorlist=[];
    merchlist=[];


    constructor(
        injector: Injector,
        private _retailPaymentService: RetailPaymentServiceProxy,
    ) {
        super(injector);
    }
    show(retailID?: number | null | undefined): void {
        this._retailPaymentService.getRetailPaymentForView(retailID).subscribe(result => {
            this.retail = result;
            this.modal.show();
        })

    }

    getMerchName(id: number): any {
        for (const iterator of this.merchlist) {
            if (iterator.id === id) {
                return iterator.name;
            }
        }
    }

    getVendorName(id: number): any {
        for (const iterator of this.vendorlist) {
            if (iterator.id == id) {
                return iterator.name;
            }
        }
    }
    close() : void{
        this.modal.hide();
    }
}
