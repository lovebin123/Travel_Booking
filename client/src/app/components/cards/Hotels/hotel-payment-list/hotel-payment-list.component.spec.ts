import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelPaymentListComponent } from './hotel-payment-list.component';

describe('HotelPaymentListComponent', () => {
  let component: HotelPaymentListComponent;
  let fixture: ComponentFixture<HotelPaymentListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HotelPaymentListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HotelPaymentListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
