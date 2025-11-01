import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { Auth } from '../shared/services/auth';

@Component({
  selector: 'app-login',
  imports: [RouterLink,FormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
    constructor (private authServices:Auth,private router:Router){}

    user:any={
      email:'',
      password:''
    }

    onSubmit(){
         this.authServices.logIn(this.user).subscribe({
          next:(res)=>{
            this.router.navigate(['dashboard'])
            console.log(res)
          },error:(err)=>{
            console.log("Error",err);
          }
         })
    }
}
