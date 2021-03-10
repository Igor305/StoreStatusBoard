import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { DeviceInShopResponseModel } from '../models/response/device.response';
import { ShopResponseModel } from '../models/response/shop.response';
import { BoardService } from '../services/board.service';

@Component({
  selector: 'app-stock',
  templateUrl: './stock.component.html',
  styleUrls: ['./stock.component.css']
})
export class StockComponent implements OnInit {

  shopId: number
  shopInfo: ShopResponseModel = {}
  deviceInShop: DeviceInShopResponseModel = {}

  constructor(private boardService: BoardService, private route: ActivatedRoute) { }

  public async ngOnInit() {

    this.shopId = this.route.snapshot.params['shopId'];

    this.getShopInfo();
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
}
