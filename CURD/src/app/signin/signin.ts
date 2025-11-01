import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { Auth } from '../shared/services/auth';

@Component({
  selector: 'app-signin',
  imports: [RouterModule,FormsModule],
  templateUrl: './signin.html',
  styleUrl: './signin.css',
})
export class Signin {
     constructor (private authServices:Auth,private router:Router){}
     user:any={
       firstName:'',
       lastName:'',
       email:'',
       password:''
     }

     onSubmit(){
         this.authServices.signIn(this.user).subscribe({
          next:(res:any)=>{
            if(res.result.succeeded)
             this.router.navigate(["/login"])
            console.log(res);
          },error:(err)=>{
            console.log("error",err);
          }
         })
     }
}
