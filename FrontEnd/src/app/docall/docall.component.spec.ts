import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DocallComponent } from './docall.component';

describe('DocallComponent', () => {
  let component: DocallComponent;
  let fixture: ComponentFixture<DocallComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DocallComponent]
    });
    fixture = TestBed.createComponent(DocallComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
