import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FlexLayoutModule } from '@angular/flex-layout';
import { RouterModule } from '@angular/router';
import { BoardModule } from './board/board.module';

import { CookieService } from 'ngx-cookie-service';
import { BoardService } from './services/board.service';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { BoardComponent } from './board/board.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { StockComponent } from './stock/stock.component';
import { StockModule } from './stock/stock.module';
import { MAT_DIALOG_DEFAULT_OPTIONS } from '@angular/material/dialog';
import { MAT_FORM_FIELD_DEFAULT_OPTIONS } from '@angular/material/form-field';
import { BoardHelpComponent } from './board/board-help/board-help.component';



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
], { relativeLinkResolution: 'legacy', initialNavigation: 'enabled' }),
    BrowserAnimationsModule
  ],
  providers: [
    { provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: {hasBackdrop: false}},
    { provide: MAT_FORM_FIELD_DEFAULT_OPTIONS, useValue: { appearance: 'fill' }},
    BoardService, 
    CookieService,
  ],
  bootstrap: [AppComponent],
  entryComponents: [BoardComponent, BoardHelpComponent]
})
export class AppModule { }
