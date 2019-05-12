import { Component, AfterViewInit, OnInit, ViewChild, Injector } from "@angular/core";
import { appModuleAnimation } from "@shared/animations/routerTransition";
import { AppComponentBase } from "@shared/common/app-component-base";
import { Table } from "primeng/table";
import { Paginator, LazyLoadEvent } from "primeng/primeng";
import { CreateOrEditMerchandiseTypeModalComponent } from "./create-or-edit-merchandise-type-modal.component";
import { ViewMerchandiseTypeModalComponent } from "./view-merchandise-type-modal.component";
import { MerchandiseTypeServiceProxy } from "@shared/service-proxies/service-proxies";
import { ActivatedRoute, Params } from "@angular/router";

@Component({
    templateUrl: './merchandise-type.component.html',
    animations: [appModuleAnimation()]
})

export class MerchandiseTypeComponent extends AppComponentBase implements AfterViewInit, OnInit {
    /**
    * @ViewChild là dùng get control và call thuộc tính, functions của control đó
    */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditMerchandiseTypeModalComponent;
    @ViewChild('viewMerchandiseTypeModal') viewMerchandiseTypeModal: ViewMerchandiseTypeModalComponent;
   
    // biến để filter
    merchandiseTypeName: string;
    merchandiseTypeID: string;
    isActive: string;

    constructor(
        injector: Injector,
        private _merchandiseTypeService: MerchandiseTypeServiceProxy,
        private _activatedRoute: ActivatedRoute,
    ) {
        super(injector);
    }

    ngAfterViewInit(): void {
        // ham xu ly sau khi view dc init
        setTimeout(() => {
            this.init();
        })
    }    
    
    ngOnInit(): void {
       // ham xu ly truoc khi view duoc init
    }

    /**
    * Hàm get danh sách MerchandiseType
    * @param event
    */
   getMerchandiseTypes(event?: LazyLoadEvent) {
       if(!this.paginator || !this.dataTable) {
           return;
       }

       // show loading trong gridview
       this.primengTableHelper.showLoadingIndicator();

       // default filter = null
       this.reloadList(null, null, null, event);
   }

   reloadList(merchandiseTypeID, merchandiseTypeName, isActive, event?: LazyLoadEvent) {
       this._merchandiseTypeService.getMerchandiseByFilter(
            merchandiseTypeID, merchandiseTypeName, isActive,
            this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
   }

   init(): void {
       // get params from url to filter
       this._activatedRoute.params.subscribe((params: Params) => {
           this.merchandiseTypeID = params['typeID'] || '';
           this.merchandiseTypeName = params['name'] || '';
           this.isActive = params[String('isActive')] || '';
           this.reloadList(this.merchandiseTypeID, this.merchandiseTypeName, this.isActive, null);
       });
   }

   deleteMerchandiseType(id): void {
       this._merchandiseTypeService.deleteMerchandiseType(id).subscribe(() => {
           this.reloadPage();
       });
   }

   reloadPage(): void {
       this.paginator.changePage(this.paginator.getPage());
   }

   applyFilters(): void {
       // load params to url through router
       this.reloadList(this.merchandiseTypeID, this.merchandiseTypeName, this.isActive, null);

       if (this.paginator.getPage() !== 0) {
           this.paginator.changePage(0);
           return;
       }
   }

   // show view create MerchandiseType
   createMerchandiseType() {
       this.createOrEditModal.show();
   }

   /**
    * Tạo pipe thay vì tạo từng hàm truncate như thế này
    * @param text
    */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }

    customIsActive(bool): string {
        if (bool == true) {
            return "Còn";
        }
        else {
            return "Không";
        }
    }
}