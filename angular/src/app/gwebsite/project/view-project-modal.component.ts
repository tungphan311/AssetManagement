import { ProjectForViewDto } from './../../../shared/service-proxies/service-proxies';
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { ProjectServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from 'ngx-bootstrap';

@Component({
    selector: 'viewProjectModal',
    templateUrl: './view-project-modal.component.html'
})

export class ViewProjectModalComponent extends AppComponentBase {

    project : ProjectForViewDto = new ProjectForViewDto();
    @ViewChild('viewModal') modal: ModalDirective;

    constructor(
        injector: Injector,
        private _projectService: ProjectServiceProxy
    ) {
        super(injector);
    }

    show(projectId?: number | null | undefined): void {
        this._projectService.getProjectForView(projectId).subscribe(result => {
            this.project = result;
            this.modal.show();
        })
    }

    close() : void{
        this.modal.hide();
    }
}