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

  title = 'Grade';

  public subjects: Array<Subject>;
  private subjectPath = environment.URL_API + 'Subject';

  gradeForm: FormGroup;

  constructor(private http: HttpClient, private fb: FormBuilder) {
    this.gradeForm = this.fb.group({
      'id': 0,
      'subjectID': 0,
      'name': ['']
    });
  }

  newGradeForm() {

    console.log(this.subjects)

    this.newGrade = true;

    this.gradeForm.reset({
      'id': 0,
      'subjectID': 0,
      'name': '',
    });
  }

  public gradeSelected: Subject;
  public newGrade: boolean;

  gradeSelect(grade) {

    if (grade != null) {
      this.gradeSelected = grade;

      this.gradeForm = this.fb.group({
        'id': grade.id,
        'subjectID': grade.subjecID,
        'name': grade.name
      });

    }
    else {
      this.gradeSelected = null;
      this.newGrade = false;

      this.newGradeForm() 
    }
  }

  GetListSubject() {
    this.http.get<Subject[]>(this.subjectPath).subscribe(result => {
      this.subjects = result;
    }, error => console.error(error));
  }

  ngOnInit() {
    this.GetListSubject();
  }
}

interface Subject {
  id: number,
  subjectName: string
}


