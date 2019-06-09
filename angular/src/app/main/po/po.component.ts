import { AppComponentBase } from "@shared/common/app-component-base";
import { Injector, Component } from "@angular/core";
import { appModuleAnimation } from "@shared/animations/routerTransition";

@Component({
    templateUrl: './po.component.html',
    animations: [appModuleAnimation()]
})

export class POCOmponent extends AppComponentBase {

    constructor(
        injector: Injector
    ) {
        super(injector);
    }

}