import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AccountService, Friend, PlayHistory } from '../account.service';
import { User } from '../user';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})

export class AccountComponent implements OnInit {
  users: User [];
  friends: Friend [];
  playHistory: PlayHistory[];
  constructor(private httpClient: HttpClient, private accountService: AccountService) {
    this.users = [];
    this.friends = [];
    this.playHistory = [];
   }

  ngOnInit(): void {
    this.getUser();
    this.getFriends();
    this.getPlayHistory();
  }

  getUser() {
    this.httpClient.get<any>('https://localhost:44350/api/User/list').subscribe( //change to get currently signed in user
      response => {
        console.log(response);
        this.users = response;
      })
  }
  getFriends() {
    this.httpClient.get<any>('https://localhost:44350/api/Friend/list/1').subscribe( //change to get currently signed in user
      response => {
        console.log(response);
        this.users = response;
      })
  }
  getPlayHistory() {
    this.httpClient.get<any>('https://localhost:44350/api/PlayHistory/1').subscribe( //change to get currently signed in user
      response => {
        console.log(response);
        this.users = response;
      })
  }
}
