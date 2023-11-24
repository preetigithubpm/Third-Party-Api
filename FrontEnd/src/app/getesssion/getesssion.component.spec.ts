import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetesssionComponent } from './getesssion.component';

describe('GetesssionComponent', () => {
  let component: GetesssionComponent;
  let fixture: ComponentFixture<GetesssionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GetesssionComponent]
    });
    fixture = TestBed.createComponent(GetesssionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
