import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GenreDiscussionComponent } from './genre-discussion.component';

describe('GenreDiscussionComponent', () => {
  let component: GenreDiscussionComponent;
  let fixture: ComponentFixture<GenreDiscussionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GenreDiscussionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GenreDiscussionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
