import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild, Input } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { ProductContractServiceProxy, ProductContractInput, ProductServiceProxy, ProductInput, PurchaseProductDetailInput, PurchaseOrderInput } from '@shared/service-proxies/service-proxies';
import { ActivatedRoute, Params } from '@angular/router';
import { LazyLoadEvent, Paginator } from 'primeng/primeng';
import { Table } from 'primeng/table';


@Component({
    selector: 'purchase-product-selection-modal',
    templateUrl: './purchase-product-selection-modal.component.html'
})
export class PurchaseProductSelectionModalComponent extends AppComponentBase {


    @ViewChild('dataTable') dataTable: Table;
    @ViewChild('paginator') paginator: Paginator;
    @ViewChild('createOrEditModal') modal: ModalDirective;


    /**
     * @Output dùng để public event cho component khác xử lý
     */



    saving = false;


    productName: string;
    purchaseProductDetails: PurchaseProductDetailInput[];

    @Output() productsValueChange = new EventEmitter();
    @Output() openContractSelectModalEmit = new EventEmitter
    @Input() contractId: number | null;
    @Input() purchaseOrderRecieved: PurchaseOrderInput

    allowLoad: boolean
    contractIdToFind: number | null | undefined

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
        this.allowLoad = false
        this.primengTableHelper.isLoading = false
    }

    /**
     * Hàm xử lý sau khi View được init
     */
    ngAfterViewInit(): void {

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
        this.allowLoad = true
    }

    reloadList(productName, event?: LazyLoadEvent) {
        if (!this.allowLoad) return

        if (this.purchaseOrderRecieved.contractId != null && !this.purchaseOrderRecieved.isInProject)
            this.contractIdToFind = this.purchaseOrderRecieved.contractId
        else
            this.contractIdToFind = null
    
        this._productService.getProductsByFilter(productName, productName, this.contractIdToFind, this.primengTableHelper.getSorting(this.dataTable),
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

    //getContractEmit

    //hàm show view create MenuClient
    createProduct() {

    }

    onItemChecked(record: ProductInput | null, e) {
        // this.products=[...this.products,item ]
        if (e.target.checked) {
            let newProductContract = new PurchaseProductDetailInput();
            newProductContract.productId = record.id
            newProductContract.product = record;
            newProductContract.amount = 1;
            newProductContract.price = record.currentPrice;

            const tempProductContracts = this.purchaseProductDetails != null ? this.purchaseProductDetails : [];
            this.purchaseProductDetails = [...tempProductContracts, newProductContract]

        } else {
            this.purchaseProductDetails = this.purchaseProductDetails ? this.purchaseProductDetails.filter(e => e.product.id != record.id) : []

        }


    }
    openContractSelectModal(contract) {
        this.openContractSelectModalEmit.emit(contract)
    }

    show(purchaseInput?: PurchaseOrderInput | null | undefined): void {
        this.saving = false;

        //console.log("show modal")
        if (purchaseInput) {

        }
        this.modal.show();
        console.log(purchaseInput)
    }

    save(): void {
        let input = this.purchaseProductDetails;
        this.saving = true;

        if (this.purchaseProductDetails && this.purchaseProductDetails.length > 0) {
            this.purchaseOrderRecieved.purchaseProductDetails = [...this.purchaseProductDetails]

            let totalProductPrice = this.purchaseOrderRecieved.purchaseProductDetails.reduce((total, item) => total + item.price, 0)
            if (!totalProductPrice) totalProductPrice = 0
            this.purchaseOrderRecieved.totalPrice = totalProductPrice

        }
        console.log(this.purchaseOrderRecieved)
        this.modal.hide();

    }

    close(): void {
        this.modal.hide();

    }

    truncateString(text): string {
        return abp.utils.truncateStringWithPostfix(text, 32, '...');
    }
}
