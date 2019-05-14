import { VendorForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { VendorServiceProxy, VendorTypeServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewVendorModal',
    templateUrl: './view-vendor-modal.component.html'
})

export class ViewVendorModalComponent extends AppComponentBase {

    vendor : VendorForViewDto = new VendorForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    // list vendortype
    vendortypeList: any[];

    constructor(
        injector: Injector,
        private _vendorService: VendorServiceProxy,
        private _vendortypeService: VendorTypeServiceProxy
    ) {
        super(injector);
    }

    show(vendorId?: number | null | undefined): void {
        this._vendorService.getVendorForView(vendorId).subscribe(result => {
            this.vendor = result;
            this.modal.show();
        });
        this._vendortypeService.getVendorTypesByFilter(null, null, null, null, 99, 0,
        ).subscribe(result => {
            this.vendortypeList = result.items;
        });
    }

    close() : void{
        this.modal.hide();
    }
    getVendorTypeName(TypeID): String {
        for (let vendortype of this.vendortypeList) {
            if (vendortype.id == TypeID) {
                return vendortype.name;
            }
        }
        return "";
    }
}
