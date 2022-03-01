import { Component, OnInit } from '@angular/core';
import { ReviewDTO } from 'src/app/Models/reviewDTO';
import { ReviewService } from 'src/app/services/review.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-next-reviews',
  templateUrl: './next-reviews.component.html',
  styleUrls: ['./next-reviews.component.css']
})
export class NextReviewsComponent implements OnInit {

  reviews: ReviewDTO[] = new Array<ReviewDTO>();
  constructor(private userService: UserService, private reviewService: ReviewService) { }

  ngOnInit(): void {
    this.getAllNextReviews();
  }

  private getAllNextReviews(): void{
    if(!this. userService.isDoctor)
      this.reviewService.getAllNextReviewOfPatent().subscribe(data => {
        this.reviews = data;
      })
  }

  //rad sa greskama
  public cancelReview(id: number): void {
    this.reviewService.cancelReview(id).subscribe(() => {
      alert('REVIEW IS CANCELED');
      this.getAllNextReviews();
    })
  }

}
