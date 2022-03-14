import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ReviewDTO } from 'src/app/Models/reviewDTO';
import { ReviewService } from 'src/app/services/review.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-past-reviews',
  templateUrl: './past-reviews.component.html',
  styleUrls: ['./past-reviews.component.css']
})

export class PastReviewsComponent implements OnInit {
  
  reviews: ReviewDTO[] = new Array<ReviewDTO>(); 

  constructor(private reviewService: ReviewService,
     public userService: UserService, private router: Router) { }

  ngOnInit(): void {
    this.getAllPastReviews();
  }

  private getAllPastReviews(): void {
    if(!this.userService.isDoctor)
      this.reviewService.getAllPastReviewOfPatient().subscribe(data => {
        this.reviews = data;
      })
    else
      this.reviewService.getAllPastReviewOfDoctor().subscribe(data => {
        this.reviews = data;
      })
  }

  openRatingForm(r: ReviewDTO): void {
    this.reviewService.selectedReviewForRating = r;
    this.router.navigateByUrl('/rateReview');
  }
}
