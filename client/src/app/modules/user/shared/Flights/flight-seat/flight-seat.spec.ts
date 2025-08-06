import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightSeat } from './flight-seat';

describe('FlightSeat', () => {
  let component: FlightSeat;
  let fixture: ComponentFixture<FlightSeat>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FlightSeat]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FlightSeat);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
