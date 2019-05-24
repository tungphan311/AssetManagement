import { BidForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { BidServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewBidModal',
    templateUrl: './view-bid-modal.component.html'
})

export class ViewBidModalComponent extends AppComponentBase {

    bid : BidForViewDto = new BidForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _bidService: BidServiceProxy
    ) {
        super(injector);
    }

    show(bidId?: number | null | undefined): void {
        this._bidService.getBidForView(bidId).subscribe(result => {
            this.bid = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}
