import { TSThueForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { TSThueServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewTSThueModal',
    templateUrl: './view-tsthue-modal.component.html'
})

export class ViewTSThueModalComponent extends AppComponentBase {

    tsthue : TSThueForViewDto = new TSThueForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _tsthueService: TSThueServiceProxy
    ) {
        super(injector);
    }

    show(tsthueId?: number | null | undefined): void {
        this._tsthueService.getTSThueForView(tsthueId).subscribe(result => {
            this.tsthue = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}
