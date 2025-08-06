import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransactionTabs } from './transaction-tabs';

describe('TransactionTabs', () => {
  let component: TransactionTabs;
  let fixture: ComponentFixture<TransactionTabs>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TransactionTabs]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TransactionTabs);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
