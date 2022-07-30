import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { TickerBasicInfoComponent } from './components/ticker-basic-info/ticker-basic-info.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    TickerBasicInfoComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
