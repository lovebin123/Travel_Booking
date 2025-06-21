import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightTicketPaymentComponent } from './flight-ticket-payment.component';

describe('FlightTicketPaymentComponent', () => {
  let component: FlightTicketPaymentComponent;
  let fixture: ComponentFixture<FlightTicketPaymentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FlightTicketPaymentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FlightTicketPaymentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
