import { Component, OnInit } from '@angular/core';
import { StockModel } from '../models/stock.model';
import { BoardService } from '../services/board.service';
import { AnimationOptions } from 'ngx-lottie';
import { PingRedModel } from '../models/ping.red.model';
import { MatDialog } from '@angular/material/dialog';
import { BoardHelpComponent } from './board-help/board-help.component';

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
  routers : StockModel[] = [];
  syncs : StockModel[] = []; 
  showFiller: boolean = true;
  pingReds: PingRedModel[] = [];

  options: AnimationOptions = {
    path: '/assets/data.json',
  };

  constructor(private boardService: BoardService, public dialog: MatDialog) { }

  public async ngOnInit() {

    await this.getBoard();
    setInterval(async () => await this.getBoard(), 60000);
    setInterval(async () => await this.getPingRed(), 60000);
  }

  public async getBoard(){
    
    let stocks = await this.boardService.getBoard();
    this.stocks = stocks.monitoringModels;

    let routers = await this.boardService.getLastTrueRouters();
    this.routers = routers.monitoringModels;

    let syncs = await this.boardService.getLastTrueS();
    this.syncs = syncs.monitoringModels;
  }

  public async getPingRed(){

    let pingReds = await this.boardService.getPingRed();
    this.pingReds = pingReds.pingRedModels;
  }

  openDialog() {
    const dialogRef = this.dialog.open(BoardHelpComponent, {width: "450px"});

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }
}