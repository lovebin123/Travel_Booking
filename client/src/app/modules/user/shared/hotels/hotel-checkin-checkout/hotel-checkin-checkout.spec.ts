import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelCheckinCheckout } from './hotel-checkin-checkout';

describe('HotelCheckinCheckout', () => {
  let component: HotelCheckinCheckout;
  let fixture: ComponentFixture<HotelCheckinCheckout>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HotelCheckinCheckout]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HotelCheckinCheckout);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
