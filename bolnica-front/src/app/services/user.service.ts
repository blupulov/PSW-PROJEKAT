import {Observable} from "rxjs";
import {Injectable} from "@angular/core";
import {HttpClient, HttpParams} from "@angular/common/http";
import {UserDTO} from "../Models/userDTO";
import {query} from "@angular/animations";

@Injectable({
  providedIn: 'root'
})
export class UserService{
  private apiServerUrl = 'http://localhost:31236/api/user';

  constructor(private http: HttpClient) { }

  userForRegistration:UserDTO = new UserDTO();
  loggedUser: UserDTO = new UserDTO();
  userForChange: UserDTO = new UserDTO();

  registerUser(){
    return this.http.post(this.apiServerUrl, this.userForRegistration);
  }
  loginUser(username: string, password: string): Observable<UserDTO>{
    let params = new HttpParams();
    params = params.append('username', username);
    params = params.append('password', password);
    return this.http.get<UserDTO>(this.apiServerUrl + '/login', {params: params});
  }
}
