import { VendorForViewDto, MerchandiseInput, AssignmentTableServiceProxy, AssignmentTableForViewDto, AssignmentTableInput, VendorInput, ContractInput, ContractDetailInput, MerchandiseDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild,OnInit, EventEmitter, Output } from "@angular/core";
import { VendorServiceProxy, VendorTypeServiceProxy, MerchandiseServiceProxy, MerchandiseTypeServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { CreateMerchandiseModalComponent } from "./create-merchandise-modal.component";
import { AddContractDetailModalComponent } from '../contract/add-contract-detail-modal-component';
import { AddMerchandiseModalComponent } from './add-merchandise-modal.component';
import { containsElement } from '@angular/animations/browser/src/render/shared';

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

    @ViewChild('addMerchandiseModal') addMerchandiseModal: AddMerchandiseModalComponent;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
    // list vendortype
    vendortypeList: any[];
    mertypeList: any[];
    asssignmentTableList: any[];
    products: ContractDetailInput[] = [];
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
        this.saving = false;
        this.vendorId = vendorId;
        this.addMerchandiseModal.listMerID = [];
        this._vendorService.getVendorForView(vendorId).subscribe(result => {
            this.vendor = result;
            this._assignmentTableService.getAssignmentTablesByFilter(0,vendorId,null,99,0).subscribe(merch=>{
                for (const item of merch.items){
                    this._merchandiseService.getMerchandiseForEdit(item.merchID).subscribe(obj=>{
                        this.addMerchandiseModal.listMerID.push(obj);
                        console.log(obj.id);
                        this.getMerchandises();
                    })
                }
            })
            
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
    }
    getMerchandises() {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();
        // this.passToProducts();
        this.reloadListVendorDetail();
    }

    // getVendorDetail(event?: LazyLoadEvent) {
    //     if (!this.paginator || !this.dataTable) {
    //         return;
    //     }

    //     this.reloadListVendorDetail();


    //     this.primengTableHelper.showLoadingIndicator();

    // }   

    reloadListVendorDetail() {

        this.primengTableHelper.totalRecordsCount = this.addMerchandiseModal.listMerID.length;
        this.primengTableHelper.records = this.addMerchandiseModal.listMerID;
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
        this.addMerchandiseModal.show();
        // this.createModal.show(this.vendorId);
    }
    //chỉ sửa typevender của hàng hóa đó lại = 0
    deleteMerchandise(id): void { 
        this.addMerchandiseModal.listMerID = this.addMerchandiseModal.listMerID.filter(x=>x.id!=id);
        this.getMerchandises();
        
    }
    save(): void {

        this.saving = true;

        this._vendorService.getVendorForEdit(this.vendorId).subscribe(result =>{
            result.merchandises = [];
            for (const item of this.addMerchandiseModal.listMerID){
                result.merchandises.push(item.id);
            }
            this._vendorService.createOrEditVendor(result).subscribe(result =>{
                this.notify.info(this.l('SavedSuccessfully'));
                this.close();
            })
        })
    }
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
