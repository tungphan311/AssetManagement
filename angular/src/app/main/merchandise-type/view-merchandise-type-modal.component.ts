import { AppComponentBase } from "@shared/common/app-component-base";
import { Component, ViewChild, Injector } from "@angular/core";
import { MerchandiseTypeForViewDto, MerchandiseTypeServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from "ngx-bootstrap";

@Component({
    selector: 'viewMerchandiseTypeModal',
    templateUrl: './view-merchandise-type-modal.component.html'
})

export class ViewMerchandiseTypeModalComponent extends AppComponentBase {
    merchandiseType: MerchandiseTypeForViewDto = new MerchandiseTypeForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _merchandiseTypeService: MerchandiseTypeServiceProxy
    ) {
        super(injector);
    }

    show(merchandiseTypeId?: number | null | undefined): void {
        this._merchandiseTypeService.getMerchandiseTypeForView(merchandiseTypeId).subscribe(result => {
            this.merchandiseType = result;
            this.modal.show();
        })
    }

    close(): void {
        this.modal.hide();
    }
}