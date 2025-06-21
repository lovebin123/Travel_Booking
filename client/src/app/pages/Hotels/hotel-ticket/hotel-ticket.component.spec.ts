import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelTicketComponent } from './hotel-ticket.component';

describe('HotelTicketComponent', () => {
  let component: HotelTicketComponent;
  let fixture: ComponentFixture<HotelTicketComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HotelTicketComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HotelTicketComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
