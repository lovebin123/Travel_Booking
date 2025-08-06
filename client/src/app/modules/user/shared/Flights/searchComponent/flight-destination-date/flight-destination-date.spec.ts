import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightDestinationDate } from './flight-destination-date';

describe('FlightDestinationDate', () => {
  let component: FlightDestinationDate;
  let fixture: ComponentFixture<FlightDestinationDate>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FlightDestinationDate]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FlightDestinationDate);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
