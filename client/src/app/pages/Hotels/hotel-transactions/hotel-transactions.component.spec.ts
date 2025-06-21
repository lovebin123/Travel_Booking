import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HotelTransactionsComponent } from './hotel-transactions.component';

describe('HotelTransactionsComponent', () => {
  let component: HotelTransactionsComponent;
  let fixture: ComponentFixture<HotelTransactionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HotelTransactionsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HotelTransactionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
