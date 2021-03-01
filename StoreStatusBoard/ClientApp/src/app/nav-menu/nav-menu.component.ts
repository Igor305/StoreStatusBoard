import { Component } from '@angular/core';
import { BoardService } from '../services/board.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  timeNow: string = ""
  stockAmount: string = ""
  amountR: number 
  amountS: number
  hideAmountR: number 
  middleAmountR: number 
  lowAmountR: number 
  routerPercent: any

  constructor(private boardService: BoardService) { }

  public async ngOnInit() {

    setInterval(() => this.getTime(), 1000);

    let stocks = await this.boardService.getBoard();
    this.stockAmount = stocks.amount;
    this.amountR = 0;
    this.hideAmountR = 0;
    this.middleAmountR = 0;
    this.lowAmountR = 0;
    var numStocks = Number(stocks.amount);
    console.log(stocks.monitoringModelsR);
    for (var x = 0; x < numStocks; x++) {

      if (stocks.monitoringModelsR[x].status == 0) {
        this.amountR++;
      }
      if (stocks.monitoringModelsR[x].responseTime != 0) {
        if (stocks.monitoringModelsR[x].responseTime < 40) {
          this.hideAmountR++;
        }
        if ((stocks.monitoringModelsR[x].responseTime >= 40) && (stocks.monitoringModelsR[x].responseTime < 80)) {
          this.middleAmountR++;
        }
        if (stocks.monitoringModelsR[x].responseTime >= 80) {
          this.lowAmountR++;
        }
      }
    }
    this.routerPercent = ((this.hideAmountR + this.middleAmountR + this.lowAmountR) / numStocks * 100).toFixed(2);
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
