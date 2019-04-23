import { VendorTypeForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { VendorTypeServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewVendorTypeModal',
    templateUrl: './view-vendortype-modal.component.html'
})

export class ViewVendorTypeModalComponent extends AppComponentBase {

    vendortype : VendorTypeForViewDto = new VendorTypeForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _vendortypeService: VendorTypeServiceProxy
    ) {
        super(injector);
    }

    show(vendortypeId?: number | null | undefined): void {
        this._vendortypeService.getVendorTypeForView(vendortypeId).subscribe(result => {
            this.vendortype = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}
