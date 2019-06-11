import { VehicleModelForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { VehicleModelServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewVehicleModelModal',
    templateUrl: './view-vehicle-model-modal.component.html'
})

export class ViewVehicleModelModalComponent extends AppComponentBase {

    vehicleModel : VehicleModelForViewDto = new VehicleModelForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _vehicleModelService: VehicleModelServiceProxy
    ) {
        super(injector);
    }

    show(vehicleModelId?: number | null | undefined): void {
        this._vehicleModelService.getVehicleModelForView(vehicleModelId).subscribe(result => {
            this.vehicleModel = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}