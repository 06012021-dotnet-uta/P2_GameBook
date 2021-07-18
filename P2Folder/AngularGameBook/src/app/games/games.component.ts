import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { GameService, Game } from '../game.service';

@Component({
  selector: 'app-games',
  templateUrl: './games.component.html',
  styleUrls: ['./games.component.css']
})
export class GamesComponent implements OnInit {
  games: Game[];
  constructor(private httpClient: HttpClient, private gameService: GameService) {
    this.games = [];
  }
  ngOnInit(): void {
    this.getGames();
  }
  getGames() {
    this.httpClient.get<any>('https://localhost:44350/api/Game/GameList').subscribe(
      response => {
        console.log(response);
        this.games = response;
      }
    )
  }
}

