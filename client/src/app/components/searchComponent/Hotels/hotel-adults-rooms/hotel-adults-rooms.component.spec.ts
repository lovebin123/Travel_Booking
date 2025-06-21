import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelAdultsRoomsComponent } from './hotel-adults-rooms.component';

describe('HotelAdultsRoomsComponent', () => {
  let component: HotelAdultsRoomsComponent;
  let fixture: ComponentFixture<HotelAdultsRoomsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HotelAdultsRoomsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HotelAdultsRoomsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
