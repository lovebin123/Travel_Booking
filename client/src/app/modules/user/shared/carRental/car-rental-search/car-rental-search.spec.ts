import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalSearch } from './car-rental-search';

describe('CarRentalSearch', () => {
  let component: CarRentalSearch;
  let fixture: ComponentFixture<CarRentalSearch>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CarRentalSearch]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarRentalSearch);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
