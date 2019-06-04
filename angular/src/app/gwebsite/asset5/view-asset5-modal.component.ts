import { Asset5ForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { Asset5ServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewAsset5Modal',
    templateUrl: './view-asset5-modal.component.html'
})

export class ViewAsset5ModalComponent extends AppComponentBase {

    asset5 : Asset5ForViewDto = new Asset5ForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _asset5Service: Asset5ServiceProxy
    ) {
        super(injector);
    }

    show(asset5Id?: number | null | undefined): void {
        this._asset5Service.getAsset5ForView(asset5Id).subscribe(result => {
            this.asset5 = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}