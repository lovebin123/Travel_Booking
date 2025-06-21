import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightPaymentTransactionComponent } from './flight-payment-transaction.component';

describe('FlightPaymentTransactionComponent', () => {
  let component: FlightPaymentTransactionComponent;
  let fixture: ComponentFixture<FlightPaymentTransactionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FlightPaymentTransactionComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FlightPaymentTransactionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
