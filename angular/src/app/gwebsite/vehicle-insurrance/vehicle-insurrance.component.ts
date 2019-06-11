import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild} from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { VehicleInsurranceServiceProxy, VehicleInsurranceInput, VehicleInsurranceForViewDto, PagedResultDtoOfAssetDto, } from '@shared/service-proxies/service-proxies';

import { SelectVehicleModalComponent } from '../select-vehicle/select-vehicle-modal.component'

import { DemoUiComponentsServiceProxy } from '@shared/service-proxies/service-proxies';

import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';

import * as moment from 'moment';

@Component({
    templateUrl: './vehicle-insurrance.component.html',
    animations: [appModuleAnimation()]
})
export class VehicleInsurranceComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */

    @ViewChild('selectVehicleModal') modal: SelectVehicleModalComponent;
    @ViewChild('vehicleInsurranceCombobox') vehicleInsurranceCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    vehicleRInsurranceForView: VehicleInsurranceForViewDto = new VehicleInsurranceForViewDto();

    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;

    saving = false;

    vehicleInsurrance: VehicleInsurranceInput = new VehicleInsurranceInput();

    constructor(
        injector: Injector,
        private _vehicleInsurranceService: VehicleInsurranceServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private demoUiComponentsService: DemoUiComponentsServiceProxy,
    ) {
        super(injector);
    }

    selectVehicle(): void {
        this.modal.show();
    }

    fillSelected(): void {

        this.vehicleInsurrance.plateNumber = this.modal.vehicle.plateNumber;
        this._vehicleInsurranceService.getVehicleInsurranceNumber(this.vehicleInsurrance.plateNumber).subscribe(result => {
            this.vehicleInsurrance.insurranceNumber = result;
        })
        this.applyFilters();

        this.notify.info(this.l('GetSuccessfully'));
    }

    save(): void {
        if (this.vehicleInsurrance.plateNumber==null) {
            this.notify.info(this.l('SaveFailed'));
            return;
        }
        let input = this.vehicleInsurrance;
        this.saving = true;
        this._vehicleInsurranceService.createOrEditVehicleInsurrance(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.vehicleInsurrance = new VehicleInsurranceInput();
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
     * Hàm get danh sách VehicleOperation
     * @param event
     */
    getVehicleInsurrances(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(this.vehicleInsurrance.plateNumber, event);

    }

    reloadList(plateNumber, event?: LazyLoadEvent) {
        if (plateNumber == null){
            this.primengTableHelper.totalRecordsCount = 0;
            this.primengTableHelper.records = new PagedResultDtoOfAssetDto().items;
            this.primengTableHelper.hideLoadingIndicator();
            return;
        }
        this._vehicleInsurranceService.getVehicleInsurrancesByFilter(plateNumber, this.primengTableHelper.getSorting(this.dataTable),
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
        this.reloadList(this.vehicleInsurrance.plateNumber, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    GetVehicleInsurranceForEdit(id?: number | null | undefined): void {
        this._vehicleInsurranceService.getVehicleInsurranceForEdit(id).subscribe(result => {
            this.vehicleInsurrance = result;
            this.notify.info(this.l('GetSuccessfully'));
        })
    }

    deleteVehicleInsurrance(id): void {
        this._vehicleInsurranceService.deleteVehicleInsurrance(id).subscribe(() => {
            this.reloadPage();
        })
    }
    
    // Thay đổi expirationDate khi registerDuration thay đổi
    onSearchChange(searchValue : number ) {  
        this.vehicleInsurrance.insurranceDuration.toString();
        if (this.vehicleInsurrance.plateNumber == null || searchValue == null) 
            return;
        if (this.vehicleInsurrance.insurranceDuration < 0) 
            this.vehicleInsurrance.insurranceDuration = 0;
        this.vehicleInsurrance.expirationDate = moment(this.vehicleInsurrance.date).add(this.vehicleInsurrance.insurranceDuration, 'M');
        this.vehicleInsurrance.expirationDate.format('DD-MM-YYYY');
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
