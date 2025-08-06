import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightUser } from './flight-user';

describe('FlightUser', () => {
  let component: FlightUser;
  let fixture: ComponentFixture<FlightUser>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FlightUser]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FlightUser);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
