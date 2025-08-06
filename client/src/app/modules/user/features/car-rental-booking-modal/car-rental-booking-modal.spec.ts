import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalBookingModal } from './car-rental-booking-modal';

describe('CarRentalBookingModal', () => {
  let component: CarRentalBookingModal;
  let fixture: ComponentFixture<CarRentalBookingModal>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CarRentalBookingModal]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarRentalBookingModal);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
