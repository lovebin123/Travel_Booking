import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalServices } from './car-rental-services';

describe('CarRentalServices', () => {
  let component: CarRentalServices;
  let fixture: ComponentFixture<CarRentalServices>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CarRentalServices]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarRentalServices);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
