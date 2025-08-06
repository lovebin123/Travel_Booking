import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalList } from './car-rental-list';

describe('CarRentalList', () => {
  let component: CarRentalList;
  let fixture: ComponentFixture<CarRentalList>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CarRentalList]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarRentalList);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
