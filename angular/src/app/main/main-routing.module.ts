import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { MerchandiseComponent } from './merchandise/merchandise.component';
import { VenderComponent } from './vender/vender.component';
import { AssignmentTableComponent } from './assignment-table/assignment-table.component';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                children: [
                    { path: 'dashboard', component: DashboardComponent, data: { permission: 'Pages.Tenant.Dashboard' } },
                    { path: 'merchandise', component: MerchandiseComponent, data: { permission: 'Pages.Administration.Merchandise' } },
                    { path: 'vender', component: VenderComponent },
                    { path: 'assignment-table', component: AssignmentTableComponent }
                ]
            }
        ])
    ],
    exports: [
        RouterModule
    ]
})
export class MainRoutingModule { }
