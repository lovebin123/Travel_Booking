import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRemtalAddUpdateModal } from './car-remtal-add-update-modal';

describe('CarRemtalAddUpdateModal', () => {
  let component: CarRemtalAddUpdateModal;
  let fixture: ComponentFixture<CarRemtalAddUpdateModal>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CarRemtalAddUpdateModal]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarRemtalAddUpdateModal);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
