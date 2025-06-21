import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightDestinationDateComponent } from './flight-destination-date.component';

describe('FlightDestinationDateComponent', () => {
  let component: FlightDestinationDateComponent;
  let fixture: ComponentFixture<FlightDestinationDateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FlightDestinationDateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FlightDestinationDateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
