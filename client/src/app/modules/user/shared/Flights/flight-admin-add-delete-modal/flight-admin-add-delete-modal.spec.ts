import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightAdminAddDeleteModal } from './flight-admin-add-delete-modal';

describe('FlightAdminAddDeleteModal', () => {
  let component: FlightAdminAddDeleteModal;
  let fixture: ComponentFixture<FlightAdminAddDeleteModal>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FlightAdminAddDeleteModal]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FlightAdminAddDeleteModal);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
