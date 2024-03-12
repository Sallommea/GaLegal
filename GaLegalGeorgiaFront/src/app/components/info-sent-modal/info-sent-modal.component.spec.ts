import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InfoSentModalComponent } from './info-sent-modal.component';

describe('InfoSentModalComponent', () => {
  let component: InfoSentModalComponent;
  let fixture: ComponentFixture<InfoSentModalComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [InfoSentModalComponent]
    });
    fixture = TestBed.createComponent(InfoSentModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
