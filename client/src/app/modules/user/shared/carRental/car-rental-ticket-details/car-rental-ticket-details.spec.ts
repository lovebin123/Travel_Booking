import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalTicketDetails } from './car-rental-ticket-details';

describe('CarRentalTicketDetails', () => {
  let component: CarRentalTicketDetails;
  let fixture: ComponentFixture<CarRentalTicketDetails>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CarRentalTicketDetails]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarRentalTicketDetails);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
