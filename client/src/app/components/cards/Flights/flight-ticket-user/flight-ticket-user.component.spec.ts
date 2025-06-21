import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightTicketUserComponent } from './flight-ticket-user.component';

describe('FlightTicketUserComponent', () => {
  let component: FlightTicketUserComponent;
  let fixture: ComponentFixture<FlightTicketUserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FlightTicketUserComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FlightTicketUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
