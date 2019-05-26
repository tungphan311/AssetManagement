import { Component, Injector, OnInit } from '@angular/core';
import { AppComponentBase } from '@shared/common/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { DonViServiceProxy, UnitTaiSanDto } from '@shared/service-proxies/service-proxies';

@Component({
    templateUrl: './asset_dashboard.component.html',
    styleUrls: ['./asset_dashboard.component.css'],
    animations: [appModuleAnimation()]
})

export class AssetDashboardComponent extends AppComponentBase implements OnInit
{
	chart: PieChartData;
    header_stats: AssetHeaderStats;
    unit_taisan: UnitTaiSanDto[] = [];

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
        this._DonViService.getUnit().subscribe( result => 
        {
            this.unit_taisan = result;
            this.get_display_data();
        });
    }

    get_display_data(): void
    {
    	this.header_stats.Assets_Count = this.unit_taisan[0].soLuong;
        this.header_stats.Assets_Active = this.unit_taisan[0].suDung;
        this.header_stats.Assets_Storage = this.unit_taisan[0].trongKho;
        this.header_stats.Assets_Disposed = this.unit_taisan[0].huHong;

        if(this.header_stats.Assets_Count > 0)
        {
        	let perimeter = 2* 3.14 * 100;
        	this.chart.Perimeter = perimeter;
        	this.chart.Assets_Active_Span = 0;
        	this.chart.Assets_Storage_Span = 1 - (this.unit_taisan[0].trongKho/this.unit_taisan[0].soLuong) - (this.unit_taisan[0].huHong/this.unit_taisan[0].soLuong);
        	this.chart.Assets_Disposed_Span = 1 - (this.unit_taisan[0].huHong/this.unit_taisan[0].soLuong);
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
