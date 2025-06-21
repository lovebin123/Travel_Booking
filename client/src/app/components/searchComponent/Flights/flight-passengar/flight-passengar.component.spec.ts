import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightPassengarComponent } from './flight-passengar.component';

describe('FlightPassengarComponent', () => {
  let component: FlightPassengarComponent;
  let fixture: ComponentFixture<FlightPassengarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FlightPassengarComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FlightPassengarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
