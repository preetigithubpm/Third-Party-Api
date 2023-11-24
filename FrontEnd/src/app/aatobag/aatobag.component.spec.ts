import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AatobagComponent } from './aatobag.component';

describe('AatobagComponent', () => {
  let component: AatobagComponent;
  let fixture: ComponentFixture<AatobagComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AatobagComponent]
    });
    fixture = TestBed.createComponent(AatobagComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
