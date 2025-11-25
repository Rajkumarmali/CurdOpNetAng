import { Component, OnInit } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { Auth } from '../shared/services/auth';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-navbar',
  imports: [CommonModule,RouterModule],
  templateUrl: './navbar.html',
  styleUrl: './navbar.css',
})
export class Navbar implements OnInit{
  constructor(private router:Router,private authServices:Auth){}

  isLogin:boolean=false;

  ngOnInit():void{
     this.authServices.isLoggedIn$.subscribe(status=>{
       this.isLogin = Boolean(status);
     });
  }
  onSignin(){
       this.router.navigate(['']);
  }
  onLogin(){
    this.router.navigate(['/login'])
  }
  onLogOut(){
     this.authServices.logOut();
     this.router.navigate([''])
  }
}
