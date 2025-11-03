import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class Student {

   constructor(private http:HttpClient){}

   listOfStudent(){
      return  this.http.get("http://localhost:5050/api/Student");
   }
   addStudent(student:any){
     return this.http.post("http://localhost:5050/api/Student",student)
   }
   updateStudent(student:any){
       return this.http.post("http://localhost:5050/api/Student/update",student);
   }
   deleteStudent(studentId:any){
     return this.http.delete(`http://localhost:5050/api/Student/${studentId}`);
   }
}
