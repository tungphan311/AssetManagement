import { Component, ViewChild, Injector } from "@angular/core";
import { AppComponentBase } from "@shared/common/app-component-base";
import { ModalDirective } from "ngx-bootstrap";

@Component({
    selector: 'addMerchandiseToPO',
    templateUrl: './add-merchandise-to-po.component.html'
})

export class AddMerchandiseToPOComponent extends AppComponentBase {
    @ViewChild('addMerchandiseToPO') addMerchandiseToPO: ModalDirective;

    saving = false;

    constructor (
        injector: Injector
    ) {
        super(injector);
    }

    show() {
        this.saving = false;
        this.addMerchandiseToPO.show();
    }
}