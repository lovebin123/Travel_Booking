import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalPickupTimeComponent } from './car-rental-pickup-time.component';

describe('CarRentalPickupTimeComponent', () => {
  let component: CarRentalPickupTimeComponent;
  let fixture: ComponentFixture<CarRentalPickupTimeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarRentalPickupTimeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CarRentalPickupTimeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
