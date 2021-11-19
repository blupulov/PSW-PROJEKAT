import { Component, OnInit } from '@angular/core';
import {UserService} from "../services/user.service";
import {UserDTO} from "../Models/userDTO";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(public userService:UserService) { }

  ngOnInit(): void {
  }

  logOut() {
    this.userService.loggedUser = new UserDTO();

  }
}
