import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class Auth {
   private loginStatus = new BehaviorSubject<Boolean>(this.isLogin());
   isLoggedIn$ = this.loginStatus.asObservable();

   constructor(private http:HttpClient){}

   signIn(user:any){
      return this.http.post("http://localhost:5050/api/Auth",user);
   }

   logIn(user:any){
      return this.http.post("http://localhost:5050/api/Auth/login",user);
   }
   setLogin(token:string){
      localStorage.setItem('token',token);
      this.loginStatus.next(true);
   }
   logOut(){
      localStorage.removeItem('token');
      this.loginStatus.next(false);
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
