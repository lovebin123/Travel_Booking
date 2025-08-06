import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightBookingTransactions } from './flight-booking-transactions';

describe('FlightBookingTransactions', () => {
  let component: FlightBookingTransactions;
  let fixture: ComponentFixture<FlightBookingTransactions>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FlightBookingTransactions]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FlightBookingTransactions);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
