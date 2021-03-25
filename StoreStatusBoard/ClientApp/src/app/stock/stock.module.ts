import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StockComponent } from '../stock/stock.component';
import { RouterModule } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { MatTooltipModule } from '@angular/material/tooltip';
import { LottieModule } from 'ngx-lottie';
import player from 'lottie-web';

export function playerFactory() {
  return player;
}


@NgModule({
  declarations: [StockComponent],
  imports: [
    CommonModule,
    RouterModule,
    MatTableModule,
    MatTooltipModule,
    LottieModule.forRoot({ player: playerFactory })
  ]
})
export class StockModule { }
