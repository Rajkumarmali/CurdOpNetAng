import { Component, OnInit } from '@angular/core';
import { Auth } from '../shared/services/auth';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-user-profile',
  imports: [CommonModule,FormsModule],
  templateUrl: './user-profile.html',
  styleUrl: './user-profile.css',
})
export class UserProfile implements OnInit{

  resetPassModel:Boolean = false;

  constructor(private authServices:Auth,private toastr:ToastrService){}

  userDetail:any;

  updatePassword:any={
    oldPassword:'',
    newPassword:''
  }

  onUpdatePassword(){
    this.authServices.updatePassword(this.updatePassword).subscribe({
    next: (res: any) => {
      console.log(res);
      if(!res.status)
       this.toastr.error(res.message)
      else this.toastr.success(res.message)
    },
    error: (err) => {
      console.log(err);
      alert("Something went wrong!");
    }
  })
   this.resetPassModel = false;
   this.updatePassword={
     oldPassword:'',
    newPassword:''
   }
};

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
