import { Component, Injector, ViewChild, Output, EventEmitter, ElementRef } from "@angular/core";
import { AppComponentBase } from "@shared/common/app-component-base";
import { ModalDirective } from "ngx-bootstrap";
import { Table } from "primeng/table";
import { Paginator, LazyLoadEvent } from "primeng/primeng";
import { MerchandiseDto, MerchandiseServiceProxy } from "@shared/service-proxies/service-proxies";

@Component({
    selector: 'addMerchandiseModal',
    templateUrl: './add-merchandise-modal.component.html'
})

export class AddMerchandiseModalComponent extends AppComponentBase {
    @ViewChild('addMerchandiseModal') addMerchandiseModal: ModalDirective;
    @ViewChild('contractCombobox') contractCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;

    @Output() data: EventEmitter<any> = new EventEmitter<any>();
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    listMerchandise: {
        merch: MerchandiseDto,
        isSelected: boolean
    }[] = [];
    saving = false;
    savingId: boolean[]=[];

    merID: string;
    merName: string;
    typeID: number;
    isSelectAll: boolean;
    listMerID: MerchandiseDto[]=[];

    constructor(
        injector: Injector,
        private _merchandiseService: MerchandiseServiceProxy
    ) {
        super(injector);
    }

    show() {
        this.saving = false;
        this.getMerchandises(null);
        this.addMerchandiseModal.show();
    }
    getMerchandises(event): void {
        if (!this.paginator || !this.dataTable) {
            return;
        }

        //show loading trong gridview
        this.primengTableHelper.showLoadingIndicator();

        this.reloadList(null, null, 0, event);
    }
    reloadList(merID, merName, typeID, event: LazyLoadEvent) {
        this._merchandiseService.getMerchandiseByFilter(merID, 
             merName, typeID, 0, null, 
             this.primengTableHelper.getSorting(this.dataTable),
             this.primengTableHelper.getMaxResultCount(this.paginator, event),
             this.primengTableHelper.getSkipCount(this.paginator, event),
            ).subscribe(result => {
             result.items = result.items.filter(x=>this.listMerID.filter(old=>old.id==x.id).length==0);
             this.listMerchandise.length=0;
             for (const item of result.items){
                 let obj = {
                     merch: item,
                     isSelected: false
                 }
                 this.listMerchandise.push(obj);
             }

             this.primengTableHelper.totalRecordsCount = result.items.length;
             this.primengTableHelper.records = this.listMerchandise;
             console.log(this.listMerchandise);
            
             this.primengTableHelper.hideLoadingIndicator();        
         });
    }
    save(): void {
        this.saving = true;

        
        for (const iterator of this.listMerchandise) {
            console.log(iterator.merch);
            if (iterator.isSelected) {
                this.listMerID.push(iterator.merch);
            }    
        }

        //console.log(this.listMerID);
        this.data.emit(this.listMerID);
        this.close();
    }
    applyFilters(): void {
        this.reloadList(this.merID, this.merName, this.typeID, null);
        this.isSelectAll = false;
 
        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }
    selectAll(): void {
        for (const iterator of this.listMerchandise)
        {
            iterator.isSelected=this.isSelectAll;
        }
    }
    checkAll(): void {
        for (const merch of this.listMerchandise)
        {
            if (merch.isSelected==false) 
            {
                this.isSelectAll=false;
                return;
            }
        }
        this.isSelectAll=true;
    }
    close(): void {
        this.addMerchandiseModal.hide();
        this.modalSave.emit(null);
    }
        /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
    
}