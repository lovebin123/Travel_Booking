import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelServiceList } from './hotel-service-list';

describe('HotelServiceList', () => {
  let component: HotelServiceList;
  let fixture: ComponentFixture<HotelServiceList>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HotelServiceList]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HotelServiceList);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
