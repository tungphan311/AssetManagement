
import { ViewProjectModalComponent } from './view-project-modal.component';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { ProjectServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditProjectModalComponent } from './create-or-edit-project-modal.component';


@Component({
    templateUrl: './project.component.html',
    animations: [appModuleAnimation()]
})

export class ProjectComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditProjectModalComponent;
    @ViewChild('viewProjectModal') viewProjectModal: ViewProjectModalComponent;

    /**
     * tạo các biến dể filters
     */
    projectCode: string;
    projectName: string;
    projectDate: string;

    constructor(
        injector: Injector,
        private _projectService: ProjectServiceProxy,
        private _activatedRoute: ActivatedRoute,

    ) {
        super(injector);
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

    /**
     * Hàm get danh sách Project
     * @param event
     */
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

    deleteProject(id): void {
        this._projectService.deleteProject(id).subscribe(() => {
            this.reloadPage();
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.projectCode = params['code'] || '';
            this.projectName = params['name'] || '';
            this.projectDate = params['date'] || '';
            this.reloadList(this.projectCode, this.projectName, this.projectDate, null);
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

    //hàm show view create MenuClient
    createProject() {
        this.createOrEditModal.show();
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
}
