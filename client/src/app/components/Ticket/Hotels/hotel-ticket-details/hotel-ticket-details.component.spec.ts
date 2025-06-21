import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelTicketDetailsComponent } from './hotel-ticket-details.component';

describe('HotelTicketDetailsComponent', () => {
  let component: HotelTicketDetailsComponent;
  let fixture: ComponentFixture<HotelTicketDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HotelTicketDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HotelTicketDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
