import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { ChartType } from 'chart.js'

@Component({
    templateUrl: './asset_dashboard.component.html',
    styleUrls: ['./asset_dashboard.component.css'],
    animations: [appModuleAnimation()]
})

export class AssetDashboardComponent extends AppComponentBase 
{
	header_stats: AssetHeaderStats;
	assets_state_chart: ProfitSharePieChart;

    constructor(injector: Injector) 
    {
        super(injector);
        this.header_stats = new AssetHeaderStats();
        this.assets_state_chart = new ProfitSharePieChart('#m_chart_profit_share');
    }  
}

class AssetHeaderStats
{

    Assets_Count = 0; 
    Assets_Count_Counter = 0;
    Assets_Value = 0; 
    Assets_Value_Counter = 0;
    Request_Count = 0; 
    Request_Count_Counter = 0;
    newUsers = 0; newUsersCounter = 0;

    totalProfitChange = 76; totalProfitChangeCounter = 0;
    newFeedbacksChange = 85; newFeedbacksChangeCounter = 0;
    newOrdersChange = 45; newOrdersChangeCounter = 0;
    newUsersChange = 57; newUsersChangeCounter = 0;

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

    constructor(canvasId: string) 
    {
        this._canvasId = canvasId;
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
        if ($(this._canvasId).length === 0) 
        {
            return;
        }

        let chart = new Chart($(this._canvasId), {
            type: 'doughnut',
            data: this.chartData,
            //options: Chart.defaults.doughnut,
        });

        //this.hideLoading();
    }
}