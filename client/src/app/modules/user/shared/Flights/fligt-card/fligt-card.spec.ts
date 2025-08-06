import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FligtCard } from './fligt-card';

describe('FligtCard', () => {
  let component: FligtCard;
  let fixture: ComponentFixture<FligtCard>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FligtCard]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FligtCard);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
