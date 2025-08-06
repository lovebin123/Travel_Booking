import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalPickUpLocation } from './car-rental-pick-up-location';

describe('CarRentalPickUpLocation', () => {
  let component: CarRentalPickUpLocation;
  let fixture: ComponentFixture<CarRentalPickUpLocation>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CarRentalPickUpLocation]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarRentalPickUpLocation);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
