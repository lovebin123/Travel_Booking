import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalDropOffTime } from './car-rental-drop-off-time';

describe('CarRentalDropOffTime', () => {
  let component: CarRentalDropOffTime;
  let fixture: ComponentFixture<CarRentalDropOffTime>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CarRentalDropOffTime]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarRentalDropOffTime);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
