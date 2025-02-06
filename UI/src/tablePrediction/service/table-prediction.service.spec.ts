import { TestBed } from '@angular/core/testing';

import { TablePredictionService } from './table-prediction.service';

describe('TablePredictionService', () => {
  let service: TablePredictionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TablePredictionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
