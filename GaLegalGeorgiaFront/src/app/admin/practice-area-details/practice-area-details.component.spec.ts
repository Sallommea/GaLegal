import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PracticeAreaDetailsComponent } from './practice-area-details.component';

describe('PracticeAreaDetailsComponent', () => {
  let component: PracticeAreaDetailsComponent;
  let fixture: ComponentFixture<PracticeAreaDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PracticeAreaDetailsComponent]
    });
    fixture = TestBed.createComponent(PracticeAreaDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
