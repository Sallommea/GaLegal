import { TestBed } from '@angular/core/testing';

import { ConsultationRequestsService } from './consultation-requests.service';

describe('ConsultationRequestsService', () => {
  let service: ConsultationRequestsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ConsultationRequestsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
