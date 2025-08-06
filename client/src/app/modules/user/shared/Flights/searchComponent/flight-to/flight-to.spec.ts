import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightTo } from './flight-to';

describe('FlightTo', () => {
  let component: FlightTo;
  let fixture: ComponentFixture<FlightTo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FlightTo]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FlightTo);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
