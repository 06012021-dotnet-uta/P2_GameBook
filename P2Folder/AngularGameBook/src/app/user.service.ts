import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  url: string = 'https://localhost:44350/api/User/';
  httpOptions = 
  {
    headers: new HttpHeaders
    ({
      'Content-Type': 'application/json'
    })
  }
  // GetPlayerlist(): Observable<User[]> {
  //   //returnthe MockPlayerList
  //   //return of(mockPlayerList);
  //   return this.http.get<User[]>('https://localhost:5001/api/RpsGame/PlayerList');
  // }

  // AddPlayer(u: User): Observable<User> {
  //   //this MAY not be correct
  //   return this.http.post<User>(`${this.url}CreateNewUser/`, u, this.httpOptions)

  // }
}