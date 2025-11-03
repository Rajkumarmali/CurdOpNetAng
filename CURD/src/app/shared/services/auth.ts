import { HttpClient, HttpHeaders } from '@angular/common/http';
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
   userProfile(){
        // const token = localStorage.getItem('token')
        // const headers = new HttpHeaders({
        //   'Authorization':`Bearer ${token}`
        // })
        // return this.http.get("http://localhost:5050/api/Auth",{headers})
        return this.http.get("http://localhost:5050/api/Auth")
   }
   isLogin(){
       return localStorage.getItem('token') != null? true:false;
   }
}
