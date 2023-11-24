import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetbyidiamgeComponent } from './getbyidiamge.component';

describe('GetbyidiamgeComponent', () => {
  let component: GetbyidiamgeComponent;
  let fixture: ComponentFixture<GetbyidiamgeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GetbyidiamgeComponent]
    });
    fixture = TestBed.createComponent(GetbyidiamgeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
