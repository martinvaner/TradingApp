import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Ticker } from 'src/app/interfaces/Ticker';
import { Tickers } from 'src/app/interfaces/Tickers';
import { HttpService } from 'src/app/services/HttpService';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  tickers: Ticker[];
  addProcess = '';

  addForm = this.formBuilder.group({
    tickerName: '',
  });

  constructor(private httpService: HttpService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {    
    this.addProcess = 'ready';

    this.httpService.getUserData("vaner").subscribe({
      next: data => {
        console.log(data);
        this.tickers = data.sort( (a,b) => a.symbol.localeCompare(b.symbol) );
      },
      error: error => {
        console.log("Error ocurred while getting data: " + error);
      }
    })
  }

  onAddTicker() {
    const tickers: Tickers = {
      names: [this.addForm.value.tickerName]
    }

    this.addProcess = 'processing';

    this.httpService.postTicker("vaner", tickers).subscribe({
      next: data => {
        this.tickers = data.sort( (a,b) => a.symbol.localeCompare(b.symbol) );
        this.addProcess = 'ready';
      },
      error: error => {
        console.log("Error ocurred while adding ticker: " + error);
        this.addProcess = 'ready';
      }
    });
  }

  onTickerRemoved(newTickers: Ticker[]) {
    this.tickers = newTickers.sort( (a,b) => a.symbol.localeCompare(b.symbol) );
  }

}
