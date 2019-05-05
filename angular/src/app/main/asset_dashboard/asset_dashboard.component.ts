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
    	if (this.userName == "admin")
    	{
        	this._DonViService.getDonVi("DonViChinh").subscribe( result => 
        	{
                this.header_stats.Assets_Count = result[0].soLuongTaiSan;
                this.header_stats.Assets_Active = result[0].taiSanSuDung;
                this.header_stats.Assets_Storage = result[0].taiSanTrongKho;
                this.header_stats.Assets_Disposed = result[0].taiSanHu;
            });
        }
        else
        {
        	this._DonViService.getDonVi(this.userName).subscribe( result => 
        	{
                this.header_stats.Assets_Count = result[0].soLuongTaiSan;
                this.header_stats.Assets_Active = result[0].taiSanSuDung;
                this.header_stats.Assets_Storage = result[0].taiSanTrongKho;
                this.header_stats.Assets_Disposed = result[0].taiSanHu;
            });
        }
    }
}

class AssetHeaderStats
{
    Assets_Count = 0; 
    Assets_Count_Counter = 0;
    Assets_Active = 0; 
    Assets_Active_Counter = 0;
    Assets_Storage = 0;
    Assets_Storage_Counter = 0;
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