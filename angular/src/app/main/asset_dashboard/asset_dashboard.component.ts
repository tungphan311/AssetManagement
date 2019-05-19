import { Component, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { DonViServiceProxy, DonViDto } from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: './asset_dashboard.component.html',
    styleUrls: ['./asset_dashboard.component.css'],
    animations: [appModuleAnimation()]
})

export class AssetDashboardComponent extends AppComponentBase implements OnInit
{
    people: DonViDto[] = [];
	chart: PieChartData;
    header_stats: AssetHeaderStats;

    constructor(injector: Injector, private _DonViService: DonViServiceProxy) 
    {
        super(injector);
        this.chart = new PieChartData();
        this.header_stats = new AssetHeaderStats();
        // this.userName = this.appSession.user.userName;
        // if(this.appSession.user.userName == "admin")
        //     this.userName = "DonViChinh";
    }

    ngOnInit(): void 
    {
    	this.getData();
    }

    getData(): void
    {
        this._DonViService.getDonVi("").subscribe( result => 
        {
            this.get_display_data(result);
            this.people = result;
        });
    }

    get_display_data(result): void
    {
    	this.header_stats.Assets_Count = result[0].soLuongTaiSan;
        this.header_stats.Assets_Active = result[0].taiSanSuDung;
        this.header_stats.Assets_Storage = result[0].taiSanTrongKho;
        this.header_stats.Assets_Disposed = result[0].taiSanHu;

        if(this.header_stats.Assets_Count > 0)
        {
        	let perimeter = 2* 3.14 * 100;
        	this.chart.Perimeter = perimeter;
        	this.chart.Assets_Active_Span = 0;
        	this.chart.Assets_Storage_Span = 1 - (result[0].taiSanTrongKho/result[0].soLuongTaiSan) - (result[0].taiSanHu/result[0].soLuongTaiSan);
        	this.chart.Assets_Disposed_Span = 1 - (result[0].taiSanHu/result[0].soLuongTaiSan);
        	this.chart.Assets_Active_Span *= -perimeter;
        	this.chart.Assets_Storage_Span *= -perimeter;
        	this.chart.Assets_Disposed_Span *= -perimeter;
        }
    }

}



class PieChartData
{
	Perimeter = 0;
    Assets_Active_Span = 0;
    Assets_Storage_Span = 0;
    Assets_Disposed_Span = 0;
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
}
