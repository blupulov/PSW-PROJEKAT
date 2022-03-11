import {Observable} from "rxjs";
import {Injectable} from "@angular/core";
import {HttpClient, HttpParams} from "@angular/common/http";
import {UserDTO} from "../Models/userDTO";

@Injectable({
  providedIn: 'root'
})
export class UserService{
  private apiServerUrl = 'http://localhost:31236/api/user';

  constructor(private http: HttpClient) { }

  //SHARED DATA
  userForRegistration:UserDTO = new UserDTO();
  loggedUser: UserDTO = new UserDTO();
  userForChange: UserDTO = new UserDTO();
  isDoctor: boolean = false;

  //METHODS
  registerUser(){
    return this.http.post(this.apiServerUrl, this.userForRegistration);
  }
  
  loginUser(username: string, password: string): Observable<UserDTO>{
    let params = new HttpParams();
    params = params.append('username', username);
    params = params.append('password', password);
    return this.http.get<UserDTO>(this.apiServerUrl + '/login', {params: params});
  }

  getAllSuspiciousUsers(){
    return this.http.get<UserDTO[]>(this.apiServerUrl + '/suspicious');
  }

  getAllUsers(){
    return this.http.get<UserDTO[]>(this.apiServerUrl + '/allUsers');
  }

  blockUser(userId: number){
    return this.http.put(this.apiServerUrl + '/block/' + userId, {});

  }

  unblockUser(userId: number){
    return this.http.put(this.apiServerUrl + '/unblock/' + userId, {});
  }

  clearSuspiciousUser(userId: number){
    return this.http.put(this.apiServerUrl + '/clearSuspiciousUser/' + userId, {});
  }
}
