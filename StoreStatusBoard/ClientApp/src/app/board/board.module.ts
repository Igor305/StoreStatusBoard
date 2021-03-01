import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BoardComponent } from '../board/board.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [BoardComponent],
  imports: [
    CommonModule,
    MatSidenavModule,
    RouterModule
  ]
})
export class BoardModule { }
