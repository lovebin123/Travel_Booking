import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalPaymentDetailsComponent } from './car-rental-payment-details.component';

describe('CarRentalPaymentDetailsComponent', () => {
  let component: CarRentalPaymentDetailsComponent;
  let fixture: ComponentFixture<CarRentalPaymentDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarRentalPaymentDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CarRentalPaymentDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
