/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PolicyService } from './policy.service';

describe('Service: Policy', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PolicyService]
    });
  });

  it('should ...', inject([PolicyService], (service: PolicyService) => {
    expect(service).toBeTruthy();
  }));
});
