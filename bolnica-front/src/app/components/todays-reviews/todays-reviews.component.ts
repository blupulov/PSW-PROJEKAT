import { Component, OnInit } from '@angular/core';
import { ReviewDTO } from 'src/app/Models/reviewDTO';
import { ReviewService } from 'src/app/services/review.service';

@Component({
  selector: 'app-todays-reviews',
  templateUrl: './todays-reviews.component.html',
  styleUrls: ['./todays-reviews.component.css']
})

export class TodaysReviewsComponent implements OnInit {

  reviews: ReviewDTO[] = new Array<ReviewDTO>();

  constructor(private reviewService: ReviewService) { }

  ngOnInit(): void {
    this.loadReviews();
  }

  loadReviews(){
    this.reviewService.getAllTodaysReviewsOfDoctor().subscribe(
      res => {
        this.reviews = res;
      }
    )
  }

}
