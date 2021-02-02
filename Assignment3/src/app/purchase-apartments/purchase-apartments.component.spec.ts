import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PurchaseApartmentsComponent } from './purchase-apartments.component';

describe('PurchaseApartmentsComponent', () => {
  let component: PurchaseApartmentsComponent;
  let fixture: ComponentFixture<PurchaseApartmentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PurchaseApartmentsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaseApartmentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
