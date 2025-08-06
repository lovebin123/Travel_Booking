import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalPickUpDate } from './car-rental-pick-up-date';

describe('CarRentalPickUpDate', () => {
  let component: CarRentalPickUpDate;
  let fixture: ComponentFixture<CarRentalPickUpDate>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CarRentalPickUpDate]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarRentalPickUpDate);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
