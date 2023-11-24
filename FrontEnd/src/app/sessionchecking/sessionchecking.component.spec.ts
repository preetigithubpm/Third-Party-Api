import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SessioncheckingComponent } from './sessionchecking.component';

describe('SessioncheckingComponent', () => {
  let component: SessioncheckingComponent;
  let fixture: ComponentFixture<SessioncheckingComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SessioncheckingComponent]
    });
    fixture = TestBed.createComponent(SessioncheckingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
