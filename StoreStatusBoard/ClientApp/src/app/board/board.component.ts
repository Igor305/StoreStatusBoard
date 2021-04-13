import { BreakpointObserver } from '@angular/cdk/layout';
import { Component, OnInit } from '@angular/core';
import { StockModel } from '../models/stock.model';
import { BoardService } from '../services/board.service';
import { AnimationOptions } from 'ngx-lottie';
import { PingRedModel } from '../models/ping.red.model';

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.css']
})
export class BoardComponent implements OnInit {

  opened: boolean = true;
  badPingStock: string = "";
  badPing: boolean = false;
  stocks: StockModel[] = [];
  showFiller: boolean = true;
  pingReds: PingRedModel[] = [];

  options: AnimationOptions = {
    path: '/assets/data.json',
  };

  constructor(private boardService: BoardService, private breakpointObserver: BreakpointObserver) { }


  public async ngOnInit() {

    this.getBoard();
    setInterval(() => this.getBoard(), 60000);
    setInterval(() => this.getPingRed(), 60000);
  }

  public async getBoard(){
    
    let stocks = await this.boardService.getBoard();
    if(stocks.monitoringModels.length == 0){
      console.log("0");
    }
    if(stocks.monitoringModels.length != 0){
      console.log("WTF");
      this.stocks = stocks.monitoringModels;
    }

  }

  public async getPingRed(){

    let pingReds = await this.boardService.getPingRed();
    this.pingReds = pingReds.pingRedModels;
  }
}
