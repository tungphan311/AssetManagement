import { VendorForViewDto, MerchandiseInput, AssignmentTableServiceProxy, AssignmentTableForViewDto, AssignmentTableInput } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild,OnInit } from "@angular/core";
import { VendorServiceProxy, VendorTypeServiceProxy, MerchandiseServiceProxy, MerchandiseTypeServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { CreateMerchandiseModalComponent } from "./create-merchandise-modal.component";

@Component({
    selector: 'viewVendorModal',
    templateUrl: './view-vendor-modal.component.html'
})

export class ViewVendorModalComponent extends AppComponentBase {

    @ViewChild('createModal') createModal: CreateMerchandiseModalComponent;


    assignmentTable : AssignmentTableForViewDto = new AssignmentTableForViewDto();
    assignmentTableInput: AssignmentTableInput = new AssignmentTableInput();
    vendor : VendorForViewDto = new VendorForViewDto();
    vendorId: number;
    @ViewChild('viewModal') modal: ModalDirective;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;

    // list vendortype
    vendortypeList: any[];
    mertypeList: any[];
    asssignmentTableList: any[];

    constructor(
        injector: Injector,
        private _vendorService: VendorServiceProxy,
        private _vendortypeService: VendorTypeServiceProxy,
        private _merchandiseService: MerchandiseServiceProxy,
        private _merchandisetypeService: MerchandiseTypeServiceProxy,
        private _assignmentTableService: AssignmentTableServiceProxy
    ) {
        super(injector);
    }

    show(vendorId?: number | null | undefined): void {
        this.vendorId = vendorId;
        this._vendorService.getVendorForView(vendorId).subscribe(result => {
            this.vendor = result;
            this.modal.show();
        });
        this._vendortypeService.getVendorTypesByFilter(null, null, null, null, 99, 0,
        ).subscribe(result => {
            this.vendortypeList = result.items;
        });
        this._merchandisetypeService.getMerchandiseByFilter(null, null, null, null, 999, 0).subscribe(result => {
            this.mertypeList = result.items
        });
        this._assignmentTableService.getAssignmentTablesByFilter(0,0,null,99,0).subscribe(result => {
            this.asssignmentTableList=result.items
        })
        this.getMerchandises();
    }
    getMerchandises(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        /**
         * mặc định ban đầu lấy hết dữ liệu nên dữ liệu filter = null
         */

        this.reloadList(event);
    }
    reloadList(event?: LazyLoadEvent) {
        this._merchandiseService.getMerchandiseByFilter(null, null, 0, 0, null, 
            this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event)<1?10:this.primengTableHelper.getMaxResultCount(this.paginator, event),         
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
    close() : void{
        this.modal.hide();
    }


    //kiểm tra trạng thái trong bảng gán của vendor và merchandise tương ứng
    getAssignState(venId, merchandiseId): boolean {

        for (const iterator of this.asssignmentTableList) {
            if (iterator.vendorID==venId) {
                 if (iterator.merchID==merchandiseId)
                    return true;
            }
        }

    }
    //Thêm item vào bảng gán
    addToAssignmentTable(venId, merchandiseId): void {
        this.assignmentTableInput.merchID=merchandiseId;
        this.assignmentTableInput.vendorID=venId;
        let input = this.assignmentTableInput;
        this._assignmentTableService.createOrEditAssignmentTable(input).subscribe(result =>{
            this.notify.info(this.l('Added to AssignmentTable'));
            this.close();
        })
    }

    getVendorTypeName(TypeID): String {
        for (const iterator of this.vendortypeList) {
            if (iterator.id == TypeID) {
                return iterator.name;
            }
        }
    }
    getTypeNames(id: number): any {
        for (const iterator of this.mertypeList) {
            if (iterator.id === id) {
                return iterator.name;
            }
        }
    }

    createMerchandise() {
        
        this.createModal.show(this.vendorId);
    }
    //chỉ sửa typevender của hàng hóa đó lại = 0
    deleteMerchandise(id): void { 
        this.primengTableHelper.showLoadingIndicator();
        
        this._merchandiseService.getMerchandiseForEdit(id).subscribe(result => {
            var merInput = result;
            if (merInput.id==null){
                this.notify.info(this.l('DeletedFailed'));
                this.primengTableHelper.hideLoadingIndicator();
                return;
            }
            merInput.typeVender=0;
            this._merchandiseService.createOrEditMerchandise(merInput).subscribe(() => {
                this.notify.info(this.l('DeletedSuccessfully'));
                this.primengTableHelper.hideLoadingIndicator();
                this.getMerchandises();
            })
        })
        
    }
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
