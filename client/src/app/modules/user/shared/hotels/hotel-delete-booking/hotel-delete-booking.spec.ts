import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelDeleteBooking } from './hotel-delete-booking';

describe('HotelDeleteBooking', () => {
  let component: HotelDeleteBooking;
  let fixture: ComponentFixture<HotelDeleteBooking>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HotelDeleteBooking]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HotelDeleteBooking);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
