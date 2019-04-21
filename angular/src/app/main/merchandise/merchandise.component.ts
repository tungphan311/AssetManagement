import { Component, Injector, AfterViewInit, OnInit } from "@angular/core";
import { appModuleAnimation } from "@shared/animations/routerTransition";
import { AppComponentBase } from "@shared/common/app-component-base";
import { Router, ActivatedRoute } from "@angular/router";
import { WebApiServiceProxy } from "@shared/service-proxies/webapi.service";
import { MerchandiseControlllerServiceProxy, MerchandiseListDto, ListResultDtoOfMerchandiseListDto } from '@shared/service-proxies/service-proxies'
import * as _ from "lodash";
 
@Component({
    templateUrl: './merchandise.component.html',
    animations: [appModuleAnimation()],
    styleUrls: ['./merchandise.component.less'],
    providers: [MerchandiseControlllerServiceProxy]
})

export class MerchandiseComponent extends AppComponentBase implements OnInit {
    merchandises: MerchandiseListDto[] = [];
    mer: String = 'Tung'
    filter: string = '';

    constructor(
        injector: Injector,
        private _merchandiseService: MerchandiseControlllerServiceProxy
    ) {
        super(injector)
    }

    ngOnInit(): void {
        this._merchandiseService.getMerchandise(this.filter).subscribe((result) => {
            this.merchandises = result.items;
           // this.mer = this.merchandises[0];
        });
    }

    deleteMerchandise(merchandise: MerchandiseListDto): void {
        this.message.confirm(
            this.l('AreYouSureToDeleteTheMerchandise'),
            isConfirmed => {
                if (isConfirmed) {
                    this._merchandiseService.deleteMerchandise(merchandise.id).subscribe(() => {
                        this.notify.info(this.l('SuccessfullyDeleted'));
                        _.remove(this.merchandises, merchandise);
                    });
                }
            }
        )
    }
}