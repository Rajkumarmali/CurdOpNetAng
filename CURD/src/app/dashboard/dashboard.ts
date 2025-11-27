import { Component, OnInit } from '@angular/core';
import { Student } from '../shared/services/student';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-dashboard',
  imports: [CommonModule,FormsModule],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css',
})
export class Dashboard implements OnInit{
  constructor(private studentServices:Student,private toastr:ToastrService){}
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

  clearData(){
     this.addStudentDetail={
      fullName:'',
      email:'',
      phone:'',
      address:''
     }
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
          this.toastr.success("Student added successfully");
          this.fetchStudent();
          this.clearData();
          console.log(res)
        },error:(err:any)=>{
          this.toastr.error("Something went wrong while adding");
          console.log(err);
        }
       })
       this.addStudentModel = false
  }

  cancelAdd(){
      this.addStudentModel = false;
      this.clearData();
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
        this.toastr.success("Student updated successfully");
        this.fetchStudent();
        console.log(res)
      },error:(err:any)=>{
        this.toastr.error("Something went wrong while updating");
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
           this.toastr.success("Student deleted successfully");
          this.fetchStudent();
          console.log(res);
        },error:(err)=>{
          this.toastr.error("Something went wrong while deleting");
          console.log(err);
        }
      })
  }
}
