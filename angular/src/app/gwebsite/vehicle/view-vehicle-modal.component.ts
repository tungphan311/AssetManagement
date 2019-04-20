import { VehicleForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { VehicleServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewVehicleModal',
    templateUrl: './view-vehicle-modal.component.html'
})

export class ViewVehicleModalComponent extends AppComponentBase {

    vehicle : VehicleForViewDto = new VehicleForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _vehicleService: VehicleServiceProxy
    ) {
        super(injector);
    }

    show(vehicleId?: number | null | undefined): void {
        this._vehicleService.getVehicleForView(vehicleId).subscribe(result => {
            this.vehicle = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}