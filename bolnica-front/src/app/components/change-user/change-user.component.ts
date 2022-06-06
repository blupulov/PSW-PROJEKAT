import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ChangeUserInfoDTO } from 'src/app/Models/changeUserInfoDTO';
import { UserDTO } from 'src/app/Models/userDTO';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-change-user',
  templateUrl: './change-user.component.html',
  styleUrls: ['./change-user.component.css']
})
export class ChangeUserComponent implements OnInit {

  newUser:ChangeUserInfoDTO = new ChangeUserInfoDTO();
  user: UserDTO = new UserDTO();

  constructor(private userService: UserService, private router:Router) { }

  ngOnInit(): void {
    this.userService.getUserById(this.userService.loggedUser.id).subscribe(
      res => {
        this.user = res
        console.log(this.user)
      }, err => {
        alert('problem with loading user')
      }
    )
  }

  onSubmit() {
    this.mapUser()
    //console.log(this.newUser)
    this.userService.changeUser(this.user.id, this.newUser).subscribe(
      res => {
        this.loadNewUser()
      }, err => {
        alert('error while changing user')
      }
    )
  }

  loadNewUser() {
    this.userService.getUserById(this.user.id).subscribe(
      res => {
        this.userService.loggedUser = res
        this.router.navigateByUrl('profile')
      }, err => {
        alert('problem with loading new user info')
      }
    )
  }

  mapUser() {
    this.newUser.name = this.user.name
    this.newUser.address = this.user.address
    this.newUser.surname = this.user.surname
    this.newUser.phoneNumber = this.user.phoneNumber
    this.newUser.email = this.user.eMail
    this.newUser.gender = this.user.gender
  }

}
