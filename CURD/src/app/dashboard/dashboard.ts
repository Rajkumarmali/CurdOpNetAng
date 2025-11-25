import { Component, OnInit } from '@angular/core';
import { Student } from '../shared/services/student';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  imports: [CommonModule,FormsModule],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css',
})
export class Dashboard implements OnInit{
  constructor(private studentServices:Student){}
  studentData:any;
  addStudentModel:boolean = false;
  updateId:number | null=null

  updateStudentData:any={
    id:'',
    fullName:'',
    email:'',
    phone:'',
    address:''
  }

  addStudentDetail:any={
    fullName:'',
    email:'',
    phone:'',
    address:''
  }


  ngOnInit():void{
     this.fetchStudent();
  }

  fetchStudent(){
      this.studentServices.listOfStudent().subscribe({
        next:(res:any)=>{
           this.studentData=res.students;
           console.log(this.studentData);
        },error:(err)=>{
          console.log(err);
        }
      })
  }

  addStudent(){
     this.addStudentModel=true;
  }

  onAddStudent(){
       this.studentServices.addStudent(this.addStudentDetail).subscribe({
        next:(res:any)=>{
          this.fetchStudent();
          console.log(res)
        },error:(err:any)=>{
          console.log(err);
        }
       })
       this.addStudentModel = false
  }
  onUpdate(id:any){
     this.updateId=id;
     const student = this.studentData.find((s:any)=>s.id==id);
     this.updateStudentData.id = id;
     if(student){
      this.updateStudentData.fullName = student.fullName,
      this.updateStudentData.email=student.email,
      this.updateStudentData.phone = student.phone,
      this.updateStudentData.address = student.address
     }
     console.log(id);
  }
  saveUpdate(){
    this.studentServices.updateStudent(this.updateStudentData).subscribe({
      next:(res:any)=>{
        this.fetchStudent();
        console.log(res)
      },error:(err:any)=>{
        console.log(err);
      }
    })
     this.updateId=null;
  }

  canelEdit(){
      this.updateId=null;
  }
  onDelete(id:any){
      this.studentServices.deleteStudent(id).subscribe({
        next:(res:any)=>{
          this.fetchStudent();
          console.log(res);
        },error:(err)=>{
          console.log(err);
        }
      })
  }
}
