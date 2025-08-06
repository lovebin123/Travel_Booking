import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelTicketDetails } from './hotel-ticket-details';

describe('HotelTicketDetails', () => {
  let component: HotelTicketDetails;
  let fixture: ComponentFixture<HotelTicketDetails>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HotelTicketDetails]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HotelTicketDetails);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
