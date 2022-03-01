import { NgModule } from '@angular/core';
import {Routes, RouterModule} from "@angular/router";
import {UserRegistrationComponent} from "./components/user-registration/user-registration.component";
import {UserLoginComponent} from "./components/user-login/user-login.component";
import {UserProfileComponent} from "./components/user-profile/user-profile.component";
import { NextReviewsComponent } from './components/next-reviews/next-reviews.component';
import { PastReviewsComponent } from './components/past-reviews/past-reviews.component';
import { ScheduleReviewComponent } from './components/schedule-review/schedule-review.component';

const routes: Routes = [
  {path: '', component: UserLoginComponent},
  {path: 'registration', component: UserRegistrationComponent},
  {path: 'profile', component: UserProfileComponent},
  {path: 'nextReviews', component: NextReviewsComponent},
  {path: 'pastReviews', component: PastReviewsComponent},
  {path: 'scheduleReview', component: ScheduleReviewComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
