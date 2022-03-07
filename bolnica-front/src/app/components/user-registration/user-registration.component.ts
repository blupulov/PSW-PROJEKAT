import { Component, OnInit } from '@angular/core';
import {UserService} from "../../services/user.service";
import {UserDTO} from "../../Models/userDTO";
import {Router} from "@angular/router";

@Component({
  selector: 'app-user-registration',
  templateUrl: './user-registration.component.html',
  styleUrls: ['./user-registration.component.css']
})
export class UserRegistrationComponent implements OnInit {

  constructor(public userService: UserService, private router: Router) { }

  ngOnInit(): void {
  }
  
  onSubmit(form: any) {
    this.userService.registerUser().subscribe(
      res => {
        this.userService.userForRegistration = new UserDTO();
        this.router.navigate([''])
        },
      err => {
        alert('THERE IS SOME PROBLEM WITH SERVER');
      }
    );
  }

  clearForm() {
    this.userService.userForRegistration = new UserDTO();
  }
}
