import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent implements OnInit {

  title = 'Courses';

  public courses: Array<Course>;
  private coursePath = environment.URL_API + 'Course';
  courseForm: FormGroup;

  constructor(private http: HttpClient, private fb: FormBuilder) {
    this.courseForm = this.fb.group({
      'id': 0,
      'name': ['']
    });
  }

  ngOnInit() {
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

  public courseSelected: Course;
  public newCourse: boolean;

  courseSelect(course) {
    if (course != null) {
      this.courseSelected = course;

      this.courseForm.setValue({
        'id': course.id,
        'name': course.name
      });
    }
    else {
      this.courseSelected = null;
      this.newCourse = false;

      this.courseForm.reset({
        'id': 0,
        'name': ''
      });
    }
  }

  newCourseForm() {

    this.newCourse = true;

    this.courseForm.reset({
      'id': 0,
      'name': ''
    });
  }

  submitForm() {
    var course: Course = this.courseForm.value;
    course.id > 0 ? this.update() : this.insert();
  }

  insert() {
    this.http.post<Course>(this.coursePath, this.courseForm.value, this.httpOptions).subscribe(result => {
      this.courseSelect(null);
      this.GetListCourse();
    }, error => console.error(error));
  }

  update() {
    this.http.put<Course>(this.coursePath, this.courseForm.value, this.httpOptions).subscribe(result => {
      this.courseSelect(null);
      this.GetListCourse();
    }, error => console.error(error));
  }

  courseDelete(id) {
    if (id > 0) {
      this.http.delete<Course>(`${this.coursePath}/${id}`, this.httpOptions).subscribe(result => {
        this.courseSelect(null);
        this.GetListCourse();
      }, error => console.error(error));
    }
  }
}

interface Course {
  id: number,
  name: string
}

