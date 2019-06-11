import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { VehicleModelServiceProxy, VehicleModelInput } from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'createOrEditVehicleModelModal',
    templateUrl: './create-or-edit-vehicle-model-modal.component.html'
})
export class CreateOrEditVehicleModelModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('vehicleModelCombobox') vehicleModelCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    vehicleModel: VehicleModelInput = new VehicleModelInput();

    constructor(
        injector: Injector,
        private _vehicleModelService: VehicleModelServiceProxy
    ) {
        super(injector);
    }

    show(vehicleModelId?: number | null | undefined): void {
        this.saving = false;

        this._vehicleModelService.getVehicleModelForEdit(vehicleModelId).subscribe(result => {
            this.vehicleModel = result;
            this.modal.show();

        })
    }

    save(): void {
        
        let input = this.vehicleModel;
        this.saving = true;
        this._vehicleModelService.createOrEditVehicleModel(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
