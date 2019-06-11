import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild} from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { VehicleMaintenanceServiceProxy, VehicleMaintenanceInput, VehicleMaintenanceForViewDto, PagedResultDtoOfAssetDto, } from '@shared/service-proxies/service-proxies';

import { SelectVehicleModalComponent } from './../select-vehicle/select-vehicle-modal.component'

import { DemoUiComponentsServiceProxy } from '@shared/service-proxies/service-proxies';

import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';

@Component({
    templateUrl: './vehicle-maintenance.component.html',
    animations: [appModuleAnimation()]
})
export class VehicleMaintenanceComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */

    @ViewChild('selectVehicleModal') modal: SelectVehicleModalComponent;
    @ViewChild('vehicleMaintenanceCombobox') vehicleMaintenanceCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    vehicleMaintenanceForView: VehicleMaintenanceForViewDto = new VehicleMaintenanceForViewDto();

    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;

    saving = false;

    vehicleMaintenance: VehicleMaintenanceInput = new VehicleMaintenanceInput();

    constructor(
        injector: Injector,
        private _vehicleMaintenanceService: VehicleMaintenanceServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private demoUiComponentsService: DemoUiComponentsServiceProxy,
    ) {
        super(injector);
    }

    selectVehicle(): void {
        this.modal.show();
    }

    fillSelected(): void {

        this.vehicleMaintenance.plateNumber = this.modal.vehicle.plateNumber;

        this._vehicleMaintenanceService.getVehicleMaintenanceNumber(this.vehicleMaintenance.plateNumber).subscribe(result => {
            this.vehicleMaintenance.numberMaintenanceTimes = result;
        })

        this.applyFilters();

        this.notify.info(this.l('GetSuccessfully'));
    }

    save(): void {
        if (this.vehicleMaintenance.plateNumber==null) {
            this.notify.info(this.l('SaveFailed'));
            return;
        }
        let input = this.vehicleMaintenance;
        this.saving = true;
        this._vehicleMaintenanceService.createOrEditVehicleMaintenance(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.vehicleMaintenance = new VehicleMaintenanceInput();
            this.saving = false;
            this.reloadPage();
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
            this.reloadList(null, null);
        });
    }

    /**
     * Hàm get danh sách VehicleMaintenance
     * @param event
     */
    getVehicleMaintenances(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(this.vehicleMaintenance.plateNumber, event);

    }

    reloadList(plateNumber, event?: LazyLoadEvent) {
        if (plateNumber == null){
            this.primengTableHelper.totalRecordsCount = 0;
            this.primengTableHelper.records = new PagedResultDtoOfAssetDto().items;
            this.primengTableHelper.hideLoadingIndicator();
            return;
        }
        this._vehicleMaintenanceService.getVehicleMaintenancesByFilter(plateNumber, this.primengTableHelper.getSorting(this.dataTable),
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
        this.reloadList(this.vehicleMaintenance.plateNumber, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    GetVehicleMaintenanceForEdit(id?: number | null | undefined): void {
        this._vehicleMaintenanceService.getVehicleMaintenanceForEdit(id).subscribe(result => {
            this.vehicleMaintenance = result;
            this.notify.info(this.l('GetSuccessfully'));
        })
    }

    deleteVehicleMaintenance(id): void {
        this._vehicleMaintenanceService.deleteVehicleMaintenance(id).subscribe(() => {
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
