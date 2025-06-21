import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalPickupDateComponent } from './car-rental-pickup-date.component';

describe('CarRentalPickupDateComponent', () => {
  let component: CarRentalPickupDateComponent;
  let fixture: ComponentFixture<CarRentalPickupDateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarRentalPickupDateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CarRentalPickupDateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
