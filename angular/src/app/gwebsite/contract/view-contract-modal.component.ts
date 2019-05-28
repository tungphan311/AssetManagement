////import { contractForViewDto } from '../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
//import { contractServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';
import { ContractServiceProxy } from "@shared/service-proxies/service-proxies";
import { ContractForViewDto } from './../../../shared/service-proxies/service-proxies';
@Component({
    selector: 'viewContractModal',
    templateUrl: './view-contract-modal.component.html'
})

export class ViewContractModalComponent extends AppComponentBase {

    contract : ContractForViewDto = new ContractForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _contractService: ContractServiceProxy
    ) {
        super(injector);
    }

    show(contractId?: number | null | undefined): void {
        this._contractService.getContractForView(contractId).subscribe(result => {
            this.contract = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}