import { Routes } from '@angular/router';
import { Signin } from './signin/signin';
import { Login } from './login/login';
import { Dashboard } from './dashboard/dashboard';
import { authGuard } from './shared/auth-guard';
import { UserProfile } from './user-profile/user-profile';

export const routes: Routes = [
  {path:'', component:Signin},
  {path:'login', component:Login},
  {path:'dashboard', component:Dashboard,canActivate:[authGuard]},
  {path:'userProfile',component:UserProfile,canActivate:[authGuard]}
];
