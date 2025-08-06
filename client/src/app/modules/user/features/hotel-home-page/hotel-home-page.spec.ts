import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelHomePage } from './hotel-home-page';

describe('HotelHomePage', () => {
  let component: HotelHomePage;
  let fixture: ComponentFixture<HotelHomePage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HotelHomePage]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HotelHomePage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
