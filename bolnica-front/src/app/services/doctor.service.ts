import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { DoctorDTO } from "../Models/doctorDTO";
import { UserDTO } from "../Models/userDTO";

@Injectable({
  providedIn: 'root'
})

export class DoctorService{
  private apiServerUrl = 'http://localhost:31236/api/doctor'

  constructor(private http:HttpClient) {}

  //SHARED DATA
  selectedDoctor: DoctorDTO;

  //METHODS
  getAllNonSpecialistDoctors(){
    return this.http.get<DoctorDTO[]>(this.apiServerUrl + '/nonSpecialist');
  }

  getAllSpecialistDoctors(){
    return this.http.get<DoctorDTO[]>(this.apiServerUrl + '/specialist');
  }

  loginDoctor(username: string, password: string){
    let params = new HttpParams();
    params = params.append('username', username);
    params = params.append('password', password);
    return this.http.get<UserDTO>(this.apiServerUrl + '/login', {params: params})
  }
}