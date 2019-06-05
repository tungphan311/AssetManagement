import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild, Input } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { ProductContractServiceProxy, ProductContractInput,ContractInput } from '@shared/service-proxies/service-proxies';
// import { ProductContractServiceProxy } from '@shared/service-proxies/service-proxies';
import {ProductContractItemComponent} from './product-contract-item.component'
 import { CreateOrEditProductContractModalComponent } from './create-or-edit-product-contract-modal.component';

 import {ProductForSelectComponent} from './../product/product-for-select.component'

@Component({
    selector: 'productContractComponent',
    templateUrl: './product-contract.component.html',
    animations: [appModuleAnimation()]
})
export class ProductContractComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('productforselectmodal')productforselectmodal:ProductForSelectComponent
    // @ViewChild('createOrEditModal') createOrEditModal: CreateOrEditProductContractModalComponent;
   
    // productContracts : ProductContractInput[];
    @Input() contractInput:ContractInput
    /**
     * tạo các biến dể filters
     */
    @Input() contractId: number;

    constructor(
        injector: Injector,
        private _productContractService: ProductContractServiceProxy,
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
        this.contractInput.totalProductPrice=0;        
    }

    display(arr){
    // console.log('display ' + arr)
     //this.productContracts = arr?[...arr]:[];
     this.contractInput.productContracts = arr?[...arr]:[];
    }

    /**
     * Hàm get danh sách ProductContract
     * @param event
     */
    getProductContracts(event?: LazyLoadEvent) {
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

  
    reloadList(contractId, event?: LazyLoadEvent) {
        this._productContractService.getProductContractsByFilter(contractId, this.primengTableHelper.getSorting(this.dataTable),
        this.primengTableHelper.getMaxResultCount(this.paginator, event),
        this.primengTableHelper.getSkipCount(this.paginator, event),
    ).subscribe(result => {
        this.primengTableHelper.totalRecordsCount = result.totalCount;
        this.primengTableHelper.records = result.items;
        this.primengTableHelper.hideLoadingIndicator();
    });
    }

    deleteProductContract(id): void {
        this._productContractService.deleteProductContract(id).subscribe(() => {
            this.reloadPage();
        })
    }

    init(): void {
        //get params từ url để thực hiện filter
        // this._activatedRoute.params.subscribe((params: Params) => {
        //     this.contractId = params['id'] || '';
        //     // this.reloadList(this.contractId, null);
        // });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.contractId, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    //hàm show view create MenuClient
    createProductContract() {
        //this.createOrEditModal.show();
    }

    onDeleteItem(item){
        if(item){
            this.contractInput.totalProductPrice-=item.price
            if(this.contractInput.totalProductPrice<0) this.contractInput.totalProductPrice=0
           let newArr=  this.contractInput.productContracts.filter(e=>e.product.id!=item.product.id)
           this.contractInput.productContracts =[...newArr];
         
        }       
    }
    onChangeTotalProductPrice(){
        if(this.contractInput&&this.contractInput.productContracts&&this.contractInput.productContracts.length>0){
            let totalProductPrice = this.contractInput.productContracts.reduce((total,item)=>total+item.price,0)            
            this.contractInput.totalProductPrice=totalProductPrice
        }
        
    }

    createProductForSelect(){
        this.productforselectmodal.show();
    }
    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
