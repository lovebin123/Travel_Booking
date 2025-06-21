import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRentalPayemntListComponent } from './car-rental-payemnt-list.component';

describe('CarRentalPayemntListComponent', () => {
  let component: CarRentalPayemntListComponent;
  let fixture: ComponentFixture<CarRentalPayemntListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarRentalPayemntListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CarRentalPayemntListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
