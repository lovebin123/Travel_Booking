import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalTicket } from './car-rental-ticket';

describe('CarRentalTicket', () => {
  let component: CarRentalTicket;
  let fixture: ComponentFixture<CarRentalTicket>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CarRentalTicket]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarRentalTicket);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
