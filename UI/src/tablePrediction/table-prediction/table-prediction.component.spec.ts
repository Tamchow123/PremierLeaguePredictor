import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TablePredictionComponent } from './table-prediction.component';

describe('TablePredictionComponent', () => {
  let component: TablePredictionComponent;
  let fixture: ComponentFixture<TablePredictionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TablePredictionComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TablePredictionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
