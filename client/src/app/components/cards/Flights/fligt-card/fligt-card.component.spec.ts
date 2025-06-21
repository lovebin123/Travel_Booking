import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FligtCardComponent } from './fligt-card.component';

describe('FligtCardComponent', () => {
  let component: FligtCardComponent;
  let fixture: ComponentFixture<FligtCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FligtCardComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FligtCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
