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
     if(this.authServices.isLogin()) this.isLogin = true;
     console.log(this.isLogin)

  }
  onSignin(){
       this.router.navigate(['']);
  }
  onLogin(){
    this.router.navigate(['/login'])
  }
  onLogOut(){
     localStorage.removeItem('token');
     this.router.navigate([''])
  }
}
