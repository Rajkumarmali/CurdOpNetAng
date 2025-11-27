import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { Auth } from '../shared/services/auth';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-signin',
  imports: [RouterModule,FormsModule],
  templateUrl: './signin.html',
  styleUrl: './signin.css',
})
export class Signin {
     constructor (private authServices:Auth,private router:Router,private toastr:ToastrService){}
     user:any={
       firstName:'',
       lastName:'',
       email:'',
       password:''
     }

     onSubmit(){
         this.authServices.signIn(this.user).subscribe({
          next:(res:any)=>{
            if(res.result.succeeded){
             this.toastr.success("User are successfully register")
             this.router.navigate(["/login"])
            }
            else{
               this.toastr.error(res?.result?.errors[0]?.description)
               console.log(res.result.errors);
            }
          },error:(err)=>{
            console.log("error",err);
          }
         })
     }
}
