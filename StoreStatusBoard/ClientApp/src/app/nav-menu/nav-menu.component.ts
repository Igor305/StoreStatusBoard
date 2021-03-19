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

    this.getState();
    setInterval(() => this.getTime(), 1000);
    setInterval(() => this.getState(), 50000);
  }

  public async getState() {

    let stocks = await this.boardService.getBoard();
    this.amountR = 0;
    this.amountS = 0;
    this.hideAmountR = 0;
    this.middleAmountR = 0;
    this.lowAmountR = 0;

    for (var x  of stocks.monitoringModels) {

      if ((x.status == 0) && (x.isGrey == 0)) {
        this.amountR++;
      }
      if ((x.statusS == 0) && (x.isGrey == 0)) {
        this.amountS++;
      }
      if ((x.responseTime != 0) && (x.isGrey == 0)) {
        if (x.responseTime < 40) {
          this.hideAmountR++;
        }
        if ((x.responseTime >= 40) && (x.responseTime < 80)) {
          this.middleAmountR++;
        }
        if (x.responseTime >= 80) {
          this.lowAmountR++;
        }
      }
    }
    this.routerPercent = ((stocks.monitoringModels.length - this.amountR) / stocks.monitoringModels.length * 100).toFixed(2);
    this.syncPercent = ((stocks.monitoringModels.length - this.amountS) / stocks.monitoringModels.length * 100).toFixed(2);
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
