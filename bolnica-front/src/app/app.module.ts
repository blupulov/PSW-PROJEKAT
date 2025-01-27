import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatButtonModule} from "@angular/material/button";
import {MatIconModule} from "@angular/material/icon";
import {NoopAnimationsModule} from "@angular/platform-browser/animations";
import { AppComponent } from './app.component';
import { UserRegistrationComponent } from './components/user-registration/user-registration.component';
import {HttpClientModule} from "@angular/common/http";
import { AppRoutingModule } from './app-routing.module';
import { UserLoginComponent } from './components/user-login/user-login.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavbarComponent } from './components/navbar/navbar.component';
import { ReactiveFormsModule } from "@angular/forms";
import {MatInputModule} from "@angular/material/input";
import {MatOptionModule} from "@angular/material/core";
import {MatSelectModule} from "@angular/material/select";
import {MatGridListModule} from "@angular/material/grid-list";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {FormsModule} from "@angular/forms";
import {UserService} from "./services/user.service";
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { ScheduleReviewComponent } from './components/schedule-review/schedule-review.component';
import { PastReviewsComponent } from './components/past-reviews/past-reviews.component';
import { NextReviewsComponent } from './components/next-reviews/next-reviews.component';
import { MatTableModule } from '@angular/material/table';
import { RatingReviewComponent } from './components/rating-review/rating-review.component';
import { MatCardModule } from '@angular/material/card';
import { CreateSurveyComponent } from './components/create-survey/create-survey.component';
import { ShowSurveysComponent } from './components/show-surveys/show-surveys.component';
import { EditSurveyComponent } from './components/edit-survey/edit-survey.component';
import { SuspiciousUsersComponent } from './components/suspicious-users/suspicious-users.component';
import { AllUsersComponent } from './components/all-users/all-users.component';
import { MatMenuModule} from '@angular/material/menu';
import { TodaysReviewsComponent } from './components/todays-reviews/todays-reviews.component';
import { AllSpecialistsComponent } from './components/all-specialists/all-specialists.component';
import { SpecialistProfileComponent } from './components/specialist-profile/specialist-profile.component';
import { DrugsComponent } from './components/drugs/drugs.component';
import { ChangeUserComponent } from './components/change-user/change-user.component';

@NgModule({
  declarations: [
    AppComponent,
    UserRegistrationComponent,
    UserLoginComponent,
    NavbarComponent,
    UserProfileComponent,
    ScheduleReviewComponent,
    PastReviewsComponent,
    NextReviewsComponent,
    RatingReviewComponent,
    CreateSurveyComponent,
    ShowSurveysComponent,
    EditSurveyComponent,
    SuspiciousUsersComponent,
    AllUsersComponent,
    TodaysReviewsComponent,
    AllSpecialistsComponent,
    SpecialistProfileComponent,
    DrugsComponent,
    ChangeUserComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    NoopAnimationsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatOptionModule,
    MatSelectModule,
    MatGridListModule,
    NgbModule,
    FormsModule,
    MatTableModule,
    MatCardModule,
    MatMenuModule
  ],
  providers: [UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
