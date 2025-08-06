import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalUser } from './car-rental-user';

describe('CarRentalUser', () => {
  let component: CarRentalUser;
  let fixture: ComponentFixture<CarRentalUser>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CarRentalUser]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarRentalUser);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
