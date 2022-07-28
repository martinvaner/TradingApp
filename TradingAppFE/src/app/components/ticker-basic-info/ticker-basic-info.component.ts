import { Component, Input, OnInit } from '@angular/core';
import { Ticker } from 'src/app/interfaces/Ticker';

@Component({
  selector: 'app-ticker-basic-info',
  templateUrl: './ticker-basic-info.component.html',
  styleUrls: ['./ticker-basic-info.component.scss']
})
export class TickerBasicInfoComponent implements OnInit {

  @Input() ticker: Ticker;


  constructor() { }

  ngOnInit(): void {
  }

}
