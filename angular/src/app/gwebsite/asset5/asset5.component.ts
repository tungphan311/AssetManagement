import { ViewAsset5ModalComponent } from './view-asset5-modal.component';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { Asset5ServiceProxy } from '@shared/service-proxies/service-proxies';
import { CreateOrEditAsset5ModalComponent } from './create-or-edit-asset5-modal.component';

@Component({
    templateUrl: './asset5.component.html',
    animations: [appModuleAnimation()]
})

export class Asset5Component extends AppComponentBase implements AfterViewInit, OnInit {

    /**
    * @ViewChild là dùng get control và call thuộc tính, functions của control đó
    */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditAsset5ModalComponent;
    @ViewChild('viewAsset5Modal') viewAsset5Modal: ViewAsset5ModalComponent;

    /**
    * tạo các biến dể filters
    */
    asset5Name: string;

    constructor(
        injector: Injector,
        private _asset5Service: Asset5ServiceProxy,
        private _activatedRoute: ActivatedRoute,
    )  {
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
    * Hàm get danh sách Asset
    * @param event
    */
   getAsset5s(event?: LazyLoadEvent) {
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

reloadList(asset5Name, event?: LazyLoadEvent) {
    this._asset5Service.getAsset5sByFilter(asset5Name, this.primengTableHelper.getSorting(this.dataTable),
        this.primengTableHelper.getMaxResultCount(this.paginator, event),
        this.primengTableHelper.getSkipCount(this.paginator, event),
    ).subscribe(result => {
        this.primengTableHelper.totalRecordsCount = result.totalCount;
        this.primengTableHelper.records = result.items;
        this.primengTableHelper.hideLoadingIndicator();
    });
}

deleteAsset5(id): void {
    this._asset5Service.deleteAsset5(id).subscribe(() => {
        this.reloadPage();
    })
}

init(): void {
    //get params từ url để thực hiện filter
    this._activatedRoute.params.subscribe((params: Params) => {
        this.asset5Name = params['name'] || '';
        this.reloadList(this.asset5Name, null);
    });
}

reloadPage(): void {
    this.paginator.changePage(this.paginator.getPage());
}

applyFilters(): void {
    //truyền params lên url thông qua router
    this.reloadList(this.asset5Name, null);

    if (this.paginator.getPage() !== 0) {
        this.paginator.changePage(0);
        return;
    }
}

//hàm show view create MenuClient
createAsset5() {
    this.createOrEditModal.show();
}

/**
* Tạo pipe thay vì tạo từng hàm truncate như thế này
* @param text
*/
truncateString(text): string {
    return abp.utils.truncateStringWithPostfix(text, 32, '...');
}
}