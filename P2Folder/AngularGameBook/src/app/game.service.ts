import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  url: string = 'https://localhost:5001/api/GetGameList/';
  httpOptions =
    {
      headers: new HttpHeaders
        ({
          'Content-Type': 'application/json'
        })
    }
}

export interface Game
{
    GameId: number;
    Name: string;
}