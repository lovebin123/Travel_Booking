import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelAdminDeleteModal } from './hotel-admin-delete-modal';

describe('HotelAdminDeleteModal', () => {
  let component: HotelAdminDeleteModal;
  let fixture: ComponentFixture<HotelAdminDeleteModal>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HotelAdminDeleteModal]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HotelAdminDeleteModal);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
