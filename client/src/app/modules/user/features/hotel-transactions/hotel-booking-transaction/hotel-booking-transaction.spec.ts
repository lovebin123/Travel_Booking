import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelBookingTransaction } from './hotel-booking-transaction';

describe('HotelBookingTransaction', () => {
  let component: HotelBookingTransaction;
  let fixture: ComponentFixture<HotelBookingTransaction>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HotelBookingTransaction]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HotelBookingTransaction);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
