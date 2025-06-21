import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalAdminDeleteComponent } from './car-rental-admin-delete.component';

describe('CarRentalAdminDeleteComponent', () => {
  let component: CarRentalAdminDeleteComponent;
  let fixture: ComponentFixture<CarRentalAdminDeleteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarRentalAdminDeleteComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CarRentalAdminDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
