import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { AccountComponent } from './account/account.component';
import { ForumsComponent } from './forums/forums.component';
import { GamesComponent } from './games/games.component';
import { GenreDiscussionComponent } from './genre-discussion/genre-discussion.component';
import { GameDiscussionComponent } from './game-discussion/game-discussion.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    SignupComponent,
    AccountComponent,
    ForumsComponent,
    GamesComponent,
    GenreDiscussionComponent,
    GameDiscussionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
