import { VendorForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { VendorServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewVendorModal',
    templateUrl: './view-vendor-modal.component.html'
})

export class ViewVendorModalComponent extends AppComponentBase {

    vendor : VendorForViewDto = new VendorForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _vendorService: VendorServiceProxy
    ) {
        super(injector);
    }

    show(vendorId?: number | null | undefined): void {
        this._vendorService.getVendorForView(vendorId).subscribe(result => {
            this.vendor = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}
