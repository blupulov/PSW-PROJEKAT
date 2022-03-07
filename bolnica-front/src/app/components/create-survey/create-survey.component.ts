import { ThrowStmt } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CreateSurveyDTO } from 'src/app/Models/createSurveyDTO';
import { SurveyService } from 'src/app/services/survey.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-create-survey',
  templateUrl: './create-survey.component.html',
  styleUrls: ['./create-survey.component.css']
})
export class CreateSurveyComponent implements OnInit {

  survey: CreateSurveyDTO = new CreateSurveyDTO();
  isTimeForSurvey: boolean;

  constructor(private userService: UserService,
     private router: Router, private surveyService: SurveyService) { }

  ngOnInit(): void {
    this.surveyService.isTimeForSurvey(this.userService.loggedUser.id).subscribe(res => {
      this.isTimeForSurvey = res;
    })
  }

  onSubmit(form: any) {
    this.prepareDataForSending();
    
    this.surveyService.createSurvey(this.survey).subscribe(
      res => {
        alert("SURVEY IS CREATED!")
        this.router.navigateByUrl('/profile');
     },
      err => {
        alert("THERE IS SOME ERROR ON SERVER");
      }
    )
  }

  prepareDataForSending(){
    if(this.survey.grade.toString() == "1")
      this.survey.grade = 1;
    if(this.survey.grade.toString() == "2")
      this.survey.grade = 2;
    if(this.survey.grade.toString() == "3")
      this.survey.grade = 3;
    if(this.survey.grade.toString() == "4")
      this.survey.grade = 4;
    else
    this.survey.grade = 5;

    if(this.survey.isAnonymous.toString() == "true")
      this.survey.isAnonymous = true;
    else
      this.survey.isAnonymous = false;

    this.survey.userId = this.userService.loggedUser.id;
  }




}
