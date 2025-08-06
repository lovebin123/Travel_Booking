import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightFrom } from './flight-from';

describe('FlightFrom', () => {
  let component: FlightFrom;
  let fixture: ComponentFixture<FlightFrom>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FlightFrom]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FlightFrom);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
