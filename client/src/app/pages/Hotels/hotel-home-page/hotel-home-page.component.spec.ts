import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelHomePageComponent } from './hotel-home-page.component';

describe('HotelHomePageComponent', () => {
  let component: HotelHomePageComponent;
  let fixture: ComponentFixture<HotelHomePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HotelHomePageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HotelHomePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
