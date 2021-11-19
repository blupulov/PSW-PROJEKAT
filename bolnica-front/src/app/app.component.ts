import {Component, OnInit} from '@angular/core';
import {UserDTO} from "./Models/userDTO";
import {UserService} from "./services/user.service";
import {HttpErrorResponse} from "@angular/common/http";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent{
  title: string | undefined;

}
