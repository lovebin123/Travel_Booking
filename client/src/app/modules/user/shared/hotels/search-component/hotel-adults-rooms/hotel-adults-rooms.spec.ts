import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelAdultsRooms } from './hotel-adults-rooms';

describe('HotelAdultsRooms', () => {
  let component: HotelAdultsRooms;
  let fixture: ComponentFixture<HotelAdultsRooms>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HotelAdultsRooms]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HotelAdultsRooms);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
