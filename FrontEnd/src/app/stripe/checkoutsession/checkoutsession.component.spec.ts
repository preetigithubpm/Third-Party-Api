import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CheckoutsessionComponent } from './checkoutsession.component';

describe('CheckoutsessionComponent', () => {
  let component: CheckoutsessionComponent;
  let fixture: ComponentFixture<CheckoutsessionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CheckoutsessionComponent]
    });
    fixture = TestBed.createComponent(CheckoutsessionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
