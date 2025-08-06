import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelAdminAddUpdateModal } from './hotel-admin-add-update-modal';

describe('HotelAdminAddUpdateModal', () => {
  let component: HotelAdminAddUpdateModal;
  let fixture: ComponentFixture<HotelAdminAddUpdateModal>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HotelAdminAddUpdateModal]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HotelAdminAddUpdateModal);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
