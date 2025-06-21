import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightDeleteAdminComponent } from './flight-delete-admin.component';

describe('FlightDeleteAdminComponent', () => {
  let component: FlightDeleteAdminComponent;
  let fixture: ComponentFixture<FlightDeleteAdminComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FlightDeleteAdminComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FlightDeleteAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
