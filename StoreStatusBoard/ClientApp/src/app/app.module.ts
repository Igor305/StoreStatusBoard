import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FlexLayoutModule } from '@angular/flex-layout';
import { RouterModule } from '@angular/router';
import { BoardModule } from './board/board.module';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { BoardComponent } from './board/board.component';
import { BoardService } from './services/board.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { StockComponent } from './stock/stock.component';
import { StockModule } from './stock/stock.module';



@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BoardModule,
    StockModule,
    HttpClientModule,
    FormsModule,
    FlexLayoutModule,
    RouterModule.forRoot([
    { path: '', component: BoardComponent, pathMatch: 'full' },
    { path: ':shopId', component: StockComponent }
], { relativeLinkResolution: 'legacy' }),
    BrowserAnimationsModule
  ],
  providers: [BoardService],
  bootstrap: [AppComponent]
})
export class AppModule { }
