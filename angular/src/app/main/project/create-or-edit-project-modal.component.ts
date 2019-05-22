import { Component, ElementRef, EventEmitter, Injector, Output, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { ModalDirective } from 'ngx-bootstrap';
import { ProjectServiceProxy, ProjectInput } from '@shared/service-proxies/service-proxies';



@Component({
    selector: 'createOrEditProjectModal',
    templateUrl: './create-or-edit-project-modal.component.html'
})
export class CreateOrEditProjectModalComponent extends AppComponentBase {


    @ViewChild('createOrEditModal') modal: ModalDirective;
    @ViewChild('projectCombobox') projectCombobox: ElementRef;
    @ViewChild('iconCombobox') iconCombobox: ElementRef;
    @ViewChild('dateInput') dateInput: ElementRef;


    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    project: ProjectInput = new ProjectInput();
    
    constructor(
        injector: Injector,
        private _projectService: ProjectServiceProxy
    ) {
        super(injector);
    }

    show(projectId?: number | null | undefined): void {
        this.saving = false;


        this._projectService.getProjectForEdit(projectId).subscribe(result => {
            this.project = result;
            var moment = require('moment');      
            var _date = moment(result.date);
            var tz = _date.utcOffset(); 
            _date.add(tz, 'm');
            this.project.date = _date.format('YYYY-MM-DD');
            this.modal.show();

        })
    }

    save(): void {
        let input = this.project;
        var moment = require('moment');
        input.date = moment(input.date);
        this.saving = true;
        this._projectService.createOrEditProject(input).subscribe(result => {
            this.notify.info(this.l('SavedSuccessfully'));
            this.close();
        })

    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
