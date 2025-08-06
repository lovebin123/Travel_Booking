import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalDropOffDate } from './car-rental-drop-off-date';

describe('CarRentalDropOffDate', () => {
  let component: CarRentalDropOffDate;
  let fixture: ComponentFixture<CarRentalDropOffDate>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CarRentalDropOffDate]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarRentalDropOffDate);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
