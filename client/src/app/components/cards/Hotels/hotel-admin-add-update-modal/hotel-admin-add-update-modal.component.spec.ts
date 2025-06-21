import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelAdminAddUpdateModalComponent } from './hotel-admin-add-update-modal.component';

describe('HotelAdminAddUpdateModalComponent', () => {
  let component: HotelAdminAddUpdateModalComponent;
  let fixture: ComponentFixture<HotelAdminAddUpdateModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HotelAdminAddUpdateModalComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HotelAdminAddUpdateModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
