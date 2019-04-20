import { Component, Injector } from "@angular/core";
import { appModuleAnimation } from "@shared/animations/routerTransition";
import { AppComponentBase } from "@shared/common/app-component-base";

@Component({
    templateUrl: './assignment-table.component.html',
    animations: [appModuleAnimation()] 
})

export class AssignmentTableComponent extends AppComponentBase {
    constructor(
        injector: Injector
    ) {
        super(injector)
    }
}