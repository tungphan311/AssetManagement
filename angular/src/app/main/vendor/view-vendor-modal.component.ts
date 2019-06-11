import { VendorForViewDto, MerchandiseInput, AssignmentTableServiceProxy, AssignmentTableForViewDto, AssignmentTableInput, VendorInput } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild,OnInit, EventEmitter, Output } from "@angular/core";
import { VendorServiceProxy, VendorTypeServiceProxy, MerchandiseServiceProxy, MerchandiseTypeServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { CreateMerchandiseModalComponent } from "./create-merchandise-modal.component";
import { AddContractDetailModalComponent } from '../contract/add-contract-detail-modal-component';
import { element } from '@angular/core/src/render3/instructions';

@Component({
    selector: 'viewVendorModal',
    templateUrl: './view-vendor-modal.component.html'
})

export class ViewVendorModalComponent extends AppComponentBase {

    @ViewChild('createModal') createModal: CreateMerchandiseModalComponent;

    saving=false;

    assignmentTable : AssignmentTableForViewDto = new AssignmentTableForViewDto();
    assignmentTableInput: AssignmentTableInput = new AssignmentTableInput();
    vendor : VendorForViewDto = new VendorForViewDto();
    vendorId: number;
    @ViewChild('viewModal') modal: ModalDirective;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;

    @ViewChild('addContractDetailModal') addContractDetailModal: AddContractDetailModalComponent;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
    // list vendortype
    vendortypeList: any[];
    mertypeList: any[];
    asssignmentTableList: any[];
    products: any[]; 
    listMerchandiseID = [];
    merchlist=[];

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
        this._merchandiseService.getMerchandiseByFilter(null,null,0,0,null,null,99,0).subscribe(result => {
            this.merchlist=result.items
        })
        this.getMerchandises();
    }
    getMerchandises() {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();
        this.passToProducts();
        this.loadListMerchandise();
    }

    passToProducts() {
        this.products.length = 0;

       

        //console.log(this.addContractDetailModal.listMerID)
        //console.log(this.contract.products);
    }
    getVendorDetail(event?: LazyLoadEvent) {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        this.primengTableHelper.showLoadingIndicator();

        this.reloadListVendorDetail(this.vendorId, event);
    }   

    reloadListVendorDetail(vendorID, event: LazyLoadEvent) {


        this._assignmentTableService.getAssignmentTablesByFilter(0,vendorID,
            this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.asssignmentTableList=result.items;
            });
        for (const iterator of this.asssignmentTableList) {
                this._merchandiseService.getMerchandiseByFilter(iterator.merchID,null,0,0,null,
                    this.primengTableHelper.getSorting(this.dataTable),
                    this.primengTableHelper.getMaxResultCount(this.paginator, event),
                    this.primengTableHelper.getSkipCount(this.paginator, event),
                ).subscribe(result => {
                    this.primengTableHelper.totalRecordsCount = result.totalCount;
                    this.primengTableHelper.records = result.items;
                    this.primengTableHelper.hideLoadingIndicator();
                });
            
    }
}

    loadListMerchandise() {
        this.primengTableHelper.totalRecordsCount = this.products.length;
        this.primengTableHelper.records = this.products;
        this.primengTableHelper.hideLoadingIndicator();
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }
    close() : void{
        this.modal.hide();
        this.modalSave.emit(null);
        
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
            // this.notify.info(this.l('Added to AssignmentTable'));
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
            if (iterator.id == id) {
                return iterator.name;
            }
        }
    }
    getMerchName(id: number): any {
        for (const iterator of this.merchlist) {
            if (iterator.code == id) {
                return iterator.name;
            }
        }
    }

    addMerchandise() {
        
        this.addContractDetailModal.show();
        // this.createModal.show(this.vendorId);
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
    save(): void {

        this.saving = true;

        this.addContractDetailModal.isSelectAll = false;
        this.addContractDetailModal.listMerchandises.forEach(item => {
            item.isAddContract = false;
                if (!this.getAssignState(this.vendorId,item.id))
                {
                    this.addToAssignmentTable(this.vendorId,item.id);

                }
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();

            });
    }
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
