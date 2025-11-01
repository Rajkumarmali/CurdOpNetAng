import { Routes } from '@angular/router';
import { Signin } from './signin/signin';
import { Login } from './login/login';
import { Dashboard } from './dashboard/dashboard';

export const routes: Routes = [
  {path:'', component:Signin},
  {path:'login', component:Login},
  {path:'dashboard', component:Dashboard}
];
