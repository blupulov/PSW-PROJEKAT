import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { DoctorDTO } from "../Models/DoctorDTO";

@Injectable({
  providedIn: 'root'
})

export class DoctorService{
  private apiServerUrl = 'http://localhost:31236/api/doctor'

  constructor(private http:HttpClient) {}

  getAllNonSpecialistDoctors(){
    return this.http.get<DoctorDTO[]>(this.apiServerUrl + '/nonSpecialist');
  }
}