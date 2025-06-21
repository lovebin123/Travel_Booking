import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalTicketPageComponent } from './car-rental-ticket-page.component';

describe('CarRentalTicketPageComponent', () => {
  let component: CarRentalTicketPageComponent;
  let fixture: ComponentFixture<CarRentalTicketPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarRentalTicketPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CarRentalTicketPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
