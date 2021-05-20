import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-subjects',
  templateUrl: './subjects.component.html',
  styleUrls: ['./subjects.component.css']
})
export class SubjectsComponent implements OnInit {

  title = 'Subjects';

  public subjects: Array<Subject>;
  public courses: Array<Course>;
  private subjectPath = environment.URL_API + 'Subject';
  private coursePath = environment.URL_API + 'Course';
  subjectForm: FormGroup;

  constructor(private http: HttpClient, private fb: FormBuilder) {
    this.subjectForm = this.fb.group({
      'id': 0,
      'courseID': 0,
      'name': ['']
    });
  }

  ngOnInit() {
    this.GetListSubject();
    this.GetListCourse();
  }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    })
  };

  GetListCourse() {
    this.http.get<Course[]>(this.coursePath).subscribe(result => {
      this.courses = result;
    }, error => console.error(error));
  }

  GetListSubject() {
    this.http.get<Subject[]>(this.subjectPath).subscribe(result => {
      this.subjects = result;
    }, error => console.error(error));
  }

  public subjectSelected: Subject;
  public newSubject: boolean;

  subjectSelect(subject) {

    if (subject != null) {
      this.subjectSelected = subject;

      this.subjectForm = this.fb.group({
        'id': subject.subjectID,
        'courseID': subject.courseID,
        'name': subject.subjectName
      });

    }
    else {
      this.subjectSelected = null;
      this.newSubject = false;

      this.subjectForm.reset({
        'id': 0,
        'courseID': 0,
        'name': ''
      });
    }
  }

  newSubjectForm() {

    this.newSubject = true;

    this.subjectForm.reset({
      'id': 0,
      'courseID': 0,
      'name': ''
    });
  }

  submitForm() {
    var student: Subject = this.subjectForm.value;
    student.subjectID > 0 ? this.update() : this.insert();
  }

  insert() {
    this.http.post<Subject>(this.subjectPath, this.subjectForm.value, this.httpOptions).subscribe(result => {
      this.subjectSelect(null);
      this.GetListSubject();
    }, error => console.error(error));
  }

  update() {
    this.http.put<Subject>(this.subjectPath, this.subjectForm.value, this.httpOptions).subscribe(result => {
      this.subjectSelect(null);
      this.GetListSubject();
    }, error => console.error(error));
  }

  subjectDelete(id) {
    if (id > 0) {
      this.http.delete<Subject>(`${this.subjectPath}/${id}`, this.httpOptions).subscribe(result => {
        this.subjectSelect(null);
        this.GetListSubject();
      }, error => console.error(error));
    }
  }
}

interface Subject {
  subjectID: number,
  subjectName: string,
  courseID: number,
  courseName:string
}

interface Course {
  id: number,
  name: string
}
