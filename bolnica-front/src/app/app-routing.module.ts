import { NgModule } from '@angular/core';
import {Routes, RouterModule} from "@angular/router";
import {UserRegistrationComponent} from "./user-registration/user-registration.component";
import  {UserLoginComponent} from "./user-login/user-login.component";
import {UserProfileComponent} from "./user-profile/user-profile.component";

const routes: Routes = [
  {path: '', component: UserLoginComponent},
  {path: 'registration', component: UserRegistrationComponent},
  {path: 'profile', component: UserProfileComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
