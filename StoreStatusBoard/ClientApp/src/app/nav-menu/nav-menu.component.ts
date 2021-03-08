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
  stockAmount: string = ""
  amountR: number 
  amountS: number
  hideAmountR: number 
  middleAmountR: number 
  lowAmountR: number 
  routerPercent: any
  syncPercent: any

  constructor(private boardService: BoardService, ) { }

  public async ngOnInit() {

    this.getBoard();
    setInterval(() => this.getTime(), 1000);
    setInterval(() => this.getBoard(), 50000);
  }

  public async getBoard() {
    let stocks = await this.boardService.getBoard();
    this.stockAmount = stocks.amount;
    this.amountR = 0;
    this.amountS = 0;
    this.hideAmountR = 0;
    this.middleAmountR = 0;
    this.lowAmountR = 0;
    var numStocks = Number(stocks.amount);
    console.log(stocks.monitoringModels);
    for (var x = 0; x < numStocks; x++) {

      if ((stocks.monitoringModels[x].status == 0) && (stocks.monitoringModels[x].isGrey == 0)) {
        this.amountR++;
      }
      if ((stocks.monitoringModels[x].statusS == 0) && (stocks.monitoringModels[x].isGrey == 0)) {
        this.amountS++;
      }
      if ((stocks.monitoringModels[x].responseTime != 0) && (stocks.monitoringModels[x].isGrey == 0)) {
        if (stocks.monitoringModels[x].responseTime < 40) {
          this.hideAmountR++;
        }
        if ((stocks.monitoringModels[x].responseTime >= 40) && (stocks.monitoringModels[x].responseTime < 80)) {
          this.middleAmountR++;
        }
        if (stocks.monitoringModels[x].responseTime >= 80) {
          this.lowAmountR++;
        }
      }
    }
    this.routerPercent = ((numStocks - this.amountR) / numStocks * 100).toFixed(2);
    this.syncPercent = ((numStocks - this.amountS) / numStocks * 100).toFixed(2);
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
