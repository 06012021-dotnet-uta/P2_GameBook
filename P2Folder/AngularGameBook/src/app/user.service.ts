import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class UserService {
  constructor(private http: HttpClient) { }

  url: string = 'https://localhost:44350/api/User/';
  httpOptions =
    {
      headers: new HttpHeaders
        ({
          'Content-Type': 'application/json'
        })
    }
  httpHeader =
    {
      headers: new HttpHeaders
        ({
          'Content-Type': 'application/json'
        })
    }

  UserLogin() {
    //do something to login
  }

  AddUser(newUser: User): void{
    //post call to add user
    this.http.post(this.url, newUser.username + "/" + newUser.password + "/" + newUser.firstName + "/" + newUser.lastName + "/" + newUser.email, this.httpHeader)
      .subscribe
      (
        (data) => {
          console.log(data);
          return true;
        },
        (error) => {
          console.log(error)
          return false;
        }
      );
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