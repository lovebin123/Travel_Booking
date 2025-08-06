import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalAdminDelete } from './car-rental-admin-delete';

describe('CarRentalAdminDelete', () => {
  let component: CarRentalAdminDelete;
  let fixture: ComponentFixture<CarRentalAdminDelete>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CarRentalAdminDelete]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarRentalAdminDelete);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
