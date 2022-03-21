import { NgModule } from '@angular/core';
import {Routes, RouterModule} from "@angular/router";
import {UserRegistrationComponent} from "./components/user-registration/user-registration.component";
import {UserLoginComponent} from "./components/user-login/user-login.component";
import {UserProfileComponent} from "./components/user-profile/user-profile.component";
import { NextReviewsComponent } from './components/next-reviews/next-reviews.component';
import { PastReviewsComponent } from './components/past-reviews/past-reviews.component';
import { ScheduleReviewComponent } from './components/schedule-review/schedule-review.component';
import { RatingReviewComponent } from './components/rating-review/rating-review.component';
import { CreateSurveyComponent } from './components/create-survey/create-survey.component';
import { EditSurveyComponent } from './components/edit-survey/edit-survey.component';
import { SuspiciousUsersComponent } from './components/suspicious-users/suspicious-users.component';
import { AllUsersComponent } from './components/all-users/all-users.component';
import { TodaysReviewsComponent } from './components/todays-reviews/todays-reviews.component';
import { AllSpecialistsComponent } from './components/all-specialists/all-specialists.component';
import { SpecialistProfileComponent } from './components/specialist-profile/specialist-profile.component';
import { DrugsComponent } from './components/drugs/drugs.component';

const routes: Routes = [
  {path: '', component: UserLoginComponent},
  {path: 'registration', component: UserRegistrationComponent},
  {path: 'profile', component: UserProfileComponent},
  {path: 'nextReviews', component: NextReviewsComponent},
  {path: 'pastReviews', component: PastReviewsComponent},
  {path: 'scheduleReview', component: ScheduleReviewComponent},
  {path: 'rateReview', component: RatingReviewComponent},
  {path: 'createSurvey', component: CreateSurveyComponent},
  {path: 'editSurvey', component: EditSurveyComponent},
  {path: 'suspiciousUsers', component: SuspiciousUsersComponent},
  {path: 'allUsers', component: AllUsersComponent},
  {path: 'todaysReviews', component: TodaysReviewsComponent},
  {path: 'allSpecialists', component: AllSpecialistsComponent},
  {path: 'specialistProfile', component: SpecialistProfileComponent},
  {path: 'drugs', component: DrugsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
