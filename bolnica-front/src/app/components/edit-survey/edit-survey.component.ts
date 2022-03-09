import { Component, OnInit } from '@angular/core';
import { SurveyDTO } from 'src/app/Models/surveyDTO';
import { SurveyService } from 'src/app/services/survey.service';

@Component({
  selector: 'app-edit-survey',
  templateUrl: './edit-survey.component.html',
  styleUrls: ['./edit-survey.component.css']
})
export class EditSurveyComponent implements OnInit {

  surveys: SurveyDTO[] = new Array<SurveyDTO>(); 

  constructor(private surveyService: SurveyService) { }

  ngOnInit(): void {
    this.loadAllSurveys();
  }

  loadAllSurveys(){
    this.surveyService.getAllSurvey().subscribe(
      res => {
        this.surveys = res;
      }
    )
  }

  publishSurvey(id: number){
    this.surveyService.publishSurvey(id).subscribe(
      res => { 
        alert("Survey is published")
        this.loadAllSurveys();
      },
      err => {
        alert("THERE IS SOME ERROR WITH SERVER");
      }
    )
  }

  unpublishSurvey(id: number){
    this.surveyService.unPublishSurvey(id).subscribe(
      res => { 
        alert("Survey is unpublished")
        this.loadAllSurveys();
      },
      err => {
        alert("THERE IS SOME ERROR WITH SERVER");
      }
    )
  }

  deleteSurvey(id: number){
    this.surveyService.deleteSurvey(id).subscribe(
      res => { 
        alert("Survey is deleted")
        this.loadAllSurveys();
      },
      err => {
        alert("THERE IS SOME ERROR WITH SERVER");
      }
    )
  }

}
