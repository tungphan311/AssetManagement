import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild, EventEmitter, Output } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { VehicleRepairServiceProxy, VehicleRepairInput , PagedResultDtoOfAssetDto, } from '@shared/service-proxies/service-proxies';

import { ModalDirective } from 'ngx-bootstrap';
import { modalConfigDefaults } from 'ngx-bootstrap/modal/modal-options.class';
import { SelectAssetIdModalComponent } from './../select-asset/select-assetid-modal.component'

import { DemoUiComponentsServiceProxy } from '@shared/service-proxies/service-proxies';

import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';

import { CreateOrEditVehicleRepairModalComponent } from './create-or-edit-repair-update-modal.component'


@Component({
    templateUrl: './vehicle-repair.component.html',
    animations: [appModuleAnimation()]

})
export class VehicleRepairComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */

    @ViewChild('selectAssetIdModal') modal: SelectAssetIdModalComponent;
    @ViewChild('vehicleRepairCombobox') vehicleRepairCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

  

    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;

    @ViewChild('createOrEditVehicleRepairModal') createOrEditVehicleRepairModal: CreateOrEditVehicleRepairModalComponent;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    vehicleRepair: VehicleRepairInput = new VehicleRepairInput();

    constructor(
        injector: Injector,
        private _vehicleRepairService: VehicleRepairServiceProxy,
        private _activatedRoute: ActivatedRoute,
        private demoUiComponentsService: DemoUiComponentsServiceProxy,

    ) {
        super(injector);
    }

    selectAssetId(): void {
        this.modal.show();
    }

    fillSelected(): void {
       

            this.vehicleRepair.assetId = this.modal.asset.assetId;
            this.vehicleRepair.assetName = this.modal.asset.assetName;

            this.applyFilters();

            this.notify.info(this.l('GetSuccessfully'));

    }

    save(): void {
        if (this.vehicleRepair.assetId==null) {
            this.notify.info(this.l('SaveFailed'));
            return;
        }
        let input = this.vehicleRepair;
        this.saving = true;
        this._vehicleRepairService.createOrEditVehicleRepair(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.vehicleRepair = new VehicleRepairInput();
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
            this.vehicleRepair.assetId = params['assetId'] || '';
            this.reloadList(null, null);
        });
    }

    /**
     * Hàm get danh sách VehicleRepair
     * @param event
     */
    getVehicleRepairs(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(this.vehicleRepair.assetId, event);

    }

    reloadList(assetId, event?: LazyLoadEvent) {
        if (this.vehicleRepair.assetId == null || assetId == null){
            this.primengTableHelper.totalRecordsCount = 0;
            this.primengTableHelper.records = new PagedResultDtoOfAssetDto().items;
            this.primengTableHelper.hideLoadingIndicator();
            return;
        }
        this._vehicleRepairService.getVehicleRepairsByFilter(assetId, this.primengTableHelper.getSorting(this.dataTable),
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
        this.reloadList(this.vehicleRepair.assetId, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    //hàm show view create MenuClient
    createOrEditVehicleRepair(id?: number | null | undefined): void {
        if (this.vehicleRepair.assetId == null){
            return;
        }
        //this.createOrEditVehicleRepairModal.show(id);
        this._vehicleRepairService.getVehicleRepairForEdit(id).subscribe(result => {
            this.vehicleRepair = result;
        })
    }

    deleteVehicleRepair(id): void {
        this._vehicleRepairService.deleteVehicleRepair(id).subscribe(() => {
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
