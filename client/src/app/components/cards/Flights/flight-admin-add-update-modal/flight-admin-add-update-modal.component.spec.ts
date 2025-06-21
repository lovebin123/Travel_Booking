import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightAdminAddUpdateModalComponent } from './flight-admin-add-update-modal.component';

describe('FlightAdminAddUpdateModalComponent', () => {
  let component: FlightAdminAddUpdateModalComponent;
  let fixture: ComponentFixture<FlightAdminAddUpdateModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FlightAdminAddUpdateModalComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FlightAdminAddUpdateModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
