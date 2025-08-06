import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelPaymentDetails } from './hotel-payment-details';

describe('HotelPaymentDetails', () => {
  let component: HotelPaymentDetails;
  let fixture: ComponentFixture<HotelPaymentDetails>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HotelPaymentDetails]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HotelPaymentDetails);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
