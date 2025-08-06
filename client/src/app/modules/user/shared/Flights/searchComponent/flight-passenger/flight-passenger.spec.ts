import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightPassenger } from './flight-passenger';

describe('FlightPassenger', () => {
  let component: FlightPassenger;
  let fixture: ComponentFixture<FlightPassenger>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FlightPassenger]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FlightPassenger);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
