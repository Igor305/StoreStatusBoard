import { BreakpointObserver } from '@angular/cdk/layout';
import { Component, OnInit } from '@angular/core';
import { StockModel } from '../models/stock.model';
import { NavMenuComponent } from '../nav-menu/nav-menu.component';
import { BoardService } from '../services/board.service';

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.css']
})
export class BoardComponent implements OnInit {

  badPingStock: string = "";
  badPing: boolean = false;
  stocks: StockModel = {}
  showFiller: boolean = true;


  constructor(private boardService: BoardService, private breakpointObserver: BreakpointObserver) { }


  public async ngOnInit() {

    this.getBoard();
    //setInterval(() => this.getBoard(), 50000);

    const isSmallScreen = this.breakpointObserver.isMatched('(max-width: 1450px)');
    console.log(isSmallScreen);
  }

  public async getBoard() {

    let stocks = await this.boardService.getBoard();
    this.stocks = stocks.monitoringModels;

  }
  public async getStartBoard() {

    let stocks = await this.boardService.getStartBoard();
    this.stocks = stocks.monitoringModels;

  }
 /* public async getStatusStock(): Promise<string> {

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
