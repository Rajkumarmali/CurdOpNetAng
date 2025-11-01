import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class Auth {
   constructor(private http:HttpClient){}

   signIn(user:any){
      return this.http.post("http://localhost:5050/api/Auth",user);
   }

   logIn(user:any){
      return this.http.post("http://localhost:5050/api/Auth/login",user);
   }
}
