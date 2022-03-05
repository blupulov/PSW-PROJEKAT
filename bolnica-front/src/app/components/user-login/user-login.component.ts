import { Component } from '@angular/core';
import {UserService} from "../../services/user.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent{
  public username: string;
  public password: string;

  constructor(public userService: UserService, private router: Router) { }

  onSubmit(form: any) {
    this.userService.loginUser(this.username, this.password).subscribe(
      res => {
        this.userService.loggedUser = res;
        this.router.navigateByUrl('/profile');
        },
      err => {alert("MISTAKE")}
    )
  }
}
