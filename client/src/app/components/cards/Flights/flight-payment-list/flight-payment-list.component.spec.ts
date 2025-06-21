import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FlightPaymentListComponent } from './flight-payment-list.component';

describe('FlightPaymentListComponent', () => {
  let component: FlightPaymentListComponent;
  let fixture: ComponentFixture<FlightPaymentListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FlightPaymentListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FlightPaymentListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
