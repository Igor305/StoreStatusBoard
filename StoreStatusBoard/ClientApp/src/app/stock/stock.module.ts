import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StockComponent } from '../stock/stock.component';
import { RouterModule } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { MatTooltipModule } from '@angular/material/tooltip';



@NgModule({
  declarations: [StockComponent],
  imports: [
    CommonModule,
    RouterModule,
    MatTableModule,
    MatTooltipModule
  ]
})
export class StockModule { }
