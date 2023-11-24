import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetbyPateintImageComponent } from './getby-pateint-image.component';

describe('GetbyPateintImageComponent', () => {
  let component: GetbyPateintImageComponent;
  let fixture: ComponentFixture<GetbyPateintImageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GetbyPateintImageComponent]
    });
    fixture = TestBed.createComponent(GetbyPateintImageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
