import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TickerBasicInfoComponent } from './ticker-basic-info.component';

describe('TickerBasicInfoComponent', () => {
  let component: TickerBasicInfoComponent;
  let fixture: ComponentFixture<TickerBasicInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TickerBasicInfoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TickerBasicInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
