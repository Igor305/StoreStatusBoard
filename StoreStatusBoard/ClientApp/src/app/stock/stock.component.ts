import { Component, OnInit } from '@angular/core';
import { ShopResponseModel } from '../models/response/shop.response';
import { BoardService } from '../services/board.service';

@Component({
  selector: 'app-stock',
  templateUrl: './stock.component.html',
  styleUrls: ['./stock.component.css']
})
export class StockComponent implements OnInit {

  shopInfo : ShopResponseModel

  constructor(private boardService: BoardService) { }

  public async ngOnInit() {

    this.shopInfo = await this.boardService.getShopInfo(5);
    console.log(this.shopInfo);
  }


}
