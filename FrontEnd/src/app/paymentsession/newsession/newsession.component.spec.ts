import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewsessionComponent } from './newsession.component';

describe('NewsessionComponent', () => {
  let component: NewsessionComponent;
  let fixture: ComponentFixture<NewsessionComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NewsessionComponent]
    });
    fixture = TestBed.createComponent(NewsessionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
