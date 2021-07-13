import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ForumsComponent } from './forums/forums.component';
import { GameDiscussionComponent } from './game-discussion/game-discussion.component';
import { GamesComponent } from './games/games.component';
import { GenreDiscussionComponent } from './genre-discussion/genre-discussion.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },
  { path: 'account', component: GamesComponent },
  { path: 'forums', component: ForumsComponent },
  { path: 'forums/genre-discussion', component: GenreDiscussionComponent },
  { path: 'forums/game-discussion', component: GameDiscussionComponent },
  { path: 'games', component: GamesComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
