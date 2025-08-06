import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalServiceList } from './car-rental-service-list';

describe('CarRentalServiceList', () => {
  let component: CarRentalServiceList;
  let fixture: ComponentFixture<CarRentalServiceList>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CarRentalServiceList]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarRentalServiceList);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
