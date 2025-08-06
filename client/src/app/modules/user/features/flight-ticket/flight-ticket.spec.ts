import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightTicket } from './flight-ticket';

describe('FlightTicket', () => {
  let component: FlightTicket;
  let fixture: ComponentFixture<FlightTicket>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FlightTicket]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FlightTicket);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
