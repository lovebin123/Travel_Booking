import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalServiceListComponent } from './car-rental-service-list.component';

describe('CarRentalServiceListComponent', () => {
  let component: CarRentalServiceListComponent;
  let fixture: ComponentFixture<CarRentalServiceListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarRentalServiceListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CarRentalServiceListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
