import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalBookingModalComponent } from './car-rental-booking-modal.component';

describe('CarRentalBookingModalComponent', () => {
  let component: CarRentalBookingModalComponent;
  let fixture: ComponentFixture<CarRentalBookingModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarRentalBookingModalComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CarRentalBookingModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
