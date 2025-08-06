import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalPickUpTime } from './car-rental-pick-up-time';

describe('CarRentalPickUpTime', () => {
  let component: CarRentalPickUpTime;
  let fixture: ComponentFixture<CarRentalPickUpTime>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CarRentalPickUpTime]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarRentalPickUpTime);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
