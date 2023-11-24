import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PaylinkComponent } from './paylink.component';

describe('PaylinkComponent', () => {
  let component: PaylinkComponent;
  let fixture: ComponentFixture<PaylinkComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PaylinkComponent]
    });
    fixture = TestBed.createComponent(PaylinkComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
