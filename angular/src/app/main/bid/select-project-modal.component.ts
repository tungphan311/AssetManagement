
import { Component, ElementRef, Injector, ViewChild, Output, EventEmitter } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { ModalDirective } from 'ngx-bootstrap';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { ProjectServiceProxy } from '@shared/service-proxies/service-proxies';


@Component({
    selector: 'selectProjectModal',
    templateUrl: './select-project-modal.component.html'
})

export class SelectProjectModalComponent extends AppComponentBase {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('selectProjectModal') selectProjectModal: ModalDirective;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    


    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;
    /**
     * tạo các biến dể filters
     */
    projectCode: string;
    projectName: string;
    projectDate: string;

    constructor(
        injector: Injector,
        private _projectService: ProjectServiceProxy
    ) {
        super(injector);
    }

    getProjects(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(null,null,null, event);

    }

    reloadList(projectId, projectName, projectDate, event?: LazyLoadEvent) {
        this._projectService.getProjectsByFilter(projectId,projectName,projectDate, this.primengTableHelper.getSorting(this.dataTable),
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
        this.reloadList(this.projectCode, this.projectName, this.projectDate, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    dateFormat(date): string {
        var moment = require('moment');
        //add timezone vào time :/ với cách éo thể nào ngu hơn đc =))
        var _date = moment(date);
        var tz = _date.utcOffset(); //lấy timezone đv phút
        _date.add(tz, 'm'); //add phút
        return _date.format('DD/MM/YYYY');
    }
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
    show(): void {
        this.saving = false;
        this.selectProjectModal.show();
    }

    save(projectID:number): void {
        this.saving = true;
        this.close(projectID);          
    }

    close(projectID:number): void {
        this.selectProjectModal.hide();
        this.modalSave.emit(projectID);
    }
}
