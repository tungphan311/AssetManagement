import { Component, Injector, Output, EventEmitter, OnInit } from '@angular/core';
import { AppConsts } from '@shared/AppConsts';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/common/app-component-base';
import { DemoUiComponentsServiceProxy } from '@shared/service-proxies/service-proxies';
import { HttpRequest, HttpClient, HttpEventType } from '@angular/common/http';

@Component({
    selector: 'app-upload',
    templateUrl: './file-upload.component.html',
    styleUrls: ['./file-upload.component.css']
})

export class FileUploadComponent implements OnInit {

    public progress: number;
    public mess: string;

    @Output() public onUploadFinished = new EventEmitter();

    constructor(private http: HttpClient) { }

    ngOnInit() {
        
    }

    uploadFile(files) {
        if (files.length == 0) {
            return;
        }

        let fileToUpload = <File>files[0];
        const formData = new FormData();

        formData.append('file', fileToUpload, fileToUpload.name);

        this.http.post('https://localhost:5000/api/upload', formData, {reportProgress: true, observe: 'events'})
            .subscribe(event => {
                if (event.type == HttpEventType.UploadProgress) {
                    this.progress = Math.round(100 * event.loaded / event.total);
                }
                else if (event.type == HttpEventType.Response) {
                    this.mess = "Upload success";
                    this.onUploadFinished.emit(event.body);
                }
        });
    }
}
