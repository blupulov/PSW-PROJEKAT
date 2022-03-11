import { Component, OnInit } from '@angular/core';
import { UserDTO } from 'src/app/Models/userDTO';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-suspicious-users',
  templateUrl: './suspicious-users.component.html',
  styleUrls: ['./suspicious-users.component.css']
})
export class SuspiciousUsersComponent implements OnInit {

  users: UserDTO[] = new Array<UserDTO>();

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.loadSuspiciousUsers();
  }

  loadSuspiciousUsers(): void{
    this.userService.getAllSuspiciousUsers().subscribe(
      res => {
        this.users = res;
      },
      err => {
        alert("There is some errors with server");
      }
    )
  }

  blockUser(userId: number){
    this.userService.blockUser(userId).subscribe(
      res => {
        alert("User is blocked");
        this.loadSuspiciousUsers();
      },
      err => {alert("There is some errors with server");}
    )
  }

  unblockUser(userId: number){
    this.userService.unblockUser(userId).subscribe(
      res => {
        alert("User is unblocked");
        this.loadSuspiciousUsers();
      },
      err => {alert("There is some errors with server");}
    )
  }

  clearUser(userId: number){
    this.userService.clearSuspiciousUser(userId).subscribe(
      res => {
        alert("User is cleared");
        this.loadSuspiciousUsers();
    },
      err => {alert("There is some errors with server");}
    )
  }

}
