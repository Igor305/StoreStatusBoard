import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BoardResponseModel } from '../models/response/board.response.model';
import { ShopResponseModel } from '../models/response/shop.response';

@Injectable({
  providedIn: 'root'
})
export class BoardService {

  constructor(private http: HttpClient, private router: Router) { }

  public async getBoard(): Promise<BoardResponseModel> {
    const url: string = "https://localhost:44341/api/Board";
    const board = await this.http.get<BoardResponseModel>(url).toPromise();

    return board;
  }

  public async getShopInfo(nshop:number): Promise<ShopResponseModel> {
    const url: string = "https://localhost:44341/api/Board/Shop";
    const shop = await this.http.get<ShopResponseModel>(url).toPromise();

    return shop;
  }
}
