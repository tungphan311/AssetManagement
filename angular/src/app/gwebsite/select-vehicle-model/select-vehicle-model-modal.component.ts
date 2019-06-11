import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { VehicleModelServiceProxy, VehicleModelForViewDto } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

import { ElementRef,  OnInit, EventEmitter, Output } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';

@Component({
    selector: 'selectVehicleModelModal',
    templateUrl: './select-vehicle-model-modal.component.html'
})

export class SelectVehicleModelModalComponent extends AppComponentBase {

    vehicleModel: VehicleModelForViewDto = new VehicleModelForViewDto();

    @ViewChild('viewModal') modal: ModalDirective;

    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('vehicleModelCombobox') vehicleModelCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    constructor(
        injector: Injector,
        private _vehicleModelService: VehicleModelServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);
    }

    show(): void {
        this.reloadPage();
        this.modal.show();
    }

    close() : void{
        this.modal.hide();
    }

    selectId(id?: number | null | undefined) : void{
        this._vehicleModelService.getVehicleModelForView(id).subscribe(result => {
            this.vehicleModel = result;
            this.modalSave.emit(null);
            this.close();
        })
    }

    /**
     * tạo các biến dể filters
     */
    vehicleModelName: string;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

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

    /**
     * Hàm get danh sách VehicleModel
     * @param event
     */
    getVehicleModels(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null, event);

    }

    reloadList(vehicleModelName, event?: LazyLoadEvent) {
        this._vehicleModelService.getVehicleModelsByFilter(vehicleModelName, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.vehicleModelName = params['model'] || '';
            this.reloadList(this.vehicleModelName, null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.vehicleModelName, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }

}