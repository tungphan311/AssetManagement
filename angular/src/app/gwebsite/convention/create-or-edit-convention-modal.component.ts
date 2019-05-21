import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
//import { conventionServiceProxy, conventionInput,conventionInputStatus } from '@shared/service-proxies/service-proxies';
@Component({
    selector: 'createOrEditconventionModal',
    templateUrl: './create-or-edit-convention-modal.component.html'
})
export class CreateOrEditconventionModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('conventionCombobox') conventionCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    //convention: conventionInput = new conventionInput();

    constructor(
        injector: Injector,
        //private _conventionService: conventionServiceProxy
    ) {
        super(injector);
    }
    ngOnInit(){
       console.log('onInit')
     }

    show(conventionId?: number | null | undefined): void {
        this.saving = false;


        // this._conventionService.getconventionForEdit(conventionId).subscribe(result => {
        //     this.convention = result;
        //     this.modal.show();

        // })
    }

    // save(): void {
    //     let input = this.convention;       
    //     console.log(input)
    //     this.saving = true;
    //     this._conventionService.createOrEditconvention(input).subscribe(result => {
    //         this.notify.info(this.l('SavedSuccessfully'));
    //         this.close();
    //     })

    // }

    // getStatus(value:any):void{
    //     console.log('value is '+value.target.checked)
    //     if(value.target.checked) 
    //         this.convention.status= conventionInputStatus._1
    //      else
    //         this.convention.status= conventionInputStatus._0


    // }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
