import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalLocationComponent } from './car-rental-location.component';

describe('CarRentalLocationComponent', () => {
  let component: CarRentalLocationComponent;
  let fixture: ComponentFixture<CarRentalLocationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarRentalLocationComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CarRentalLocationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
