import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BoardComponent } from '../board/board.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { LayoutModule } from '@angular/cdk/layout';
import { RouterModule } from '@angular/router';
import { LottieModule } from 'ngx-lottie';
import  player from 'lottie-web';

export function playerFactory() {
  return player;
}

@NgModule({
  declarations: [BoardComponent],
  imports: [
    CommonModule,
    MatSidenavModule,
    LayoutModule,
    RouterModule,
    LottieModule.forRoot({ player: playerFactory })
  ]
})
export class BoardModule { }
