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

    const isSmallScreen = this.breakpointObserver.isMatched('(max-width: 1450px)');
    console.log(isSmallScreen);
  }

  public async getBoard() {

    let stocks = await this.boardService.getSession();
    this.stocks = stocks.monitoringModels;
  }
}
