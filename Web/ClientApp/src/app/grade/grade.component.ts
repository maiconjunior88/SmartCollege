import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-grade',
  templateUrl: './grade.component.html',
  styleUrls: ['./grade.component.css']
})
export class GradeComponent implements OnInit {

  title = 'Subjects';

  public subjects: Array<Subject>;
  public courses: Array<Course>;
  public students: Array<Student>;
  private subjectPath = environment.URL_API + 'Subject';
  private coursePath = environment.URL_API + 'Course';
  private studentPath = environment.URL_API + 'Student';

  constructor(private http: HttpClient, private fb: FormBuilder) {

  }

  GetListSubject() {
    this.http.get<Subject[]>(this.subjectPath).subscribe(result => {
      this.subjects = result;
    }, error => console.error(error));
  }

  GetListCourse() {
    this.http.get<Course[]>(this.coursePath).subscribe(result => {
      this.courses = result;
    }, error => console.error(error));
  }

  GetListStudent() {
    this.http.get<Student[]>(this.studentPath).subscribe(result => {
      this.students = result;
    }, error => console.error(error));
  }

  ngOnInit() {
    this.GetListSubject();
    this.GetListCourse();
    this.GetListStudent();
  }
}

interface Subject {
  id: number,
  name: string,
  courseID: number,
  courseName: string
}

interface Course {
  id: number,
  name: string
}

interface Student
{
  id: number,
  name: string,
  birthDate: Date,
}

