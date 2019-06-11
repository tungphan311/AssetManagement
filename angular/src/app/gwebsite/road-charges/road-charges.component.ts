import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild} from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { RoadChargesServiceProxy, RoadChargesInput, RoadChargesForViewDto, PagedResultDtoOfAssetDto, } from '@shared/service-proxies/service-proxies';

import { SelectVehicleModalComponent } from '../select-vehicle/select-vehicle-modal.component'

import { DemoUiComponentsServiceProxy } from '@shared/service-proxies/service-proxies';

import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';

@Component({
    templateUrl: './road-charges.component.html',
    animations: [appModuleAnimation()]
})
export class RoadChargesComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */

    @ViewChild('selectVehicleModal') modal: SelectVehicleModalComponent;
    @ViewChild('roadChargesCombobox') roadChargesCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    roadChargesForView: RoadChargesForViewDto = new RoadChargesForViewDto();

    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;

    saving = false;

    roadCharges: RoadChargesInput = new RoadChargesInput();

    constructor(
        injector: Injector,
        private _roadChargesService: RoadChargesServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);
    }

    selectVehicle(): void {
        this.modal.show();
    }

    fillSelected(): void {

        this.roadCharges.plateNumber = this.modal.vehicle.plateNumber;

        this.applyFilters();

        this.notify.info(this.l('GetSuccessfully'));
    }

    save(): void {
        if (this.roadCharges.plateNumber==null) {
            this.notify.info(this.l('SaveFailed'));
            return;
        }
        let input = this.roadCharges;
        this.saving = true;
        this._roadChargesService.createOrEditRoadCharges(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.roadCharges = new RoadChargesInput();
            this.saving = false;
            this.reloadPage();
            this.applyFilters();
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
     * Hàm get danh sách RoadCharges
     * @param event
     */
    getRoadCharges(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(this.roadCharges.plateNumber, event);

    }

    reloadList(plateNumber, event?: LazyLoadEvent) {
        if (plateNumber == null){
            this.primengTableHelper.totalRecordsCount = 0;
            this.primengTableHelper.records = new PagedResultDtoOfAssetDto().items;
            this.primengTableHelper.hideLoadingIndicator();
            return;
        }
        this._roadChargesService.getRoadChargessByFilter(plateNumber, this.primengTableHelper.getSorting(this.dataTable),
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
        this.reloadList(this.roadCharges.plateNumber, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    GetRoadChargesForEdit(id?: number | null | undefined): void {
        this._roadChargesService.getRoadChargesForEdit(id).subscribe(result => {
            this.roadCharges = result;
            this.notify.info(this.l('GetSuccessfully'));
        })
    }

    deleteRoadCharges(id): void {
        this._roadChargesService.deleteRoadCharges(id).subscribe(() => {
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
