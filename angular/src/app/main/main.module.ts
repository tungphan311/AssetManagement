import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppCommonModule } from '@app/shared/common/app-common.module';
import { UtilsModule } from '@shared/utils/utils.module';
import { CountoModule } from 'angular2-counto';
import { EasyPieChartModule } from 'ng2modules-easypiechart';
import { ModalModule, TabsModule, TooltipModule } from 'ngx-bootstrap';

import { DashboardComponent } from './dashboard/dashboard.component';
 
import { MainRoutingModule } from './main-routing.module';
import { MerchandiseComponent } from './merchandise/merchandise.component';
import { VenderComponent } from './vender/vender.component';
import { AssignmentTableComponent } from './assignment-table/assignment-table.component';
import { CreateMerchandiseModalComponent } from './merchandise/create-merchandise-modal.component'

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ModalModule,
        TabsModule,
        TooltipModule,
        AppCommonModule,
        UtilsModule,
        MainRoutingModule,
        CountoModule,
        EasyPieChartModule
    ],
    declarations: [
        DashboardComponent,
        MerchandiseComponent,
        VenderComponent,
        AssignmentTableComponent,
        CreateMerchandiseModalComponent
    ]
})
export class MainModule { }
