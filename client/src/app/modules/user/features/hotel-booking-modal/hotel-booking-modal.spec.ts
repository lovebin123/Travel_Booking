import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelBookingModal } from './hotel-booking-modal';

describe('HotelBookingModal', () => {
  let component: HotelBookingModal;
  let fixture: ComponentFixture<HotelBookingModal>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HotelBookingModal]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HotelBookingModal);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
