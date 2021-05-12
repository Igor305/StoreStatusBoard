import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BoardResponseModel } from '../models/response/board.response.model';
import { DeviceInShopResponseModel } from '../models/response/device.response.model';
import { PingRedResponseModel } from '../models/response/ping.red.response.model';
import { ShopResponseModel } from '../models/response/shop.response.model';
import { StatusForDayResponseModel } from '../models/response/status.forday.response.model';
import { StatusResponseModel } from '../models/response/status.response.model';


@Injectable({
  providedIn: 'root'
})
export class BoardService {

  constructor(private http: HttpClient, private router: Router) { }

  public async getBoard(): Promise<BoardResponseModel>{
    const url: string = "/api/Board"; //https://localhost:44341
    const board = await this.http.get<BoardResponseModel>(url).toPromise();
    return board;
  }

  public async getLastTrueRouters(): Promise<BoardResponseModel>{
    const url: string = "/api/Board/GetLastTrueRouters";
    const board = await this.http.get<BoardResponseModel>(url).toPromise();
    return board;
  }

  public async getLastTrueS(): Promise<BoardResponseModel>{
    const url: string = "/api/Board/GetLastTrueS";
    const board = await this.http.get<BoardResponseModel>(url).toPromise();
    return board;
  }

  public async getPingRed(): Promise<PingRedResponseModel>{
    const url: string = "/api/Board/GetPingRed"; 
    const getPingReds = await this.http.get<PingRedResponseModel>(url).toPromise();
    return getPingReds;
  }

  public async getStatus(nshop: number): Promise<StatusResponseModel> {
    const url: string = "/api/Board/GetStatus";

    const params = new HttpParams()
      .set('nshop', nshop.toString());

    const shop = await this.http.get<StatusResponseModel>(url, { params: params }).toPromise();
    return shop;
  }

  public async getShopInfo(nshop: number): Promise<ShopResponseModel> {
    const url: string = "/api/Board/GetShopInfo";

    const params = new HttpParams()
      .set('nshop', nshop.toString());

    const shop = await this.http.get<ShopResponseModel>(url, { params: params }).toPromise();
    return shop;
  }

  public async getStatusForDay(nshop: number): Promise<StatusForDayResponseModel> {
    const url: string = "/api/Board/GetShopStatusForDay";

    const params = new HttpParams()
      .set('nshop', nshop.toString());

    const shop = await this.http.get<StatusForDayResponseModel>(url, { params: params }).toPromise();
    return shop;
  }

  public async getDeviceInShop(nshop: number): Promise<DeviceInShopResponseModel> {
    const url: string = "/api/Board/GetDeviceInShop";

    const params = new HttpParams()
      .set('nshop', nshop.toString());

    const shop = await this.http.get<DeviceInShopResponseModel>(url, { params: params }).toPromise();
    return shop;
  }
}
