import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { CreateSurveyDTO } from "../Models/createSurveyDTO";
import { SurveyDTO } from "../Models/surveyDTO";
import { UserService } from "./user.service";

@Injectable({
  providedIn:'root'
})

export class SurveyService {
  private apiServerUrl = 'http://localhost:31236/api/survey';

  constructor(private http: HttpClient) { }

  getAllSurvey() {
    return this.http.get<SurveyDTO[]>(this.apiServerUrl);
  }

  getAllPublishedSurvey() {
    return this.http.get<SurveyDTO[]>(this.apiServerUrl + '/published');
  }

  isTimeForSurvey(userId: number) {
    return this.http.get<boolean>(this.apiServerUrl + '/isTime/' + userId);
  }

  createSurvey(survey: CreateSurveyDTO) {
    return this.http.post(this.apiServerUrl, survey);
  }

  publishSurvey(id: number) {
    return this.http.put(this.apiServerUrl + '/publish/' + id, {});
  }

  unPublishSurvey(id: number) {
    return this.http.put(this.apiServerUrl + '/unpublish/' + id, {});
  }

  deleteSurvey(id: number) {
    return this.http.delete(this.apiServerUrl + '/' + id);
  }
}