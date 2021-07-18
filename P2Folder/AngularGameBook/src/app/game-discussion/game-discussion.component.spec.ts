import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GameDiscussionComponent } from './game-discussion.component';

describe('GameDiscussionComponent', () => {
  let component: GameDiscussionComponent;
  let fixture: ComponentFixture<GameDiscussionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GameDiscussionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GameDiscussionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  // it('should create', () => {
  //   expect(component).toBeTruthy();
  // });
});
