import { TestBed } from '@angular/core/testing';

import { PracticeAreasService } from './practice-areas.service';

describe('PracticeAreasService', () => {
  let service: PracticeAreasService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PracticeAreasService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
