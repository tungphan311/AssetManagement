import { CustomerForViewDto, MerchandiseForViewDto, MerchandiseTypeServiceProxy } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { MerchandiseServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewMerchandiseModal',
    templateUrl: './view-merchandise-modal.component.html'
})

export class ViewMerchandiseModalComponent extends AppComponentBase {
    merchandise : MerchandiseForViewDto = new MerchandiseForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    merType = []

    constructor(
        injector: Injector,
        private _merchandiseService: MerchandiseServiceProxy,
        private _merTypeService: MerchandiseTypeServiceProxy
    ) {
        super(injector);
    }

    show(merchandiseId?: number | null | undefined): void {
        this._merchandiseService.getMerchandiseForView(merchandiseId).subscribe(result => {
            this.merchandise = result;
            this.modal.show();
        })

        // this._merTypeService.getMerchandiseByFilter(null, null, 99, 0).subscribe(result => {
        //     this.merType = result.items
        // })
    }

    getTypeNames(id: number): any {
        for (const iterator of this.merType) {
            if (iterator.id === id) {
                return iterator.name;
            }
        }
    }

    close() : void{
        this.modal.hide();
    }
}