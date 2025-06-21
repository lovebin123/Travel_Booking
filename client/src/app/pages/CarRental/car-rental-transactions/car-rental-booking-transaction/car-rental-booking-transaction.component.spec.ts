import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalBookingTransactionComponent } from './car-rental-booking-transaction.component';

describe('CarRentalBookingTransactionComponent', () => {
  let component: CarRentalBookingTransactionComponent;
  let fixture: ComponentFixture<CarRentalBookingTransactionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarRentalBookingTransactionComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CarRentalBookingTransactionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
