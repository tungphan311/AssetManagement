import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild, EventEmitter, Output } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { VehicleServiceProxy, VehicleInput, AttachedDeviceServiceProxy , AttachedDeviceForViewDto, PagedResultDtoOfAssetDto, VehicleModelServiceProxy, VehicleModelDto, VehicleModelForViewDto } from '@shared/service-proxies/service-proxies';

import { ModalDirective } from 'ngx-bootstrap';
import { modalConfigDefaults } from 'ngx-bootstrap/modal/modal-options.class';
import { SelectAssetIdModalComponent } from '../select-asset/select-assetid-modal.component'
import { SelectVehicleModelModalComponent } from '../select-vehicle-model/select-vehicle-model-modal.component'

import { DemoUiComponentsServiceProxy } from '@shared/service-proxies/service-proxies';

import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';

import { CreateOrEditAttachedDeviceModalComponent } from './create-or-edit-attacheddevice-modal.component'


@Component({
    templateUrl: './vehicleinfo.component.html',
    animations: [appModuleAnimation()]
})
export class VehicleInfoComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */

    @ViewChild('selectAssetIdModal') modal: SelectAssetIdModalComponent;
    @ViewChild('selectVehicleModelModal') vehicleModelModal: SelectVehicleModelModalComponent;
    @ViewChild('vehicleCombobox') vehicleCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    attachedDevice: AttachedDeviceForViewDto = new AttachedDeviceForViewDto();

    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('attachedDeviceCombobox') attachedDeviceCombobox: ElementRef;

    @ViewChild('createOrEditAttachedDeviceModal') createOrEditAttachedDeviceModal: CreateOrEditAttachedDeviceModalComponent;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    vehicle: VehicleInput = new VehicleInput();
    vehicleModel: VehicleModelForViewDto = new VehicleModelForViewDto();

    constructor(
        injector: Injector,
        private _vehicleService: VehicleServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private demoUiComponentsService: DemoUiComponentsServiceProxy,
        private _attachedDeviceService: AttachedDeviceServiceProxy,
        private _vehicleModelService: VehicleModelServiceProxy,
    ) {
        super(injector);
    }

    selectAssetId(): void {
        this.modal.show();
    }
    selectVehicleModel(): void {
        this.vehicleModelModal.show();
    }

    fillSelectedAssetId(): void {
        this._vehicleService.getVehicleByAssetForEdit(this.modal.asset.assetId).subscribe(result => {
            this.vehicle = result;
            this.vehicle.assetId = this.modal.asset.assetId;

            this.applyFilters();

            this.notify.info(this.l('GetSuccessfully'));
        })
    }

    fillSelectedVehicleModel(): void {
        this.vehicleModel = this.vehicleModelModal.vehicleModel;
        this.vehicle.model = this.vehicleModel.model;
        this.vehicle.type = this.vehicleModel.type;
        this.vehicle.manufacturer = this.vehicleModel.manufacturer;
        this.vehicle.tireSize = this.vehicleModel.tireSize;
        this.vehicle.fuelType = this.vehicleModel.fuelType;
        this.vehicle.engineType = this.vehicleModel.engineType;
        this.vehicle.gearboxType = this.vehicleModel.gearboxType;
        this.vehicle.fuelNorms = this.vehicleModel.fuelNorms;
        this.vehicle.engineVolume = this.vehicleModel.engineVolume;
        this.vehicle.length = this.vehicleModel.length;
        this.vehicle.height = this.vehicleModel.height;
        this.vehicle.horizontalLength = this.vehicleModel.horizontalLength;
        this.notify.info(this.l('GetSuccessfully'));
    }

    save(): void {
        if (this.vehicle.assetId==null) {
            this.notify.info(this.l('SaveFailed'));
            return;
        }
        let input = this.vehicle;
        this.saving = true;
        this._vehicleService.createOrEditVehicle(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.vehicle = new VehicleInput();
            this.saving = false;
        })
    }

    /**
     * Hàm xử lý trước khi View được init
     */
    ngOnInit(): void {
    }

    /**
     * Hàm xử lý sau khi View được init
     */
    ngAfterViewInit(): void {
        setTimeout(() => {
            this.init();
        });
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.vehicle.plateNumber = params['plateNumber'] || '';
            this.reloadList(null, null);
        });
    }

    /**
     * Hàm get danh sách AttachedDevice và Vehicle Model
     * @param event
     */
    getAttachedDevices(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(this.vehicle.plateNumber, event);

    }

    reloadList(plateNumber, event?: LazyLoadEvent) {
        if (this.vehicle.assetId == null || plateNumber == null){
            this.primengTableHelper.totalRecordsCount = 0;
            this.primengTableHelper.records = new PagedResultDtoOfAssetDto().items;
            this.primengTableHelper.hideLoadingIndicator();
            return;
        }
        this._attachedDeviceService.getAttachedDevicesByFilter(plateNumber, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.vehicle.plateNumber, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    //hàm show view create MenuClient
    createOrEditAttachedDevice(id?: number | null | undefined): void {
        if (this.vehicle.assetId == null){
            return;
        }
        this.createOrEditAttachedDeviceModal.show(id, this.vehicle.plateNumber);
    }

    deleteAttachedDevice(id): void {
        this._attachedDeviceService.deleteAttachedDevice(id).subscribe(() => {
            this.reloadPage();
        })
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
