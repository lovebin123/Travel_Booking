import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelAdminDeleteModalComponent } from './hotel-admin-delete-modal.component';

describe('HotelAdminDeleteModalComponent', () => {
  let component: HotelAdminDeleteModalComponent;
  let fixture: ComponentFixture<HotelAdminDeleteModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HotelAdminDeleteModalComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HotelAdminDeleteModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
