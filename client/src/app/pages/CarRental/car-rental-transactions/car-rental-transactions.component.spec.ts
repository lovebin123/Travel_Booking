import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalTransactionsComponent } from './car-rental-transactions.component';

describe('CarRentalTransactionsComponent', () => {
  let component: CarRentalTransactionsComponent;
  let fixture: ComponentFixture<CarRentalTransactionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarRentalTransactionsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CarRentalTransactionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
