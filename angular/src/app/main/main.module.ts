import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AppCommonModule } from '@app/shared/common/app-common.module';
import { UtilsModule } from '@shared/utils/utils.module';
import { CountoModule } from 'angular2-counto';
import { EasyPieChartModule } from 'ng2modules-easypiechart';
import { ModalModule, TabsModule, TooltipModule } from 'ngx-bootstrap';
import { MainRoutingModule } from './main-routing.module';

import { DashboardComponent } from './dashboard/dashboard.component';
import { PhoneBookComponent } from './phonebook/phonebook.component';
import { CreatePersonModalComponent } from './phonebook/create-person-modal.component';
import { AssetDashboardComponent } from './asset_dashboard/asset_dashboard.component';

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
        PhoneBookComponent,
        CreatePersonModalComponent,
        AssetDashboardComponent,
    ]
})
export class MainModule { }
