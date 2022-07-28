import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

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
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
