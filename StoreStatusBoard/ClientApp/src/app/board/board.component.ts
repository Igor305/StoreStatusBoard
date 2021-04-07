import { BreakpointObserver } from '@angular/cdk/layout';
import { Component, OnInit } from '@angular/core';
import { StockModel } from '../models/stock.model';
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
    setInterval(() => this.getBoard(), 10000);
    await this.boardService.getStatusPing();

  }

  public async getBoard() {

    let stocks = await this.boardService.getSession();
    this.stocks = stocks.monitoringModels;
  }
}
