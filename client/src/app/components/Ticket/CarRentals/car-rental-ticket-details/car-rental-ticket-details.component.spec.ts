import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalTicketDetailsComponent } from './car-rental-ticket-details.component';

describe('CarRentalTicketDetailsComponent', () => {
  let component: CarRentalTicketDetailsComponent;
  let fixture: ComponentFixture<CarRentalTicketDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarRentalTicketDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CarRentalTicketDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
