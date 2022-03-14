import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ReviewDTO } from 'src/app/Models/reviewDTO';
import { ScheduleReviewForSpecialistDTO } from 'src/app/Models/ScheduleReviewForSpecialistDTO';
import { DoctorService } from 'src/app/services/doctor.service';
import { ReviewService } from 'src/app/services/review.service';

@Component({
  selector: 'app-specialist-profile',
  templateUrl: './specialist-profile.component.html',
  styleUrls: ['./specialist-profile.component.css']
})
export class SpecialistProfileComponent implements OnInit {

  nextReviews: ReviewDTO[] = new Array<ReviewDTO>();
  scheduleDto: ScheduleReviewForSpecialistDTO = new ScheduleReviewForSpecialistDTO();

  constructor(private reviewService: ReviewService,
     public doctorService: DoctorService, private router: Router) { }

  ngOnInit(): void {
    this.loadAllNextReviews();
  }

  loadAllNextReviews(){
    this.reviewService.getAllNextReviewsOfDoctor(this.doctorService.selectedDoctor.id).subscribe(
      res => {
        this.nextReviews = res;
      }
    )
  }

  onSubmit(form: any){
    this.scheduleDto.specialistId = this.doctorService.selectedDoctor.id;
    this.scheduleDto.reviewId = this.reviewService.selectedReviewId;
    this.reviewService.scheduleReviewWithSpecialist(this.scheduleDto).subscribe(
      res => {
        alert("Review is scheduler");
        this.router.navigateByUrl('/todaysReviews');
      },
      err => {
        alert("There is some error with server");
      }
    )
  }
}
