import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightToComponent } from './flight-to.component';

describe('FlightToComponent', () => {
  let component: FlightToComponent;
  let fixture: ComponentFixture<FlightToComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FlightToComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FlightToComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
