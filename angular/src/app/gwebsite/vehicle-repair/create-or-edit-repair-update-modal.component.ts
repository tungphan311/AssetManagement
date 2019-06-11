import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { VehicleRepairServiceProxy, VehicleRepairInput } from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'createOrEditVehicleRepairModal',
    templateUrl: './create-or-edit-repair-update-modal.component.html'
})
export class CreateOrEditVehicleRepairModalComponent extends AppComponentBase {


    @ViewChild('createOrEditVehicleRepairModal') modal: ModalDirective;
    @ViewChild('vehicleRepairCombobox') vehicleRepairCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    vehicleRepair: VehicleRepairInput = new VehicleRepairInput();

    constructor(
        injector: Injector,
        private _vehicleRepairService: VehicleRepairServiceProxy
    ) {
        super(injector);
    }

    show(vehicleRepairId?: number | null | undefined): void {
        this.saving = false;

        this._vehicleRepairService.getVehicleRepairForEdit(vehicleRepairId).subscribe(result => {
            this.vehicleRepair = result;
            this.modal.show();

        })
    }

    save(): void {
        
        let input = this.vehicleRepair;
        this.saving = true;
        this._vehicleRepairService.createOrEditVehicleRepair(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
