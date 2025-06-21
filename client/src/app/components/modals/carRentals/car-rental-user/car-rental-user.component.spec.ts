import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalUserComponent } from './car-rental-user.component';

describe('CarRentalUserComponent', () => {
  let component: CarRentalUserComponent;
  let fixture: ComponentFixture<CarRentalUserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarRentalUserComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CarRentalUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
