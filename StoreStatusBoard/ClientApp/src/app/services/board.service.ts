import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BoardResponseModel } from '../models/response/board.response.model';
import { DeviceInShopResponseModel } from '../models/response/device.response.model';
import { ShopResponseModel } from '../models/response/shop.response.model';
import { StatusForDayResponseModel } from '../models/response/status.forday.response.model';

@Injectable({
  providedIn: 'root'
})
export class BoardService {

  constructor(private http: HttpClient, private router: Router) { }

  public async getBoard(): Promise<BoardResponseModel> {
    const url: string = "/api/Board"; //https://localhost:44341
    const board = await this.http.get<BoardResponseModel>(url).toPromise();

    return board;
  }

  public async getStartBoard(): Promise<BoardResponseModel> {
    const url: string = "/api/Board/Start";
    const board = await this.http.get<BoardResponseModel>(url).toPromise();

    return board;
  }

  public async getShopInfo(nshop: number): Promise<ShopResponseModel> {
    const url: string = "/api/Board/ShopInfo";

    const params = new HttpParams()
      .set('nshop', nshop.toString());

    const shop = await this.http.get<ShopResponseModel>(url, { params: params }).toPromise();
    return shop;
  }

  public async getStatusForDay(nshop: number): Promise<StatusForDayResponseModel> {
    const url: string = "/api/Board/ShopStatusForDay";

    const params = new HttpParams()
      .set('nshop', nshop.toString());

    const shop = await this.http.get<StatusForDayResponseModel>(url, { params: params }).toPromise();
    return shop;
  }

  public async getDeviceInShop(nshop: number): Promise<DeviceInShopResponseModel> {
    const url: string = "/api/Board/DeviceInShop";

    const params = new HttpParams()
      .set('nshop', nshop.toString());

    const shop = await this.http.get<DeviceInShopResponseModel>(url, { params: params }).toPromise();
    return shop;
  }
}
