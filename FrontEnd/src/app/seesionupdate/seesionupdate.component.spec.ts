import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SeesionupdateComponent } from './seesionupdate.component';

describe('SeesionupdateComponent', () => {
  let component: SeesionupdateComponent;
  let fixture: ComponentFixture<SeesionupdateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SeesionupdateComponent]
    });
    fixture = TestBed.createComponent(SeesionupdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
