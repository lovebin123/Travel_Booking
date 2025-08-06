import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalPaymentDetails } from './car-rental-payment-details';

describe('CarRentalPaymentDetails', () => {
  let component: CarRentalPaymentDetails;
  let fixture: ComponentFixture<CarRentalPaymentDetails>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CarRentalPaymentDetails]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarRentalPaymentDetails);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
