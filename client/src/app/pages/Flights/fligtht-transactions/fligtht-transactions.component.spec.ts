import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FligthtTransactionsComponent } from './fligtht-transactions.component';

describe('FligthtTransactionsComponent', () => {
  let component: FligthtTransactionsComponent;
  let fixture: ComponentFixture<FligthtTransactionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FligthtTransactionsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FligthtTransactionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
