import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightBaggageComponent } from './flight-baggage.component';

describe('FlightBaggageComponent', () => {
  let component: FlightBaggageComponent;
  let fixture: ComponentFixture<FlightBaggageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FlightBaggageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FlightBaggageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
