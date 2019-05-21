import { AppComponentBase } from "@shared/common/app-component-base";
import { Component, Injector, OnInit, AfterViewInit, ViewChild } from "@angular/core";
import { appModuleAnimation } from "@shared/animations/routerTransition";
import { Table } from "primeng/table";
import { Paginator } from "primeng/primeng";

@Component({
    templateUrl: './project.component.html',
    animations: [appModuleAnimation()]
})

export class ProjectComponent extends AppComponentBase implements OnInit, AfterViewInit {
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    //@ViewChild('createOrEditModal') createOrEditModal: CreateOrEditMerchandiseModalComponent;

    constructor(
        injector: Injector
    ) {
        super(injector);
    }

    ngOnInit(): void {
        
    }
    ngAfterViewInit(): void {
        setTimeout(() => {
            this.init();
        });
    }

    init(): void {
        
    }
}