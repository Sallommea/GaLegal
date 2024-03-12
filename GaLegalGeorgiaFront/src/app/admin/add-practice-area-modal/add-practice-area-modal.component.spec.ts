import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPracticeAreaModalComponent } from './add-practice-area-modal.component';

describe('AddPracticeAreaModalComponent', () => {
  let component: AddPracticeAreaModalComponent;
  let fixture: ComponentFixture<AddPracticeAreaModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddPracticeAreaModalComponent]
    });
    fixture = TestBed.createComponent(AddPracticeAreaModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
