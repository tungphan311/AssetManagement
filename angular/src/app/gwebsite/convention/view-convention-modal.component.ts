////import { conventionForViewDto } from '../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
//import { conventionServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewconventionModal',
    templateUrl: './view-convention-modal.component.html'
})

export class ViewconventionModalComponent extends AppComponentBase {

    //convention : conventionForViewDto = new conventionForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
       // private _conventionService: conventionServiceProxy
    ) {
        super(injector);
    }

    // show(conventionId?: number | null | undefined): void {
    //    // this._conventionService.getconventionForView(conventionId).subscribe(result => {
    //         //this.convention = result;
    //         this.modal.show();
    //     })
    // }

    // close() : void{
    //     this.modal.hide();
    // }
}