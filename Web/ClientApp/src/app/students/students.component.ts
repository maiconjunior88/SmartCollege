import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { environment } from '../../environments/environment';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent implements OnInit {

  title = 'Students';

  public students: Array<Student>;
  private studentPath = environment.URL_API + 'Student';
  studentForm: FormGroup;

  constructor(private http: HttpClient, private fb: FormBuilder) {
    this.studentForm = this.fb.group({
      'id': 0,
      'name': [''],
      'birthDate': ['']
    });
  }

  ngOnInit() {
    this.GetListStudent();
  }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    })
  };

  GetListStudent() {
    this.http.get<Student[]>(this.studentPath).subscribe(result => {
      this.students = result;
    }, error => console.error(error));
  }

  public studentSelected: Student;
  public newStudent: boolean;

  studentSelect(student) {
    if (student != null) {
      this.studentSelected = student;

      this.studentForm.setValue({
        'id': student.id,
        'name': student.name,
        'birthDate': formatDate(student.birthDate, "yyyy-MM-dd", "en-US")
      });

    }
    else {
      this.studentSelected = null;
      this.newStudent = false;

      this.studentForm.reset({
        'id': 0,
        'name': '',
        'birthDate': ''
      });
    }
  }

  newStudentForm() {

    this.newStudent = true;

    this.studentForm.reset({
      'id': 0,
      'name': '',
      'birthDate': ''
    });
  }

  submitForm() {
    var student: Student = this.studentForm.value;
    student.id > 0 ? this.update() : this.insert();
  }

  insert() {
    this.http.post<Student>(this.studentPath, this.studentForm.value, this.httpOptions).subscribe(result => {
      this.studentSelect(null);
      this.GetListStudent();
    }, error => console.error(error));
  }

  update() {
    this.http.put<Student>(this.studentPath, this.studentForm.value, this.httpOptions).subscribe(result => {
      this.studentSelect(null);
      this.GetListStudent();
    }, error => console.error(error));
  }

  studentDelete(id) {
    if (id > 0) {
      this.http.delete<Student>(`${this.studentPath}/${id}`, this.httpOptions).subscribe(result => {
        this.studentSelect(null);
        this.GetListStudent();
      }, error => console.error(error));
    }
  }
}

interface Student {
  id: number,
  name: string,
  birthDate: Date
}
