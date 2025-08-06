import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FligthtTransactions } from './fligtht-transactions';

describe('FligthtTransactions', () => {
  let component: FligthtTransactions;
  let fixture: ComponentFixture<FligthtTransactions>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FligthtTransactions]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FligthtTransactions);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
