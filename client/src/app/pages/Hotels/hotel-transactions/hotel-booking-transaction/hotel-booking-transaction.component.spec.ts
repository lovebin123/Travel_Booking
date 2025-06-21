import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelBookingTransactionComponent } from './hotel-booking-transaction.component';

describe('HotelBookingTransactionComponent', () => {
  let component: HotelBookingTransactionComponent;
  let fixture: ComponentFixture<HotelBookingTransactionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HotelBookingTransactionComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HotelBookingTransactionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
