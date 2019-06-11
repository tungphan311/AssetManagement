import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild} from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { VehicleOperationServiceProxy, VehicleOperationInput, VehicleOperationForViewDto, PagedResultDtoOfAssetDto } from '@shared/service-proxies/service-proxies';

import { SelectVehicleModalComponent } from '../select-vehicle/select-vehicle-modal.component'

import { DemoUiComponentsServiceProxy } from '@shared/service-proxies/service-proxies';

import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';

@Component({
    templateUrl: './vehicle-operation.component.html',
    animations: [appModuleAnimation()]
})
export class VehicleOperationComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */

    @ViewChild('selectVehicleModal') modal: SelectVehicleModalComponent;
    @ViewChild('vehicleOperationCombobox') vehicleOperationCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    vehicleOperationForView: VehicleOperationForViewDto = new VehicleOperationForViewDto();

    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;

    saving = false;

    vehicleOperation: VehicleOperationInput = new VehicleOperationInput();

    constructor(
        injector: Injector,
        private _vehicleOperationService: VehicleOperationServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private demoUiComponentsService: DemoUiComponentsServiceProxy,
    ) {
        super(injector);
    }

    selectVehicle(): void {
        this.modal.show();
    }

    fillSelected(): void {

        this.vehicleOperation.plateNumber = this.modal.vehicle.plateNumber;
        this.vehicleOperation.fuelNorm = this.modal.vehicle.fuelNorms;

        this.applyFilters();

        this.notify.info(this.l('GetSuccessfully'));
    }

    save(): void {
        if (this.vehicleOperation.plateNumber==null) {
            this.notify.info(this.l('SaveFailed'));
            return;
        }
        let input = this.vehicleOperation;
        this.saving = true;
        this._vehicleOperationService.createOrEditVehicleOperation(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.vehicleOperation = new VehicleOperationInput();
            this.reloadPage();
        })
        this.saving = false;
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
     * Hàm get danh sách VehicleOperation
     * @param event
     */
    getVehicleOperations(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(this.vehicleOperation.plateNumber, event);

    }

    reloadList(plateNumber, event?: LazyLoadEvent) {
        if (plateNumber == null){
            this.primengTableHelper.totalRecordsCount = 0;
            this.primengTableHelper.records = new PagedResultDtoOfAssetDto().items;
            this.primengTableHelper.hideLoadingIndicator();
            return;
        }
        this._vehicleOperationService.getVehicleOperationsByFilter(plateNumber, this.primengTableHelper.getSorting(this.dataTable),
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
        this.reloadList(this.vehicleOperation.plateNumber, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    GetVehicleOperationForEdit(id?: number | null | undefined): void {
        this._vehicleOperationService.getVehicleOperationForEdit(id).subscribe(result => {
            this.vehicleOperation = result;
            this.notify.info(this.l('GetSuccessfully'));
        })
    }

    deleteVehicleOperation(id): void {
        this._vehicleOperationService.deleteVehicleOperation(id).subscribe(() => {
            this.reloadPage();
        })
    }

    // Thay đổi KmGone khi VehicleIndex thay đổi
    onSearchChange(searchValue : number ) {  
        this.vehicleOperation.vehicleIndex.toString();
        if (this.vehicleOperation.plateNumber == null || searchValue == null) return;
        if (searchValue < 0) this.vehicleOperation.vehicleIndex = 0;
        this._vehicleOperationService.getLatestVehicleIndex(searchValue, this.vehicleOperation.id, this.vehicleOperation.plateNumber).subscribe(result => {
            this.vehicleOperation.kmGone = searchValue - result;
            this.vehicleOperation.realConsumption = this.vehicleOperation.fuelNorm * this.vehicleOperation.kmGone / 100;
        });
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
