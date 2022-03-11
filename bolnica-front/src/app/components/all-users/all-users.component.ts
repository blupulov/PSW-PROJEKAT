import { Component, OnInit } from '@angular/core';
import { UserDTO } from 'src/app/Models/userDTO';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-all-users',
  templateUrl: './all-users.component.html',
  styleUrls: ['./all-users.component.css']
})
export class AllUsersComponent implements OnInit {

  users: UserDTO[] = new Array<UserDTO>();
  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.loadAllUsers();
  }

  loadAllUsers(){
    this.userService.getAllUsers().subscribe(
      res => {
        this.users = res;
      }
    )
  }

  blockUser(userId: number){
    this.userService.blockUser(userId).subscribe(
      res => {
        alert("User is blocked");
        this.loadAllUsers();
      },
      err => {alert("There is some errors with server");}
    )
  }

  unblockUser(userId: number){
    this.userService.unblockUser(userId).subscribe(
      res => {
        alert("User is unblocked");
        this.loadAllUsers();
      },
      err => {alert("There is some errors with server");}
    )
  }

}
