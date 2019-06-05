import { ViewProductModalComponent } from './view-product-modal.component';
import { AfterViewInit, Component, ElementRef, Injector, OnInit, ViewChild, Output,EventEmitter, Input } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import * as _ from 'lodash';
import { LazyLoadEvent } from 'primeng/components/common/lazyloadevent';
import { Paginator } from 'primeng/components/paginator/paginator';
import { Table } from 'primeng/components/table/table';
import { ProductServiceProxy, ProductContractInput,ProductDto, ProductInput } from '@shared/service-proxies/service-proxies';
import { ModalDirective } from 'ngx-bootstrap';
import { CreateOrEditProductModalComponent } from './create-or-edit-product-modal.component';

@Component({
    selector:'product-for-select-component',
    templateUrl: './product-for-select.component.html',
    animations: [appModuleAnimation()],
    
})
export class ProductForSelectComponent extends AppComponentBase implements AfterViewInit, OnInit {

    /**
     * @ViewChild là dùng get control và call thuộc tính, functions của control đó
     */
    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') modal: ModalDirective;

    /**
     * tạo các biến dể filters
     */
    productName: string;
    productContracts: ProductContractInput[];

    @Output() productsValueChange = new EventEmitter();
    @Input() contractId:number|null;

    constructor(
        injector: Injector,
        private _productService: ProductServiceProxy,
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
     * Hàm get danh sách Product
     * @param event
     */
    getProducts(event?: LazyLoadEvent) {
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

    reloadList(productName, event?: LazyLoadEvent) {
        this._productService.getProductsByFilter(productName, productName, this.primengTableHelper.getSorting(this.dataTable),
            this.primengTableHelper.getMaxResultCount(this.paginator, event),
            this.primengTableHelper.getSkipCount(this.paginator, event),
        ).subscribe(result => {
            this.primengTableHelper.totalRecordsCount = result.totalCount;
            this.primengTableHelper.records = result.items;
            this.primengTableHelper.hideLoadingIndicator();
        });
    }



    init(): void {
        //get params từ url để thực hiện filter
        this._activatedRoute.params.subscribe((params: Params) => {
            this.productName = params['name'] || '';
            this.reloadList(this.productName, null);
        });
    }

    reloadPage(): void {
        this.paginator.changePage(this.paginator.getPage());
    }

    applyFilters(): void {
        //truyền params lên url thông qua router
        this.reloadList(this.productName, null);

        if (this.paginator.getPage() !== 0) {
            this.paginator.changePage(0);
            return;
        }
    }

    //hàm show view create MenuClient
    createProduct() {

    }

    onItemChecked(record:ProductInput|null,e){
       // this.products=[...this.products,item ]
       if(e.target.checked){
        let newProductContract = new ProductContractInput();
        newProductContract.productId=record.id
        newProductContract.product=record;
        newProductContract.amount=1;
        newProductContract.price = record.currentPrice;

        const tempProductContracts = this.productContracts!=null?this.productContracts:[];
        this.productContracts=[...tempProductContracts,newProductContract ]
      
       }else{
        this.productContracts=this.productContracts? this.productContracts.filter(e=>e.product.id!=record.id) :[]
      
       }
    

    }  

    show(productId?: number | null | undefined): void {
        console.log("show funct active")
        window.scroll(0,0);
        this.modal.show();

    }

    close(): void {
        this.modal.hide();
    }
    save():void{

        this.productsValueChange.emit(this.productContracts)
        this.close()
    }
    /**
     * Tạo pipe thay vì tạo từng hàm truncate như thế này
     * @param text
     */
    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
