import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild} from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { VehicleRegistryServiceProxy, VehicleRegistryInput, VehicleRegistryForViewDto, PagedResultDtoOfAssetDto, } from '@shared/service-proxies/service-proxies';

import { SelectVehicleModalComponent } from '../select-vehicle/select-vehicle-modal.component'

import { DemoUiComponentsServiceProxy } from '@shared/service-proxies/service-proxies';

import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';

import * as moment from 'moment';

@Component({
    templateUrl: './vehicle-registry.component.html',
    animations: [appModuleAnimation()]
})
export class VehicleRegistryComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */

    @ViewChild('selectVehicleModal') modal: SelectVehicleModalComponent;
    @ViewChild('vehicleRegistryCombobox') vehicleRegistryCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    vehicleRegistryForView: VehicleRegistryForViewDto = new VehicleRegistryForViewDto();

    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;

    saving = false;

    vehicleRegistry: VehicleRegistryInput = new VehicleRegistryInput();

    constructor(
        injector: Injector,
        private _vehicleRegistryService: VehicleRegistryServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private demoUiComponentsService: DemoUiComponentsServiceProxy,
    ) {
        super(injector);
    }

    selectVehicle(): void {
        this.modal.show();
    }

    fillSelected(): void {

        this.vehicleRegistry.plateNumber = this.modal.vehicle.plateNumber;
        this._vehicleRegistryService.getVehicleRegistryNumber(this.vehicleRegistry.plateNumber).subscribe(result => {
            this.vehicleRegistry.registerNumber = result;
        })

        this.applyFilters();

        this.notify.info(this.l('GetSuccessfully'));
    }

    save(): void {
        if (this.vehicleRegistry.plateNumber==null) {
            this.notify.info(this.l('SaveFailed'));
            return;
        }
        let input = this.vehicleRegistry;
        this.saving = true;
        this._vehicleRegistryService.createOrEditVehicleRegistry(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.vehicleRegistry= new VehicleRegistryInput();
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
     * Hàm get danh sách vehicleRegistry
     * @param event
     */
    getVehicleRegistries(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(this.vehicleRegistry.plateNumber, event);

    }

    reloadList(plateNumber, event?: LazyLoadEvent) {
        if (plateNumber == null){
            this.primengTableHelper.totalRecordsCount = 0;
            this.primengTableHelper.records = new PagedResultDtoOfAssetDto().items;
            this.primengTableHelper.hideLoadingIndicator();
            return;
        }
        this._vehicleRegistryService.getVehicleRegistriesByFilter(plateNumber, this.primengTableHelper.getSorting(this.dataTable),
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
        this.reloadList(this.vehicleRegistry.plateNumber, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    GetVehicleRegistryForEdit(id?: number | null | undefined): void {
        this._vehicleRegistryService.getVehicleRegistryForEdit(id).subscribe(result => {
            this.vehicleRegistry = result;
            this.notify.info(this.l('GetSuccessfully'));
        })
    }

    deleteVehicleRegistry(id): void {
        this._vehicleRegistryService.deleteVehicleRegistry(id).subscribe(() => {
            this.reloadPage();
        })
    }

    // Thay đổi expirationDate khi registerDuration thay đổi
    onSearchChange(searchValue : number ) {  
        this.vehicleRegistry.registerDuration.toString();
        if (this.vehicleRegistry.plateNumber == null || searchValue == null) 
            return;
        if (this.vehicleRegistry.registerDuration < 0) 
            this.vehicleRegistry.registerDuration = 0;
        this.vehicleRegistry.expirationDate = moment(this.vehicleRegistry.date).add(this.vehicleRegistry.registerDuration, 'M');
        this.vehicleRegistry.expirationDate.format('DD-MM-YYYY');
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
