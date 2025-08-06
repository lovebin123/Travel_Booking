import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightHome } from './flight-home';

describe('FlightHome', () => {
  let component: FlightHome;
  let fixture: ComponentFixture<FlightHome>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FlightHome]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FlightHome);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
