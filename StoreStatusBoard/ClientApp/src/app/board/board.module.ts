import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BoardComponent } from '../board/board.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { LayoutModule } from '@angular/cdk/layout';
import { RouterModule } from '@angular/router';
import { MatDialogModule } from '@angular/material/dialog';
import { LottieModule } from 'ngx-lottie';
import  player from 'lottie-web';
import { BoardHelpComponent } from './board-help/board-help.component';

export function playerFactory() {
  return player;
}

@NgModule({
  declarations: [BoardComponent, BoardHelpComponent],
  imports: [
    CommonModule,
    MatSidenavModule,
    LayoutModule,
    RouterModule,
    MatDialogModule,
    LottieModule.forRoot({ player: playerFactory })
  ],
  entryComponents: [BoardComponent, BoardHelpComponent]
})
export class BoardModule { }
