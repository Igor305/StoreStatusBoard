import { Component, OnInit } from '@angular/core';
import { StockModel } from '../models/stock.model';
import { BoardService } from '../services/board.service';

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.css']
})
export class BoardComponent implements OnInit {

  stocks: StockModel

  constructor(private boardService : BoardService) { }

  async ngOnInit() {
    this.stocks = await this.boardService.getBoard();
    console.log(this.stocks);
  }

}
