import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightFromComponent } from './flight-from.component';

describe('FlightFromComponent', () => {
  let component: FlightFromComponent;
  let fixture: ComponentFixture<FlightFromComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FlightFromComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FlightFromComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
