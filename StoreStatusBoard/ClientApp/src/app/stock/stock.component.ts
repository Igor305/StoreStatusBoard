import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DeviceInShopResponseModel } from '../models/response/device.response.model';
import { ShopResponseModel } from '../models/response/shop.response.model';
import { StatusForDayResponseModel } from '../models/response/status.forday.response.model';
import { StatusTableModel } from '../models/table/status.table.model';
import { BoardService } from '../services/board.service';

@Component({
  selector: 'app-stock',
  templateUrl: './stock.component.html',
  styleUrls: ['./stock.component.css']
})

export class StockComponent implements OnInit  {

  shopId: number = 0;
  hideStatusHourForDay: number = 0;
  statusMinutsForDay: boolean = false;
  shopInfo: ShopResponseModel = {};
  statusForDay: StatusForDayResponseModel = {};
  deviceInShop: DeviceInShopResponseModel = {};

  status7 : string = "";
  status7m : string = "";
  status8 : string = "";
  status8m : string = "";
  status9 : string = "";
  status9m : string = "";
  status10 : string = "";
  status10m : string = "";
  status11 : string = "";
  status11m : string = "";
  status12 : string = "";
  status12m : string = ""; 
  status13 : string = "";
  status13m: string = "";
  status14: string = "";
  status14m: string = "";
  status15: string = "";
  status15m: string = "";
  status16: string = "";
  status16m: string = "";
  status17: string = "";
  status17m: string = "";
  status18: string = "";
  status18m: string = "";
  status19: string = "";
  status19m: string = "";
  status20: string = "";
  status20m: string = "";
  status21: string = "";
  status21m: string = "";
  status22: string = "";

  constructor(private boardService: BoardService, private route: ActivatedRoute) { }

  public async ngOnInit() {

    this.shopId = this.route.snapshot.params['shopId'];

    this.getStatusForDay();

    this.getDeviceInShop();

    this.getShopInfo();

  }

  public async getShopInfo() {

    this.shopInfo = await this.boardService.getShopInfo(this.shopId);

  }

  public async getDeviceInShop() {

    this.deviceInShop = await this.boardService.getDeviceInShop(this.shopId);

  }

  public async getStatusForDay() {

    this.statusForDay = await this.boardService.getStatusForDay(this.shopId);

    if (this.statusForDay.status7 == -1){
      for (let status7 of this.statusForDay.statusForDayModels7) {
        this.status7 = this.status7 + status7.device + " : " + status7.logTime + "\r\n";
      }
    }
    if (this.statusForDay.status7m == -1) {
      for (let status7m of this.statusForDay.statusForDayModels7m) {
        this.status7m = this.status7m + status7m.device + " : " + status7m.logTime + "\r\n";
      }
    }
    if (this.statusForDay.status8 == -1) {
      for (let status8 of this.statusForDay.statusForDayModels8) {
        this.status8 = this.status8 + status8.device + " : " + status8.logTime + "\r\n";
      }
    }
    if (this.statusForDay.status8m == -1) {
      for (let status8m of this.statusForDay.statusForDayModels8m) {
        this.status8m = this.status8m + status8m.device + " : " + status8m.logTime + "\r\n";
      }
    }
    if (this.statusForDay.status9 == -1) {
      for (let status9 of this.statusForDay.statusForDayModels9) {
        this.status9 = this.status9 + status9.device + " : " + status9.logTime + "\r\n";
      }
    }
    if (this.statusForDay.status9m == -1) {
      for (let status9m of this.statusForDay.statusForDayModels9m) {
        this.status9m = this.status9m + status9m.device + " : " + status9m.logTime + "\r\n";
      }
    }
    if (this.statusForDay.status10 == -1) {
      for (let status10 of this.statusForDay.statusForDayModels10) {
        this.status10 = this.status10 + status10.device + " : " + status10.logTime + "\r\n";
      }
    }
    if (this.statusForDay.status10m == -1) {
      for (let status10m of this.statusForDay.statusForDayModels10m) {
        this.status10m = this.status7m + status10m.device + " : " + status10m.logTime + "\r\n";
      }
    }
    if (this.statusForDay.status11 == -1) {
      for (let status11 of this.statusForDay.statusForDayModels11) {
        this.status11 = this.status11 + status11.device + " : " + status11.logTime + "\r\n";
      }
    }
    if (this.statusForDay.status11m == -1) {
      for (let status11m of this.statusForDay.statusForDayModels11m) {
        this.status11m = this.status11m + status11m.device + " : " + status11m.logTime + "\r\n";
      }
    }
    if (this.statusForDay.status12 == -1) {
      for (let status12 of this.statusForDay.statusForDayModels12 ) {
        this.status12 = this.status12 + status12.device + " : " + status12 .logTime + "\r\n";
      }
    }
    if (this.statusForDay.status12m == -1) {
      for (let status12m of this.statusForDay.statusForDayModels12m) {
        this.status12m = this.status12m + status12m.device + " : " + status12m.logTime + "\r\n";
      }
    }
    if (this.statusForDay.status13 == -1) {
      for (let status13 of this.statusForDay.statusForDayModels13) {
        this.status13 = this.status13 + status13.device + " : " + status13.logTime + "\r\n";
      }
    }
    if (this.statusForDay.status13m == -1) {
      for (let status13m of this.statusForDay.statusForDayModels13m) {
        this.status13m = this.status13m + status13m.device + " : " + status13m.logTime + "\r\n";
      }
    }
    if (this.statusForDay.status14 == -1) {
      for (let status14 of this.statusForDay.statusForDayModels14) {
        this.status14 = this.status14 + status14.device + " : " + status14.logTime + "\r\n";
      }
    }
    if (this.statusForDay.status14m == -1) {
      for (let status14m of this.statusForDay.statusForDayModels14m) {
        this.status14m = this.status14m + status14m.device + " : " + status14m.logTime + "\r\n";
      }
    }
    if (this.statusForDay.status15 == -1) {
      for (let status15 of this.statusForDay.statusForDayModels15) {
        this.status15 = this.status15 + status15.device + " : " + status15.logTime + "\r\n";
      }
    }
    if (this.statusForDay.status15m == -1) {
      for (let status15m of this.statusForDay.statusForDayModels15m) {
        this.status15m = this.status15m + status15m.device + " : " + status15m.logTime + "\r\n";
      }
    }
    if (this.statusForDay.status16 == -1) {
      for (let status16 of this.statusForDay.statusForDayModels16) {
        this.status16 = this.status16 + status16.device + " : " + status16.logTime + "\r\n";
      }
    }
    if (this.statusForDay.status16m == -1) {
      for (let status16m of this.statusForDay.statusForDayModels16m) {
        this.status16m = this.status16m + status16m.device + " : " + status16m.logTime + "\r\n";
      }
    }
    if (this.statusForDay.status17 == -1) {
      for (let status17 of this.statusForDay.statusForDayModels17) {
        this.status17 = this.status17 + status17.device + " : " + status17.logTime + "\r\n";
      }
    }
    if (this.statusForDay.status17m == -1) {
      for (let status17m of this.statusForDay.statusForDayModels17m) {
        this.status17m = this.status17m + status17m.device + " : " + status17m.logTime + "\r\n";
      }
    }
    if (this.statusForDay.status18 == -1) {
      for (let status18 of this.statusForDay.statusForDayModels18) {
        this.status18 = this.status18 + status18.device + " : " + status18.logTime + "\r\n";
      }
    }
    if (this.statusForDay.status18m == -1) {
      for (let status18m of this.statusForDay.statusForDayModels18m) {
        this.status18m = this.status18m + status18m.device + " : " + status18m.logTime + "\r\n";
      }
    }
    if (this.statusForDay.status19 == -1) {
      for (let status19 of this.statusForDay.statusForDayModels19) {
        this.status19 = this.status19 + status19.device + " : " + status19.logTime + "\r\n";
      }
    }
    if (this.statusForDay.status19m == -1) {
      for (let status19m of this.statusForDay.statusForDayModels19m) {
        this.status19m = this.status19 + status19m.device + " : " + status19m.logTime + "\r\n";
      }
    }
    if (this.statusForDay.status20 == -1) {
      for (let status20 of this.statusForDay.statusForDayModels20) {
        this.status20 = this.status20 + status20.device + " : " + status20.logTime + "\r\n";
      }
    }
    if (this.statusForDay.status20m == -1) {
      for (let status20m of this.statusForDay.statusForDayModels20m) {
        this.status20m = this.status20m + status20m.device + " : " + status20m.logTime + "\r\n";
      }
    }
    if (this.statusForDay.status21 == -1) {
      for (let status21 of this.statusForDay.statusForDayModels21) {
        this.status21 = this.status21 + status21.device + " : " + status21.logTime + "\r\n";
      }
    }
    if (this.statusForDay.status21m == -1) {
      for (let status21m of this.statusForDay.statusForDayModels21m) {
        this.status21m = this.status21m + status21m.device + " : " + status21m.logTime + "\r\n";
      }
    }
    if (this.statusForDay.status22 == -1) {
      for (let status22 of this.statusForDay.statusForDayModels22) {
        this.status22 = this.status22 + status22.device + " : " + status22.logTime + "\r\n";
      }
    }
  }
}
