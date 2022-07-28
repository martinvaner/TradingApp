import { Component, OnInit } from '@angular/core';
import { Ticker } from 'src/app/interfaces/Ticker';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  tickers: Ticker[];

  constructor() { }

  ngOnInit(): void {
    this.tickers = [
      {
        symbol: 'AMZN',
        prices: [ {close: 20}, {close: 22} ],
        analytics: { movingAverage: { sma200: 25, sma50: 30 } }
      },
      {
        symbol: 'META',
        prices: [ {close: 20}, {close: 22} ],
        analytics: { movingAverage: { sma200: 25, sma50: 30 } }
      },
      {
        symbol: 'TSLA',
        prices: [ {close: 20}, {close: 22} ],
        analytics: { movingAverage: { sma200: 25, sma50: 30 } }
      },
      {
        symbol: 'VNTR',
        prices: [ {close: 20}, {close: 22} ],
        analytics: { movingAverage: { sma200: 25, sma50: 30 } }
      }
    ]
  }

}
