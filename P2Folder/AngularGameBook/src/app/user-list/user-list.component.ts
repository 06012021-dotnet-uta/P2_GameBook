import { Component, OnInit } from '@angular/core';
import { USERS } from '../mock-userList';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  users = USERS;

}
