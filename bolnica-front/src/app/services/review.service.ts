import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ReviewDTO } from "../Models/reviewDTO";
import { ReviewRatingDTO } from "../Models/reviewRatingDTO";
import { ScheduleDTO } from "../Models/scheduleDTO";
import { ScheduleReviewDTO } from "../Models/scheduleReviewDTO";
import { UserService } from "./user.service";

@Injectable({
  providedIn: 'root'
})

export class ReviewService{
  private apiServerUrl = 'http://localhost:31236/api/review'

  constructor(private http:HttpClient, private userService:UserService) {}

  //SHARED DATA
  selectedReviewForRating: ReviewDTO = new ReviewDTO();

  //METHODS
  getAllNextReviewOfPatent() {
    return this.http.get<ReviewDTO[]>(this.apiServerUrl + '/next/patient/' + this.userService.loggedUser.id);
  }

  getAllPastReviewOfPatient() {
    return this.http.get<ReviewDTO[]>(this.apiServerUrl + '/past/patient/' + this.userService.loggedUser.id);
  }

  scheduleReview(scheduleDto: ScheduleDTO) {
    return this.http.post<ScheduleReviewDTO[]>(this.apiServerUrl + '/scheduleReview', scheduleDto);
  }

  cancelReview(id: number) {
    return this.http.put(this.apiServerUrl + '/cancelReview/' + id.toString(), {});
  }

  createReview(scheduleReviewDTO: ScheduleReviewDTO) {
    return this.http.post(this.apiServerUrl + '/create', scheduleReviewDTO);
  }

  rateReview(reviewRatingDTO: ReviewRatingDTO) {
    return this.http.post(this.apiServerUrl + '/addRating', reviewRatingDTO);
  }
  
}
