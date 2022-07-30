import { Component, OnInit } from '@angular/core';
import { Ticker } from 'src/app/interfaces/Ticker';
import { HttpService } from 'src/app/services/HttpService';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  tickers: Ticker[];

  constructor(private httpService: HttpService) { }

  ngOnInit(): void {

    this.httpService.getUserData("vaner").subscribe({
      next: data => {
        console.log(data);
        this.tickers = data;
      },
      error: error => {
        console.log("Error ocurred while getting data: " + error);
      }
    })


    /*this.tickers = [
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
    ] */
  }

}
