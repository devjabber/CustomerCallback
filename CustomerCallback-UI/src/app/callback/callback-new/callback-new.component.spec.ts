import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CallbackNewComponent } from './callback-new.component';

describe('CallbackNewComponent', () => {
  let component: CallbackNewComponent;
  let fixture: ComponentFixture<CallbackNewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CallbackNewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CallbackNewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
