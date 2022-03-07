import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ReviewRatingDTO } from 'src/app/Models/reviewRatingDTO';
import { ReviewService } from 'src/app/services/review.service';

@Component({
  selector: 'app-rating-review',
  templateUrl: './rating-review.component.html',
  styleUrls: ['./rating-review.component.css']
})
export class RatingReviewComponent implements OnInit {

  reviewRatingDTO: ReviewRatingDTO = new ReviewRatingDTO();

  constructor(private reviewService: ReviewService, private router: Router) { }

  ngOnInit(): void {
    this.reviewRatingDTO.reviewId = this.reviewService.selectedReviewForRating.id;
  }

  onSubmit(form: any){
    this.prepareDataForSending();
    this.reviewService.rateReview(this.reviewRatingDTO).subscribe(
      res => {
      alert("REVIEW IS SUCCESSFULLY RATED!");
      this.router.navigateByUrl('/pastReviews')
      },
      err => {
        alert("THERE IS SOME PROBLEMS WITH SERVER");
      })
  }

  prepareDataForSending(){
    if(this.reviewRatingDTO.grade == 1)
      this.reviewRatingDTO.grade = 1;
    if(this.reviewRatingDTO.grade == 2)
      this.reviewRatingDTO.grade = 2;
    if(this.reviewRatingDTO.grade == 3)
      this.reviewRatingDTO.grade = 3;
    if(this.reviewRatingDTO.grade == 4)
      this.reviewRatingDTO.grade = 4;
    else
    this.reviewRatingDTO.grade = 5;
  }
  
}
