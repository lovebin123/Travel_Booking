import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightTicketPayment } from './flight-ticket-payment';

describe('FlightTicketPayment', () => {
  let component: FlightTicketPayment;
  let fixture: ComponentFixture<FlightTicketPayment>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FlightTicketPayment]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FlightTicketPayment);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
