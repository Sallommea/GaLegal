import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PracticeAresTableComponent } from './practice-ares-table.component';

describe('PracticeAresTableComponent', () => {
  let component: PracticeAresTableComponent;
  let fixture: ComponentFixture<PracticeAresTableComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PracticeAresTableComponent]
    });
    fixture = TestBed.createComponent(PracticeAresTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
