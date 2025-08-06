import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelTicket } from './hotel-ticket';

describe('HotelTicket', () => {
  let component: HotelTicket;
  let fixture: ComponentFixture<HotelTicket>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HotelTicket]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HotelTicket);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
