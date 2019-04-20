import { Component, Injector, AfterViewInit, OnInit } from "@angular/core";
import { appModuleAnimation } from "@shared/animations/routerTransition";
import { AppComponentBase } from "@shared/common/app-component-base";
import { Router, ActivatedRoute } from "@angular/router";
import { WebApiServiceProxy } from "@shared/service-proxies/webapi.service";

@Component({
    templateUrl: './merchandise.component.html',
    animations: [appModuleAnimation()] 
})

export class MerchandiseComponent extends AppComponentBase {
    constructor(
        injector: Injector
    ) {
        super(injector)
    }
}