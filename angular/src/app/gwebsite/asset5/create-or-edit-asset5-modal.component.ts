import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { Asset5ServiceProxy, Asset5Input } from '@shared/service-proxies/service-proxies';

@Component({
    selector: 'createOrEditAsset5Modal',
    templateUrl: './create-or-edit-asset5-modal.component.html'
})
export class CreateOrEditAsset5ModalComponent extends AppComponentBase {
    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('asset5Combobox') asset5Combobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;

    /**
    * @Output dùng để public event cho component khác xử lý
    */
   @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

   saving = false;

   customer: Asset5Input = new Asset5Input();
    asset5: any;

   constructor(
       injector: Injector,
       private _asset5Service: Asset5ServiceProxy
   ) {
       super(injector);
   }

   show(asset5Id?: number | null | undefined): void {
       this.saving = false;

       this._asset5Service.getAsset5ForEdit(asset5Id).subscribe(result => {
        this.asset5 = result;
        this.modal.show();

    })
}

save(): void {
    let input = this.asset5;
    this.saving = true;
    this._asset5Service.createOrEditAsset5(input).subscribe(result => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.close();
    })

}

close(): void {
    this.modal.hide();
    this.modalSave.emit(null);
}
}
```		
   - create-or-edit-asset5-modal.component.html
     - Đây là file mô tả layout html của trang thêm/cập nhật tài sản
```html
<div bsModal #createOrEditModal="bs-modal" class="modal fade" tabindex="-1" role="dialog"
aria-labelledby="createOrEditModal" aria-hidden="true" [config]="{backdrop: 'static'}">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <form #editForm="ngForm" novalidate (ngSubmit)="save()">
                <div class="modal-header">
                    <h4 class="modal-title">
                        <span *ngIf="asset5.id">Cập nhật tài sản: {{asset5.name}}</span>
                        <span *ngIf="!asset5.id">Tạo mới tài sản</span>
                    </h4>
                    <button type="button" class="close" (click)="close()" [attr.aria-label]="l('Close')">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label>Tên tài sản *</label>
                        <input #nameInput="ngModel" class="form-control" type="text" name="Name"
                            [(ngModel)]="asset5.name" required maxlength="64">
                        <validation-messages [formCtrl]="nameInput"></validation-messages>
                    </div>
                    <div class="form-group">
                        <label>Loại *</label>
                        <input #categoryInput="ngModel" class="form-control" type="text" name="Category"
                            [(ngModel)]="asset5.address" required maxlength="64">
                        <validation-messages [formCtrl]="asset5Input"></validation-messages>
                    </div>
                    <div class="form-group">
                        <label>Thông tin *</label>
                        <input #categoryInput="ngModel" class="form-control" type="text" name="Info"
                            [(ngModel)]="customer.info" required maxlength="64">
                        <validation-messages [formCtrl]="infoInput"></validation-messages>
                    </div>
                </div>
                <div class="modal-footer">
                    <button [disabled]="saving" type="button" class="btn btn-default"
                        (click)="close()">{{l("Cancel")}}</button>
                    <button type="submit" class="btn btn-primary" [buttonBusy]="saving"
                        [busyText]="l('SavingWithThreeDot')"><i class="fa fa-save"></i>
                        <span>{{l("Save")}}</span></button>
                </div>
            </form>
        </div>
    </div>
</div>
```
- view-asset5-modal.component.ts
```javascript
import { Asset5ForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { Asset5ServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewAsset5Modal',
    templateUrl: './view-asset5-modal.component.html'
})

export class ViewAsset5ModalComponent extends AppComponentBase {

    asset5 : Asset5ForViewDto = new Asset5ForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _asset5Service: Asset5ServiceProxy
    ) {
        super(injector);
    }

    show(asset5Id?: number | null | undefined): void {
        this._asset5Service.getCustomerForView(asset5Id).subscribe(result => {
            this.asset5 = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}
```
- view-asset5-modal.component.html
```html
<div bsModal #viewModal="bs-modal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="viewModal"
aria-hidden="true" [config]="{backdrop: 'static'}">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <div class="modal-header">
                <h4 class="modal-title">
                    <span *ngIf="asset5.id">{{l("EditAsset5")}}: {{asset5.name}}</span>
                    <span *ngIf="!asset5.id">{{l("CreateNewAsset5")}}</span>
                </h4>
                <button type="button" class="close" (click)="close()" [attr.aria-label]="l('Close')">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                <div class="form-group">
                    <label>Tên tài sản</label>
                    <p>{{asset5.name}}</p>
                </div>
                <div class="form-group">
                    <label>Loại</label>
                    <p>{{asset5.address}}</p>
                </div>
                <div class="form-group">
                    <label>Thông tin</label>
                    <p>{{asset5.info}}</p>
                </div>
            </div>
            <div class="modal-footer">
                <button [disabled]="saving" type="button" class="btn btn-default"
                    (click)="close()">{{l("Cancel")}}</button>
                <button type="submit" class="btn btn-primary" [buttonBusy]="saving"
                    [busyText]="l('SavingWithThreeDot')"><i class="fa fa-save"></i>
                    <span>{{l("Save")}}</span></button>
            </div>
        </div>
    </div>
</div>
```