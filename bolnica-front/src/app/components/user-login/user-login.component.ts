import { Component } from '@angular/core';
import {UserService} from "../../services/user.service";
import {Router} from "@angular/router";
import { DoctorService } from 'src/app/services/doctor.service';

@Component({
  selector: 'app-user-login',
  templateUrl: './user-login.component.html',
  styleUrls: ['./user-login.component.css']
})
export class UserLoginComponent{
  public username: string;
  public password: string;
  public isDoctor: boolean = false;

  constructor(public userService: UserService,
     private router: Router, private doctorService: DoctorService) { }

  onSubmit(form: any) {
    if(this.isDoctor == false)
      this.loginUser();
    else
      this.loginDoctor();
  }

  loginDoctor(){
    this.doctorService.loginDoctor(this.username, this.password).subscribe(
      res => {
        this.userService.isDoctor = true;
        this.userService.loggedUser = res;
        this.router.navigateByUrl('/profile');
      },
      err => {
        alert('MISTAKE');
      }
    )
  }

  loginUser(){
    this.userService.loginUser(this.username, this.password).subscribe(
      res => {
        this.userService.loggedUser = res;
        this.router.navigateByUrl('/profile');
        },
      err => {alert("MISTAKE")}
    )
  }

}
