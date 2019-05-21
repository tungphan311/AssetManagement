import { Component, Injector } from "@angular/core";
import { AppComponentBase } from "@shared/common/app-component-base";

@Component({
    selector: 'viewContractModal',
    templateUrl: './view-contract-modal.component.html'
})

export class ViewAssignmentTableModalComponent extends AppComponentBase {
    constructor(
        injector: Injector
    ) {
        super(injector);
    }
}
