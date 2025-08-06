import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelCheckout } from './hotel-checkout';

describe('HotelCheckout', () => {
  let component: HotelCheckout;
  let fixture: ComponentFixture<HotelCheckout>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HotelCheckout]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HotelCheckout);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
