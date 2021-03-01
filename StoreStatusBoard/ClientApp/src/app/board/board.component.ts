import { Component, OnInit } from '@angular/core';
import { StockModel } from '../models/stock.model';
import { BoardService } from '../services/board.service';

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.css']
})
export class BoardComponent implements OnInit {

  badPingStock: string = "";
  badPing: boolean = false;
  stocks: StockModel
  showFiller: boolean = true;


  constructor(private boardService: BoardService) { }

  public async ngOnInit() {
    this.stocks = await this.boardService.getBoard();
    console.log(this.stocks);
    setInterval(() => this.getBoard(), 50000);
  }

  public async getBoard() {

    this.stocks = await this.boardService.getBoard();
    console.log(this.stocks);

  }

  public async getStatusStock(): Promise<string> {

    var stock = await this.boardService.getBoard();
    if (!this.badPing) {
      this.badPingStock = stock.LogTime.toString();
      this.badPing = true;
      }
    this.badPingStock = stock.Stock.toString();
    this.badPing = false;

    return this.badPingStock;
  }

}
