import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ReviewDTO } from "../Models/reviewDTO";
import { UserService } from "./user.service";

@Injectable({
  providedIn: 'root'
})

export class ReviewService{
  private apiServerUrl = 'http://localhost:31236/api/review'

  constructor(private http:HttpClient, private userService:UserService) {}

  getAllNextReviewOfPatent() {
    return this.http.get<ReviewDTO[]>(this.apiServerUrl + '/next/patient/' + this.userService.loggedUser.id);
  }

  getAllPastReviewOfPatient() {
    return this.http.get<ReviewDTO[]>(this.apiServerUrl + '/past/patient/' + this.userService.loggedUser.id);
  }
  //DODATI ZA DOKTORA KADA GA NAPRAVIM
  //DODATI ZA ZAKAZIVANJE PREGLEDA

  cancelReview(id: number) {
    return this.http.put(this.apiServerUrl + '/cancelReview/' + id.toString(), {});
  }
}
