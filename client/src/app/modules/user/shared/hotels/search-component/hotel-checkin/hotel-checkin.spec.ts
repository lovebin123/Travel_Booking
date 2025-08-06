import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelCheckin } from './hotel-checkin';

describe('HotelCheckin', () => {
  let component: HotelCheckin;
  let fixture: ComponentFixture<HotelCheckin>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HotelCheckin]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HotelCheckin);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
