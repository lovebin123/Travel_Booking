import { TestBed } from '@angular/core/testing';

import { HotelPaymentService } from './hotel-payment.service';

describe('HotelPaymentService', () => {
  let service: HotelPaymentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HotelPaymentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
