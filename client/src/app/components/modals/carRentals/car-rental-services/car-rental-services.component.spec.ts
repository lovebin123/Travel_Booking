import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalServicesComponent } from './car-rental-services.component';

describe('CarRentalServicesComponent', () => {
  let component: CarRentalServicesComponent;
  let fixture: ComponentFixture<CarRentalServicesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarRentalServicesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CarRentalServicesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
