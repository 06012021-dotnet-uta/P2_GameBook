import { HttpClient } from '@angular/common/http';
import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { GameService, Game } from '../game.service';


@Component({
  selector: 'app-games',
  templateUrl: './games.component.html',
  styleUrls: ['./games.component.css']
})
export class GamesComponent implements OnInit {
  @Output() searchEvent = new EventEmitter();

  public apiUrl = 'https://localhost:5001/api/Game/';
  games: Game[];

  constructor(private httpClient: HttpClient, private gameService: GameService) {
    this.games = [];
  }
  ngOnInit(): void {
    this.getGames();
  }
  onSubmit(searchValue: string) {
    // your function

    this.searchEvent.emit(searchValue);
  }
  getGames() {
    this.httpClient.get<any>(this.apiUrl+'GameList').subscribe(
      response => {
        console.log(response);
        this.games = response;
      }
    )
  }
  getGamesByGenre() {
    this.httpClient.get<any>(this.apiUrl+'genre').subscribe(
      response => {
        console.log(response);
        this.games = response;
      }
    )
  }
}

