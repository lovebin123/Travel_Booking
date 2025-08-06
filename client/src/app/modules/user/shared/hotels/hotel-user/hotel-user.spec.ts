import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelUser } from './hotel-user';

describe('HotelUser', () => {
  let component: HotelUser;
  let fixture: ComponentFixture<HotelUser>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HotelUser]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HotelUser);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
