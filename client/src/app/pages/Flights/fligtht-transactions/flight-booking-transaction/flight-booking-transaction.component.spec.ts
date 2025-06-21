import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightBookingTransactionComponent } from './flight-booking-transaction.component';

describe('FlightBookingTransactionComponent', () => {
  let component: FlightBookingTransactionComponent;
  let fixture: ComponentFixture<FlightBookingTransactionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FlightBookingTransactionComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FlightBookingTransactionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
