import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalTransactions } from './car-rental-transactions';

describe('CarRentalTransactions', () => {
  let component: CarRentalTransactions;
  let fixture: ComponentFixture<CarRentalTransactions>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CarRentalTransactions]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarRentalTransactions);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
