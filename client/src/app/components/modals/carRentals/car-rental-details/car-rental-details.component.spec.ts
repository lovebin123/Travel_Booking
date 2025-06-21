import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalDetailsComponent } from './car-rental-details.component';

describe('CarRentalDetailsComponent', () => {
  let component: CarRentalDetailsComponent;
  let fixture: ComponentFixture<CarRentalDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarRentalDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CarRentalDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
