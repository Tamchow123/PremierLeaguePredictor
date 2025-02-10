import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FixturePredictionComponent } from './fixture-prediction.component';

describe('FixturePredictionComponent', () => {
  let component: FixturePredictionComponent;
  let fixture: ComponentFixture<FixturePredictionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FixturePredictionComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FixturePredictionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
