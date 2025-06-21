import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelCheckinComponent } from './hotel-checkin.component';

describe('HotelCheckinComponent', () => {
  let component: HotelCheckinComponent;
  let fixture: ComponentFixture<HotelCheckinComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HotelCheckinComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HotelCheckinComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
