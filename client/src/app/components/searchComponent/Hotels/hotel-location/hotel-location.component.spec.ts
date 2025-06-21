import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelLocationComponent } from './hotel-location.component';

describe('HotelLocationComponent', () => {
  let component: HotelLocationComponent;
  let fixture: ComponentFixture<HotelLocationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HotelLocationComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HotelLocationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
