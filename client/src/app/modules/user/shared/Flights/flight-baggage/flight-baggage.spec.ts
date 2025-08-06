import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightBaggage } from './flight-baggage';

describe('FlightBaggage', () => {
  let component: FlightBaggage;
  let fixture: ComponentFixture<FlightBaggage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FlightBaggage]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FlightBaggage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
