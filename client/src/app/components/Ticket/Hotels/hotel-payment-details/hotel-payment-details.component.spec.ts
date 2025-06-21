import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelPaymentDetailsComponent } from './hotel-payment-details.component';

describe('HotelPaymentDetailsComponent', () => {
  let component: HotelPaymentDetailsComponent;
  let fixture: ComponentFixture<HotelPaymentDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HotelPaymentDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HotelPaymentDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
