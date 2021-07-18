import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { UserService, User } from '../user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})

export class UserListComponent implements OnInit {
  users: User[];
  constructor(private httpClient: HttpClient, private userService: UserService) {
    this.users = [];
  }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers() {
    this.httpClient.get<any>('https://localhost:44350/api/User/list').subscribe(
      response => {
        console.log(response);
        this.users = response;
      }
    )
  }
}
