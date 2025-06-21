import { TestBed } from '@angular/core/testing';

import { FlightPaymentService } from './flight-payment.service';

describe('FlightPaymentService', () => {
  let service: FlightPaymentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FlightPaymentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
