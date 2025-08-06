import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalDetails } from './car-rental-details';

describe('CarRentalDetails', () => {
  let component: CarRentalDetails;
  let fixture: ComponentFixture<CarRentalDetails>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CarRentalDetails]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarRentalDetails);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
