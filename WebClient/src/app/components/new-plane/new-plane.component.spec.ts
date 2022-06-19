import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewPlaneComponent } from './new-plane.component';

describe('NewPlaneComponent', () => {
  let component: NewPlaneComponent;
  let fixture: ComponentFixture<NewPlaneComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewPlaneComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewPlaneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
