import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalAdminComponent } from './car-rental-admin.component';

describe('CarRentalAdminComponent', () => {
  let component: CarRentalAdminComponent;
  let fixture: ComponentFixture<CarRentalAdminComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarRentalAdminComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CarRentalAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
