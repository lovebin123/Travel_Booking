import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalDropoffTimeComponent } from './car-rental-dropoff-time.component';

describe('CarRentalDropoffTimeComponent', () => {
  let component: CarRentalDropoffTimeComponent;
  let fixture: ComponentFixture<CarRentalDropoffTimeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarRentalDropoffTimeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CarRentalDropoffTimeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
