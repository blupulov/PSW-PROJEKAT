import { Component, OnInit } from '@angular/core';
import { ScheduleDTO } from 'src/app/Models/scheduleDTO';
import { ScheduleReviewDTO } from 'src/app/Models/scheduleReviewDTO';
import { DoctorService } from 'src/app/services/doctor.service';
import { ReviewService } from 'src/app/services/review.service';
import { UserService } from 'src/app/services/user.service';
import { DoctorDTO } from 'src/app/Models/DoctorDTO';
import { Router } from '@angular/router';

@Component({
  selector: 'app-schedule-review',
  templateUrl: './schedule-review.component.html',
  styleUrls: ['./schedule-review.component.css']
})

export class ScheduleReviewComponent implements OnInit {

  public scheduleDto = new ScheduleDTO();
  public doctors = new Array<DoctorDTO>(); 
  public freeReviews = new Array<ScheduleReviewDTO>();

  constructor(private doctorService:DoctorService, private userService:UserService,
     private reviewService: ReviewService, private router: Router) { }

  ngOnInit(): void {
    this.scheduleDto.userId = this.userService.loggedUser.id;
    this.getAllNonSpecialistDoctors();
  }

  onSubmit(form: any){
    if(this.scheduleDto.priority === 0)
      this.scheduleDto.priority = 0;
    else
      this.scheduleDto.priority = 1;

    this.reviewService.scheduleReview(this.scheduleDto).subscribe( data => {
      this.freeReviews = data;
    }, err => {alert("There is some problem with server")})
  }

  getAllNonSpecialistDoctors(){
    this.doctorService.getAllNonSpecialistDoctors().subscribe(data => {
      this.doctors = data;
    })
  }

  isFreeReviewsEmpty(): boolean{
    if(this.freeReviews.length === 0)
      return true;
    else
      return false;
  }

  clearFreeReviews(): void{
    this.freeReviews = [];
  }

  createReview(scheduleReviewDTO:ScheduleReviewDTO){
    this.reviewService.createReview(scheduleReviewDTO).subscribe( 
      res => {
        alert("REVIEW IS SUCCESSFULLY SCHEDULED");
        this.router.navigate(['/nextReviews'])
      }, 
      err => {
        alert("THERE IS SOME PROBLEM WITH SERVER")
    })
  }
}
