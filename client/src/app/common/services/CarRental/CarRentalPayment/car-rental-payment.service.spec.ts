import { TestBed } from '@angular/core/testing';

import { CarRentalPaymentService } from './car-rental-payment.service';

describe('CarRentalPaymentService', () => {
  let service: CarRentalPaymentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CarRentalPaymentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
