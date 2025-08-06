import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminTabs } from './admin-tabs';

describe('AdminTabs', () => {
  let component: AdminTabs;
  let fixture: ComponentFixture<AdminTabs>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdminTabs]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdminTabs);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
