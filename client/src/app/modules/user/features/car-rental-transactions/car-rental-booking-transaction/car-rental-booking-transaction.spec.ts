import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalBookingTransaction } from './car-rental-booking-transaction';

describe('CarRentalBookingTransaction', () => {
  let component: CarRentalBookingTransaction;
  let fixture: ComponentFixture<CarRentalBookingTransaction>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CarRentalBookingTransaction]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarRentalBookingTransaction);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
