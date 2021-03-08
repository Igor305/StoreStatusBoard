import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { switchMap } from 'rxjs/operators';
import { ShopResponseModel } from '../models/response/shop.response';
import { BoardService } from '../services/board.service';

@Component({
  selector: 'app-stock',
  templateUrl: './stock.component.html',
  styleUrls: ['./stock.component.css']
})
export class StockComponent implements OnInit {

  shopId: number
  shopInfo : ShopResponseModel

  constructor(private boardService: BoardService, private route: ActivatedRoute) { }

  public async ngOnInit() {

    this.shopId = this.route.snapshot.params['shopId'];

    this.getShopInfo();

  }


  public async getShopInfo() {

    console.log(this.shopId);

    this.shopInfo = await this.boardService.getShopInfo(this.shopId);

  }


}
