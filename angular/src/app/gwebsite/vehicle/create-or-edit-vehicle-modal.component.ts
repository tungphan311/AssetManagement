import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { VehicleServiceProxy, VehicleInput } from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'createOrEditVehicleModal',
    templateUrl: './create-or-edit-vehicle-modal.component.html'
})
export class CreateOrEditVehicleModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('vehicleCombobox') vehicleCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    vehicle: VehicleInput = new VehicleInput();
    date: Date = new Date();

    constructor(
        injector: Injector,
        private _vehicleService: VehicleServiceProxy
    ) {
        super(injector);
    }

    show(vehicleId?: number | null | undefined): void {
        this.saving = false;

        this._vehicleService.getVehicleForEdit(vehicleId).subscribe(result => {
            this.vehicle = result;
            this.modal.show();

        })
    }

    save(): void {
        
        let input = this.vehicle;
        this.saving = true;
        this._vehicleService.createOrEditVehicle(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
