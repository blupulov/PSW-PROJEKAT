import { Component, OnInit } from '@angular/core';
import { SurveyDTO } from 'src/app/Models/surveyDTO';
import { SurveyService } from 'src/app/services/survey.service';

@Component({
  selector: 'app-show-surveys',
  templateUrl: './show-surveys.component.html',
  styleUrls: ['./show-surveys.component.css']
})
export class ShowSurveysComponent implements OnInit {

  surveys: SurveyDTO[] = new Array<SurveyDTO>();

  constructor(private surveyService: SurveyService) { }

  ngOnInit(): void {
    this.surveyService.getAllPublishedSurvey().subscribe(
      res => {
        this.surveys = res;
      }
    )
  }

}
