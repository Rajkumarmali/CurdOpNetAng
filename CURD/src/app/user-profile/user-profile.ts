import { Component, OnInit } from '@angular/core';
import { Auth } from '../shared/services/auth';

@Component({
  selector: 'app-user-profile',
  imports: [],
  templateUrl: './user-profile.html',
  styleUrl: './user-profile.css',
})
export class UserProfile implements OnInit{

  constructor(private authServices:Auth){}

  userDetail:any;

  ngOnInit():void{
      this.authServices.userProfile().subscribe({
         next:(res:any)=>{
           this.userDetail=res.user;
           console.log(this.userDetail)
         },error:(err)=>{
          console.log(err)
         }
      })
  }
}
