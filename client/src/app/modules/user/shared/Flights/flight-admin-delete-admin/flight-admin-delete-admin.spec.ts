import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightAdminDeleteAdmin } from './flight-admin-delete-admin';

describe('FlightAdminDeleteAdmin', () => {
  let component: FlightAdminDeleteAdmin;
  let fixture: ComponentFixture<FlightAdminDeleteAdmin>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FlightAdminDeleteAdmin]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FlightAdminDeleteAdmin);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
