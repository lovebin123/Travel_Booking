import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalDropoffDateComponent } from './car-rental-dropoff-date.component';

describe('CarRentalDropoffDateComponent', () => {
  let component: CarRentalDropoffDateComponent;
  let fixture: ComponentFixture<CarRentalDropoffDateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarRentalDropoffDateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CarRentalDropoffDateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
