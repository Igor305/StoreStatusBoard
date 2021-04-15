import { Component } from '@angular/core';
import { BoardService } from '../services/board.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  screenWidth1450: boolean = false;
  timeNow: string = ""
  stockAmount: string = "";
  amountR: string = ""; 
  amountS: string = "";
  hideAmountR: string = "";
  middleAmountR: string = "";
  lowAmountR: string = "";
  routerPercent: string = "";
  syncPercent: string = "";
  stocks: any

  constructor(private boardService: BoardService, ) { }

  public async ngOnInit() {

    setInterval(() => this.getTime(), 1000);

    this.getBoard();
    setInterval(() => this.getBoard(), 60000);

  }

  public async getBoard(){
    
    var stocks = await this.boardService.getBoard();
    
    if(stocks.monitoringModels.length != 0){
      this.getHeader(stocks);
    }

  }

  public getHeader(stocks : any) {

    let stockAmount = 0;
    let amountR = 0;
    let amountS = 0;
    let hideAmountR = 0;
    let middleAmountR = 0;
    let lowAmountR = 0;

    for (var x  of stocks.monitoringModels) {

      if ((x.status == 0) && (x.isGrey == 0)) {
        amountR++;
      }
      if ((x.statusS == 0) && (x.isGrey == 0)) {
        amountS++;
      }

      if ((x.responseTime != 0) && (x.isGrey == 0)) {
        if (x.responseTime < 40) {
          hideAmountR++;
        }
        if ((x.responseTime >= 40) && (x.responseTime < 80)) {
          middleAmountR++;
        }
        if (x.responseTime >= 80) {
          lowAmountR++;
        }
      }

      if (x.isGrey == 0) {
        stockAmount++;
      }
    }

    this.routerPercent = ((stocks.monitoringModels.length - amountR) / stocks.monitoringModels.length * 100).toFixed(2);
    this.syncPercent = ((stocks.monitoringModels.length - amountS) / stocks.monitoringModels.length * 100).toFixed(2);

    this.stockAmount = stockAmount.toString();
    this.amountS = amountS.toString();
    this.amountR = amountR.toString();
    this.hideAmountR = hideAmountR.toString();
    this.middleAmountR = middleAmountR.toString();
    this.lowAmountR = lowAmountR.toString();  
  }

  public async getTime() {

    const now = new Date();

    let min, sec = "";
    if (now.getMinutes()<10) {min = "0"+ now.getMinutes();}
    if (now.getMinutes()>=10) {min = now.getMinutes();}
    if (now.getSeconds()<10) {sec = "0"+ now.getSeconds();}
    if (now.getSeconds()>=10) {sec = now.getSeconds().toString();}
    
    this.timeNow = now.getHours() + ":" + min + ":" + sec;
  }

}