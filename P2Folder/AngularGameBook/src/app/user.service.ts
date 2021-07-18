import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';


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
}

  export interface User {
    userId: number,
    username: string,
    password: string,
    firstName: string,
    lastName: string,
    email: string,
}