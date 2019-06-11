import { Component, ViewChild, Injector, Output, EventEmitter } from "@angular/core";
import { AppComponentBase } from "@shared/common/app-component-base";
import { ModalDirective } from "ngx-bootstrap";
import { LazyLoadEvent, Paginator } from "primeng/primeng";
import { Table } from "primeng/table";
import { ProjectServiceProxy, ContractServiceProxy, BidServiceProxy, MerchandiseDto, ContractDetailInput, ContractDto } from "@shared/service-proxies/service-proxies";
import { SelectProjectModalComponent } from "../bid/select-project-modal.component";
import { SelectContractModalComponent } from "./select-contract-modal.component";

@Component({
    selector: 'addMerchandiseToPO',
    templateUrl: './add-merchandise-to-po.component.html'
})

export class AddMerchandiseToPOComponent extends AppComponentBase {
    @ViewChild('addMerchandiseToPO') addMerchandiseToPO: ModalDirective;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('selectProjectModal') selectProjectModal: SelectProjectModalComponent;
    @ViewChild('selectContractModal') selectContractModal: SelectContractModalComponent;
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();
    saving = false;
    selected = "";
    projectCode = "";
    projectId = 0;
    contract = "";
    contractId = 0;
    merchandise = "";

    merchandises: ContractDetailInput[] = [];
    contracts: ContractDto[] = [];
    isSelected: {value:boolean,cdID:number}[]=[];
    constructor (
        injector: Injector,
        private _projectService: ProjectServiceProxy,
        private _contractService: ContractServiceProxy,
        private _bidService: BidServiceProxy
    ) {
        super(injector);
    }

    show() {
        this.saving = false;
        
        this._contractService.getContractsByFilter(null, null, null, 0, 0 ,null, 999, 0).subscribe(result => {
            this.contracts = result.items;
        })

        this.addMerchandiseToPO.show();
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
        this.reloadList(null, null, 0, event);
    }

    reloadList(projectId, contractId, merchandise, event?: LazyLoadEvent) {
        if (this.selected == "in") {
            if (projectId == 0) {
                if (contractId == 0) {
                    this.primengTableHelper.totalRecordsCount = 0;
                    this.primengTableHelper.records = [];
                    this.isSelected.length=0;
                    this.primengTableHelper.hideLoadingIndicator();
                }
                else {
                    this._contractService.getContractForEdit(contractId).subscribe(result => {
                        result.products = result.products.filter(x => x.merName.toLowerCase().includes(merchandise));
                        this.primengTableHelper.totalRecordsCount = result.products.length;
                        this.primengTableHelper.records = result.products;
                        this.isSelected.length=0;
                        for(const product of result.products){
                            this.isSelected.push({value:false,cdID:product.id});
                        }
                        this.primengTableHelper.hideLoadingIndicator();
                    });
                }
            }
            else {
                if (contractId != 0) {
                    this._contractService.getContractForView(contractId).subscribe(contract => {
                        this._bidService.getBidForView(contract.briefcaseID).subscribe(bid => {
                            if (bid.projectId == projectId) {
                                console.log("EQUALS");
                                this._contractService.getContractForEdit(contractId).subscribe(result => {
                                    result.products = result.products.filter(x => x.merName.toLowerCase().includes(merchandise));
                                    this.primengTableHelper.totalRecordsCount = result.products.length;
                                    this.primengTableHelper.records = result.products;
                                    this.isSelected.length=0;
                                    for(const product of result.products){
                                        this.isSelected.push({value:false,cdID:product.id});
                                    }
                                    this.primengTableHelper.hideLoadingIndicator();
                                });
                            }
                            else {
                                this.primengTableHelper.totalRecordsCount = 0;
                                this.primengTableHelper.records = [];
                                this.isSelected.length=0;
                                this.primengTableHelper.hideLoadingIndicator();
                            }
                        })
                    })
                }
                else {
                    
                    this._bidService.getBidsByFilter(null, null, null, null, "All", 0, 
                        this.primengTableHelper.getSorting(this.dataTable),
                        this.primengTableHelper.getMaxResultCount(this.paginator, event),
                        this.primengTableHelper.getSkipCount(this.paginator, event),
                    ).subscribe(result => {
                        result.items = result.items.filter(x => x.projectId == projectId);
                        this.merchandises.length = 0;
                        result.items.forEach(bid => {
                            this._contractService.getContractsByFilter(null, null, null, bid.id, 0,
                                null, 999, 0).subscribe(list => {
                                    list.items.forEach(contract => {
                                        this._contractService.getContractForEdit(contract.id).subscribe(con => {
                                            this.merchandises = this.merchandises.concat(con.products);
                                        });
                                    });

                                    
                                });
                        });
                        //this.merchandises = this.merchandises.filter(x => x.merName.toLowerCase().includes(merchandise));

                        this.primengTableHelper.totalRecordsCount = this.merchandises.length;
                        this.primengTableHelper.records = this.merchandises;
                        this.isSelected.length=0;
                        for(const product of this.merchandises){
                            this.isSelected.push({value:false,cdID:product.id});
                        }
                        this.primengTableHelper.hideLoadingIndicator();
                    });
                }
            }
        }
    }
    
    selectcdID(cb,cdID:number):void{
        for(const item of this.isSelected)
        {
            if (item.cdID==cdID)
                item.value=!item.value;
        }
    }
    reloadProject(projectID:number): void {
        if (projectID!=0){
            this.projectId = projectID;
            this.projectCode = this.getProjectCode(projectID);
        }
        else
        {
            this.projectCode = "";
        }
    }

    getProjectCode(projectID:number):string{
        let projectCode = "";
        let temp = this.projectCode;
        if (projectID!=0)
        {
            this._projectService.getProjectForView(projectID).subscribe(result => {
                this.projectCode = result.code;        
            })
        }
        projectCode = this.projectCode;
        this.projectCode = temp;
        return projectCode;
    }

    reloadContract(contractID:number): void {
        if (contractID!=0){
            this.contractId = contractID;
            this._contractService.getContractForView(contractID).subscribe(result=>
            {                  
                this.contract = result.name;
            });
        }
        else {
            this.contract = "";
            this.contractId = 0;
        }
    }

    getContractName(contractId: number): string {
        for (const item of this.contracts) {
            if (item.id == contractId) {
                return item.name;
            }
        }
    }

    applyFilters(): void {
        if (this.selected == "") {
            this.notify.warn("Vui lòng chọn 'Trong KH' hoặc 'Ngoài KH'");
        }
        else {
            this.reloadList(this.projectId, this.contractId, this.merchandise, null);
        }  
    }

    save(): void {
        let result: ContractDetailInput[] = [];
        for (const record of this.primengTableHelper.records){
            if (this.isSelected.filter(x=>x.cdID==record.id&&x.value==true).length>0)
                result.push(record);
        }
        this.modalSave.emit(result);
        console.log(result);
        
    }

    close(): void {
        console.log(this.primengTableHelper.records[0]);
        this.addMerchandiseToPO.hide();
    }

    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}