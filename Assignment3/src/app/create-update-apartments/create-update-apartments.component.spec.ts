import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateUpdateApartmentsComponent } from './create-update-apartments.component';

describe('CreateUpdateApartmentsComponent', () => {
  let component: CreateUpdateApartmentsComponent;
  let fixture: ComponentFixture<CreateUpdateApartmentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateUpdateApartmentsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateUpdateApartmentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
