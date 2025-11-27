import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { Auth } from '../shared/services/auth';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  imports: [RouterLink,FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
    constructor (private authServices:Auth,private router:Router,private toastr:ToastrService){}

    user:any={
      email:'',
      password:''
    }

    onLogin(){
         this.authServices.logIn(this.user).subscribe({
          next:(res:any)=>{
            this.authServices.setLogin(res.token);
            this.toastr.success("User successfully login")
            this.router.navigate(['dashboard'])
            console.log(res)
          },error:(err)=>{
            this.toastr.error(err?.error?.text)
            console.log("Error : ",err);
          }
         })
    }
}
