import { Component, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { DonViServiceProxy, DonViDto, ListResultDtoOfDonViDto } from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: './asset_dashboard.component.html',
    styleUrls: ['./asset_dashboard.component.css'],
    animations: [appModuleAnimation()]
})

export class AssetDashboardComponent extends AppComponentBase implements OnInit
{
	userName = '';
	header_stats: AssetHeaderStats;
	assets_state_chart: ProfitSharePieChart;

    constructor(injector: Injector, private _DonViService: DonViServiceProxy) 
    {
        super(injector);
        this.header_stats = new AssetHeaderStats();
        this.assets_state_chart = new ProfitSharePieChart();
        this.userName = this.appSession.user.userName;
    }

    ngOnInit(): void 
    {
        this._DonViService
            .getDonVi()
            .subscribe(result => {
                this.header_stats.Assets_Count = result.items[0].soLuongTaiSan;
                this.header_stats.Assets_Active = result.items[0].taiSanSuDung;
                this.header_stats.Assets_Custody = result.items[0].taiSanTrongKho;
                this.header_stats.Assets_Disposed = result.items[0].soLuongTaiSan;
            });
    }
}

class AssetHeaderStats
{
    Assets_Count = 0; 
    Assets_Count_Counter = 0;
    Assets_Active = 0; 
    Assets_Active_Counter = 0;
    Assets_Custody = 0;
    Assets_Custody_Counter = 0;
    Assets_Disposed = 0; 
    Assets_Disposed_Counter = 0;

    /*init(totalProfit, newFeedbacks, newOrders, newUsers)
    {
        this.totalProfit = totalProfit;
        this.newFeedbacks = newFeedbacks;
        this.newOrders = newOrders;
        this.newUsers = newUsers;
        this.hideLoading();
    }*/
}


class ProfitSharePieChart
{
    //== Profit Share Chart.
    //** Based on Chartist plugin - https://gionkunz.github.io/chartist-js/index.html

    _canvasId: string;
    data: number[];
    chartData: {};

    constructor() 
    {
        this.init([56, 28, 16]);
        this.chartData = {
    datasets: [{
        data: [10, 20, 30]
    }],

    // These labels appear in the legend and in the tooltips when hovering different arcs
    labels: [
        'Red',
        'Yellow',
        'Blue'
    ]
};
    }

    init(data: number[]) 
    {
        this.data = data;
    }
}