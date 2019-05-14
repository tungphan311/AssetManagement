import { Component, Injector } from "@angular/core";
import { AppComponentBase } from "@shared/common/app-component-base";

@Component({
    selector: 'createOrEditContractModal',
    templateUrl: './create-or-edit-contract-modal.component.html'
})

export class CreateOrEditContractModalComponent extends AppComponentBase {
    constructor(
        injector: Injector
    ) {
        super(injector);
    }
}