import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightTicketUser } from './flight-ticket-user';

describe('FlightTicketUser', () => {
  let component: FlightTicketUser;
  let fixture: ComponentFixture<FlightTicketUser>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FlightTicketUser]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FlightTicketUser);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
