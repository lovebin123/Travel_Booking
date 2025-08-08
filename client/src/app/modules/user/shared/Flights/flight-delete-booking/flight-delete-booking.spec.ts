import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightDeleteBooking } from './flight-delete-booking';

describe('FlightDeleteBooking', () => {
  let component: FlightDeleteBooking;
  let fixture: ComponentFixture<FlightDeleteBooking>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FlightDeleteBooking]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FlightDeleteBooking);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
