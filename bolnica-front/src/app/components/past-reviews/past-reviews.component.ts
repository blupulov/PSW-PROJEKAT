import { Component, OnInit } from '@angular/core';
import { ReviewDTO } from 'src/app/Models/reviewDTO';
import { ReviewService } from 'src/app/services/review.service';

@Component({
  selector: 'app-past-reviews',
  templateUrl: './past-reviews.component.html',
  styleUrls: ['./past-reviews.component.css']
})

export class PastReviewsComponent implements OnInit {
  
  reviews: ReviewDTO[] = new Array<ReviewDTO>(); 

  constructor(private reviewService: ReviewService) { }

  ngOnInit(): void {
    this.getAllPastReviews();
  }

  private getAllPastReviews(): void {
    this.reviewService.getAllPastReviewOfPatient().subscribe(data => {
      this.reviews = data;
    })
  }

}
