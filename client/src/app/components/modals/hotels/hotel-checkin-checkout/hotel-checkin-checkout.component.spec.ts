import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelCheckinCheckoutComponent } from './hotel-checkin-checkout.component';

describe('HotelCheckinCheckoutComponent', () => {
  let component: HotelCheckinCheckoutComponent;
  let fixture: ComponentFixture<HotelCheckinCheckoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HotelCheckinCheckoutComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HotelCheckinCheckoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
