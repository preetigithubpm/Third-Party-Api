import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NestedDropdownComponent } from './nested-dropdown.component';

describe('NestedDropdownComponent', () => {
  let component: NestedDropdownComponent;
  let fixture: ComponentFixture<NestedDropdownComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NestedDropdownComponent]
    });
    fixture = TestBed.createComponent(NestedDropdownComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
