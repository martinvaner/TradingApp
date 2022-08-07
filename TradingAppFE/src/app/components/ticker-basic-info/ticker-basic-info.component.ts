import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Ticker } from 'src/app/interfaces/Ticker';
import { Tickers } from 'src/app/interfaces/Tickers';
import { HttpService } from 'src/app/services/HttpService';

@Component({
  selector: 'app-ticker-basic-info',
  templateUrl: './ticker-basic-info.component.html',
  styleUrls: ['./ticker-basic-info.component.scss']
})
export class TickerBasicInfoComponent implements OnInit {

  @Input() ticker: Ticker;

  @Output()
  tickerRemoved: EventEmitter<Ticker[]> = new EventEmitter<Ticker[]>();


  constructor(private httpService: HttpService) { }

  ngOnInit(): void {
  }

  removeTicker() {    
    const tickers: Tickers = {
      names: [this.ticker.symbol]
    }

    this.httpService.removeTicker("vaner",tickers).subscribe({
      next: data => {
        this.tickerRemoved.emit(data);
      },
      error: error => {
        console.log("Error ocurred while adding ticker: " + error);
      }
    });
  }

}
