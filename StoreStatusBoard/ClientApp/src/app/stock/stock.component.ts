import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { DeviceInShopResponseModel } from '../models/response/device.response';
import { ShopResponseModel } from '../models/response/shop.response';
import { StatusTableModel } from '../models/table/status.table.model';
import { BoardService } from '../services/board.service';

@Component({
  selector: 'app-stock',
  templateUrl: './stock.component.html',
  styleUrls: ['./stock.component.css']
})
export class StockComponent implements OnInit {

  shopId: number = 0;
  hideStatusHourForDay: number = 0;
  statusMinutsForDay: boolean = false;
  shopInfo: ShopResponseModel = {}
  deviceInShop: DeviceInShopResponseModel = {}

  constructor(private boardService: BoardService, private route: ActivatedRoute) { }

  public async ngOnInit() {

    this.shopId = this.route.snapshot.params['shopId'];

    this.getShopInfo();

    var date = new Date();
    let hour = date.getHours();
    let minutes = date.getMinutes();
    let count = 7;

    this.getTime(hour, minutes, count);

    console.log(this.hideStatusHourForDay);
    console.log(this.statusMinutsForDay);

    this.getDeviceInShop();

  }

  public async getShopInfo() {

    console.log(this.shopId);

    this.shopInfo = await this.boardService.getShopInfo(this.shopId);

    console.log(this.shopInfo);

  }

  public async getDeviceInShop() {

    this.deviceInShop = await this.boardService.getDeviceInShop(this.shopId);

    console.log(this.deviceInShop.devices);
  }

  public getTime(hours: number, minutes: number, count : number) {

    if (hours >= count) {
      if (hours >= count + 1) {

        this.getTime(hours, minutes, ++count);
      }
      else {

        if (minutes >= 30) {

          this.statusMinutsForDay = true;

        }
        if (minutes < 30) {

          this.statusMinutsForDay = false;

        }
      }
    }
    this.hideStatusHourForDay = hours;
  }
}
