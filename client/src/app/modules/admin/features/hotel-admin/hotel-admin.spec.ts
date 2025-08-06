import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelAdmin } from './hotel-admin';

describe('HotelAdmin', () => {
  let component: HotelAdmin;
  let fixture: ComponentFixture<HotelAdmin>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HotelAdmin]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HotelAdmin);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
