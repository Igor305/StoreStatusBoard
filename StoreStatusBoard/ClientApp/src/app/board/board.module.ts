import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BoardComponent } from '../board/board.component';
import { MatTabsModule } from '@angular/material/tabs';



@NgModule({
  declarations: [BoardComponent],
  imports: [
    CommonModule,
    MatTabsModule
  ]
})
export class BoardModule { }
