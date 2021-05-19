import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { StudentsComponent } from './students/students.component';
import { TeachersComponent } from './teachers/teachers.component';
import { CoursesComponent } from './courses/courses.component';
import { SubjectsComponent } from './subjects/subjects.component';
import { GradeComponent } from './grade/grade.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NavComponent } from './nav/nav.component';
import { TitleComponent } from './title/title.component';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    StudentsComponent,
    TeachersComponent,
    CoursesComponent,
    SubjectsComponent,
    GradeComponent,
    NavComponent,
    TitleComponent

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { path: 'dashboard', component: DashboardComponent },
      { path: 'students', component: StudentsComponent },
      { path: 'teachers', component: TeachersComponent },
      { path: 'courses', component: CoursesComponent },
      { path: 'subjects', component: SubjectsComponent },
      { path: 'grade', component: GradeComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
