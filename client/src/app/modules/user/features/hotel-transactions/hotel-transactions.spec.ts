import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelTransactions } from './hotel-transactions';

describe('HotelTransactions', () => {
  let component: HotelTransactions;
  let fixture: ComponentFixture<HotelTransactions>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HotelTransactions]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HotelTransactions);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
