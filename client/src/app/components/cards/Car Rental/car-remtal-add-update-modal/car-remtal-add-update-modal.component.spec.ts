import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarRemtalAddUpdateModalComponent } from './car-remtal-add-update-modal.component';

describe('CarRemtalAddUpdateModalComponent', () => {
  let component: CarRemtalAddUpdateModalComponent;
  let fixture: ComponentFixture<CarRemtalAddUpdateModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarRemtalAddUpdateModalComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CarRemtalAddUpdateModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
