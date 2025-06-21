import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalSearchComponent } from './car-rental-search.component';

describe('CarRentalSearchComponent', () => {
  let component: CarRentalSearchComponent;
  let fixture: ComponentFixture<CarRentalSearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarRentalSearchComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CarRentalSearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
