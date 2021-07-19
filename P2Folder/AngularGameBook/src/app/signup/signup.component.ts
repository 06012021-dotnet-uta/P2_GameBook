import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { User } from '../user';
@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css'],
})
export class SignupComponent implements OnInit {
  newUser: User = {
    UserId:1,
    Username:'',
    Password:'',
    FirstName:'',
    LastName:'',
    Email:'',
  };
  @Output() userevent = new EventEmitter<User>();

  userForm = new FormGroup({
    //FormControls represent the Properties of the form.
    UserId: new FormControl(0, [Validators.min(1)]),
    Username: new FormControl('', [Validators.maxLength(20), Validators.minLength(3)]),
    Password: new FormControl(''),
    FirstName: new FormControl(''),
    LastName: new FormControl(''),
    Email: new FormControl(''),
  });

  constructor() { }

  ngOnInit(): void {
  }

  AddNewUser(): void {
    this.userevent.emit(this.newUser);
  }
  UserReactiveFormSubmit(event: MouseEvent): void {
    console.log('The event was triggered')
  }

}
