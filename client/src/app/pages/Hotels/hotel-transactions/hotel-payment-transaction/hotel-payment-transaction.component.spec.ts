import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelPaymentTransactionComponent } from './hotel-payment-transaction.component';

describe('HotelPaymentTransactionComponent', () => {
  let component: HotelPaymentTransactionComponent;
  let fixture: ComponentFixture<HotelPaymentTransactionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HotelPaymentTransactionComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HotelPaymentTransactionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
