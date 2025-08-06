import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalAdmin } from './car-rental-admin';

describe('CarRentalAdmin', () => {
  let component: CarRentalAdmin;
  let fixture: ComponentFixture<CarRentalAdmin>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CarRentalAdmin]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarRentalAdmin);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
