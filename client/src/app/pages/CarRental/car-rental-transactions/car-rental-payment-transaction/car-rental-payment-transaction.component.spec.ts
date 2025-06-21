import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalPaymentTransactionComponent } from './car-rental-payment-transaction.component';

describe('CarRentalPaymentTransactionComponent', () => {
  let component: CarRentalPaymentTransactionComponent;
  let fixture: ComponentFixture<CarRentalPaymentTransactionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarRentalPaymentTransactionComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CarRentalPaymentTransactionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
