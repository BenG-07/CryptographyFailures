import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreditCardEntryComponent } from './credit-card-entry.component';

describe('CreditCardEntryComponent', () => {
  let component: CreditCardEntryComponent;
  let fixture: ComponentFixture<CreditCardEntryComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CreditCardEntryComponent]
    });
    fixture = TestBed.createComponent(CreditCardEntryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
