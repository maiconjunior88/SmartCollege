import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { environment } from '../../environments/environment';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-teachers',
  templateUrl: './teachers.component.html',
  styleUrls: ['./teachers.component.css']
})
export class TeachersComponent implements OnInit {

  title = 'Teachers';

  public teachers: Array<Teacher>;
  private teacherPath = environment.URL_API + 'Teacher';
  teacherForm: FormGroup;

  constructor(private http: HttpClient, private fb: FormBuilder) {
    this.teacherForm = this.fb.group({
      'id': 0,
      'name': [''],
      'birthDate': [''],
      'salary': ['']
    });
  }

  ngOnInit() {
    this.GetListTeacher();
  }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Accept': 'application/json'
    })
  };

  GetListTeacher() {
    this.http.get<Teacher[]>(this.teacherPath).subscribe(result => {
      this.teachers = result;
    }, error => console.error(error));
  }

  public teacherSelected: Teacher;
  public newTeacher: boolean;

  teacherSelect(teacher) {

    if (teacher != null) {
      this.teacherSelected = teacher;

      console.log(teacher);

      this.teacherForm.setValue({
        'id': teacher.id,
        'name': teacher.name,
        'birthDate': formatDate(teacher.birthDate, "yyyy-MM-dd", "en-US"),
        'salary': teacher.salary
      });

    }
    else {
      this.teacherSelected = null;
      this.newTeacher = false;

      this.teacherForm.reset({
        'id': 0,
        'name': '',
        'birthDate': '',
        'salary': ''
      });
    }
  }

  newTeacherForm() {

    this.newTeacher = true;

    this.teacherForm.reset({
      'id': 0,
      'name': '',
      'birthDate': '',
      'salary': ''
    });
  }

  submitForm() {
    var teacher: Teacher = this.teacherForm.value;
    teacher.id > 0 ? this.update() : this.insert();
  }

  insert() {
    this.http.post<Teacher>(this.teacherPath, this.teacherForm.value, this.httpOptions).subscribe(result => {
      this.teacherSelect(null);
      this.GetListTeacher();
    }, error => console.error(error));
  }

  update() {
    this.http.put<Teacher>(this.teacherPath, this.teacherForm.value, this.httpOptions).subscribe(result => {
      this.teacherSelect(null);
      this.GetListTeacher();
    }, error => console.error(error));
  }

  teacherDelete(id) {
    if (id > 0) {
      this.http.delete<Teacher>(`${this.teacherPath}/${id}`, this.httpOptions).subscribe(result => {
        this.teacherSelect(null);
        this.GetListTeacher();
      }, error => console.error(error));
    }
  }
}

interface Teacher {
  id: number,
  name: string,
  birthdate: Date,
  salary: number
}
