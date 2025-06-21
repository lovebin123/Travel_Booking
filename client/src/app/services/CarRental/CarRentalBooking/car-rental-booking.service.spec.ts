import { TestBed } from '@angular/core/testing';

import { CarRentalBookingService } from './car-rental-booking.service';

describe('CarRentalBookingService', () => {
  let service: CarRentalBookingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CarRentalBookingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
