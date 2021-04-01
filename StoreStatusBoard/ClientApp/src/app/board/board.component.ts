import { BreakpointObserver } from '@angular/cdk/layout';
import { Component, OnInit } from '@angular/core';
import { StockModel } from '../models/stock.model';
import { NavMenuComponent } from '../nav-menu/nav-menu.component';
import { BoardService } from '../services/board.service';
import { AnimationOptions } from 'ngx-lottie';

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

  options: AnimationOptions = {
    path: '/assets/data.json',
  };

  constructor(private boardService: BoardService, private breakpointObserver: BreakpointObserver) { }


  public async ngOnInit() {

    this.getBoard();
    setInterval(() => this.getBoard(), 50000);
    //await this.boardService.getRecordSession();
    //this.stocks = JSON.parse(sessionStorage.getItem("board"));


    const isSmallScreen = this.breakpointObserver.isMatched('(max-width: 1450px)');
    console.log(isSmallScreen);
  }

  public async getBoard() {

    let stocks = await this.boardService.getSession();
    this.stocks = stocks.monitoringModels;
    console.log(this.stocks);
   // sessionStorage.setItem("board", JSON.stringify(stocks.monitoringModels));
  //  this.stocks = JSON.parse(sessionStorage.getItem("board"));
  }

  public async getStartBoard() {


  }
 /* public a
  * sync getStatusStock(): Promise<string> {

    var stock = await this.boardService.getBoard();
    if (!this.badPing) {
      this.badPingStock = stock.LogTime.toString();
      this.badPing = true;
      }
    this.badPingStock = stock.Stock.toString();
    this.badPing = false;

    return this.badPingStock;
  }*/
}
