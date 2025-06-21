import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalHomePageComponent } from './car-rental-home-page.component';

describe('CarRentalHomePageComponent', () => {
  let component: CarRentalHomePageComponent;
  let fixture: ComponentFixture<CarRentalHomePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarRentalHomePageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CarRentalHomePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
