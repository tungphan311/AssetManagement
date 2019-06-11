import { Component, Injector, ViewChild } from "@angular/core";
import { AppComponentBase } from "@shared/common/app-component-base";
import { MerchandiseServiceProxy, VendorServiceProxy, RetailForViewDto, RetailServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from "ngx-bootstrap";

@Component({
    selector: 'viewRetailModal',
    templateUrl: './view-retail-modal.component.html'
})

export class ViewRetailModalComponent extends AppComponentBase {

    retail: RetailForViewDto = new RetailForViewDto();
    @ViewChild('viewRetailModal') modal: ModalDirective;

    vendorlist=[];
    merchlist=[];


    constructor(
        injector: Injector,
        private _merchandiseService: MerchandiseServiceProxy,
        private _vendorService: VendorServiceProxy,
        private _retailService: RetailServiceProxy,
    ) {
        super(injector);
    }
    show(retailID?: number | null | undefined): void {
        this._retailService.getRetailForView(retailID).subscribe(result => {
            this.retail = result;
            this.modal.show();
        })

        this._merchandiseService.getMerchandiseByFilter(null,null,0,0,null,null,99,0).subscribe(result => {
            this.merchlist=result.items
        })
        this._vendorService.getVendorsByFilter(null,null,0,null,null,99,0).subscribe(result =>{
            this.vendorlist=result.items
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
