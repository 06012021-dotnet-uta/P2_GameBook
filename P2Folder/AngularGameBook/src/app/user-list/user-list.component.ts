import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { USERS } from '../mock-userList';

export class User {
  constructor(
    public userId: number,
    public username: string,
    public password: string,
    public firstName: string,
    public lastName: string,
    public email: string,
  ) {
  }
}

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})

export class UserListComponent implements OnInit {

  users: User[] | undefined;
  constructor(
    private httpClient: HttpClient
  ) { }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers(){
    this.httpClient.get<any>('https://localhost:5001/api/User').subscribe(
      response => {
        console.log(response);
        this.users = response;
      }
    )
  }

}
