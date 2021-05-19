using DB.EF;
using Models;
using System;
using System.Collections.Generic;

namespace Infrastructure.Seed
{
    public class DbInitializer : System.Data.Entity.DropCreateDatabaseAlways<DBContext>
    {
        protected override void Seed(DBContext context)
        {
            var students = new List<Student>
            {
                new Student{ID=1,Name="Carson",BirthDate=DateTime.Parse("1988-01-11")},
                new Student{ID=2,Name="Meredith",BirthDate=DateTime.Parse("2002-09-01")},
                new Student{ID=3,Name="Arturo",BirthDate=DateTime.Parse("2003-09-01")},
                new Student{ID=4,Name="Gytis",BirthDate=DateTime.Parse("2002-09-01")},
                new Student{ID=5,Name="Yan",BirthDate=DateTime.Parse("2002-09-01")},
                new Student{ID=6,Name="Peggy",BirthDate=DateTime.Parse("2001-09-01")},
                new Student{ID=7,Name="Laura",BirthDate=DateTime.Parse("2003-09-01")},
                new Student{ID=8,Name="Nino",BirthDate=DateTime.Parse("2005-09-01")}
            };

            students.ForEach(s => context.Student.Add(s));
            context.SaveChanges();

            var teachers = new List<Teacher>
            {
                new Teacher{ID=1,Name="João",BirthDate=DateTime.Parse("2001-09-01"), Salary=2000},
                new Teacher{ID=2,Name="Nuno",BirthDate=DateTime.Parse("2005-09-01"), Salary=3000},
                new Teacher{ID=3,Name="Arturo",BirthDate=DateTime.Parse("1988-09-01"), Salary=4000},
                new Teacher{ID=4,Name="Gytis",BirthDate=DateTime.Parse("1999-09-01"), Salary=5000},
                new Teacher{ID=5,Name="Yan",BirthDate=DateTime.Parse("1960-09-01"), Salary=6000},
                new Teacher{ID=6,Name="Peggy",BirthDate=DateTime.Parse("2001-09-01"), Salary=7000}
            };

            teachers.ForEach(s => context.Teacher.Add(s));
            context.SaveChanges();

            var courses = new List<Course>
            {
                new Course{ID=1,Name="Química"},
                new Course{ID=2,Name="Ciências"},
                new Course{ID=3,Name="Matemática"},
                new Course{ID=4,Name="História"},
                new Course{ID=5,Name="Música"},
                new Course{ID=6,Name="Letras"}
            };

            courses.ForEach(s => context.Course.Add(s));
            context.SaveChanges();

            var subjects = new List<Subject>
            {
                new Subject{ID=1, CourseID=1, Name="Química 1"},
                new Subject{ID=2, CourseID=1, Name="Química 2"},
                new Subject{ID=3, CourseID=2, Name="Ciências 1"},
                new Subject{ID=4, CourseID=2, Name="Ciências 2"},
                new Subject{ID=5, CourseID=3, Name="Matemática 1"},
                new Subject{ID=6, CourseID=3, Name="Matemática 2"},
                new Subject{ID=7, CourseID=4, Name="História 1"},
                new Subject{ID=8, CourseID=4, Name="História 2"},
                new Subject{ID=9, CourseID=5, Name="Música 1"},
                new Subject{ID=10, CourseID=5, Name="Música 2"},
                new Subject{ID=11, CourseID=6, Name="Letras 1"},
                new Subject{ID=12, CourseID=6, Name="Letras 2"}

            };
            subjects.ForEach(s => context.Subject.Add(s));
            context.SaveChanges();

            var relationshipsTeacherSubject = new List<RelationTeacherSubject>
            {
                new RelationTeacherSubject{ID=1,  TeacherID=1, SubjectID=1 },
                new RelationTeacherSubject{ID=2,  TeacherID=1, SubjectID=2 },
                new RelationTeacherSubject{ID=3,  TeacherID=1, SubjectID=3 },
                new RelationTeacherSubject{ID=4,  TeacherID=2, SubjectID=4 },
                new RelationTeacherSubject{ID=5,  TeacherID=2, SubjectID=5 },
                new RelationTeacherSubject{ID=6,  TeacherID=3, SubjectID=6 },
                new RelationTeacherSubject{ID=7,  TeacherID=4, SubjectID=7 },
                new RelationTeacherSubject{ID=8,  TeacherID=4, SubjectID=8 },
                new RelationTeacherSubject{ID=9,  TeacherID=5, SubjectID=9 },
                new RelationTeacherSubject{ID=10, TeacherID=5, SubjectID=10},
                new RelationTeacherSubject{ID=11, TeacherID=5, SubjectID=11},
                new RelationTeacherSubject{ID=12, TeacherID=6, SubjectID=12 }

            };
            relationshipsTeacherSubject.ForEach(s => context.RelationTeacherSubject.Add(s));
            context.SaveChanges();

            var relationshipsStudentSubject = new List<RelationStudentSubject>
            {
                new RelationStudentSubject{ID=1, StudentID=1, SubjectID=1 },
                new RelationStudentSubject{ID=2, StudentID=1, SubjectID=2 },
                new RelationStudentSubject{ID=3, StudentID=2, SubjectID=1 },
                new RelationStudentSubject{ID=4, StudentID=2, SubjectID=2 },
                new RelationStudentSubject{ID=5, StudentID=3, SubjectID=1 },
                new RelationStudentSubject{ID=6, StudentID=3, SubjectID=2 },
                new RelationStudentSubject{ID=7, StudentID=3, SubjectID=3 },
                new RelationStudentSubject{ID=8, StudentID=3, SubjectID=4 },
                new RelationStudentSubject{ID=10,StudentID=4, SubjectID=6 },
                new RelationStudentSubject{ID=11,StudentID=5, SubjectID=7 },
                new RelationStudentSubject{ID=12,StudentID=5, SubjectID=8 },
                new RelationStudentSubject{ID=13,StudentID=6, SubjectID=9 },
                new RelationStudentSubject{ID=14,StudentID=6, SubjectID=10},
                new RelationStudentSubject{ID=15,StudentID=7, SubjectID=11},
                new RelationStudentSubject{ID=16,StudentID=7, SubjectID=12},
                new RelationStudentSubject{ID=17,StudentID=8, SubjectID=11},
                new RelationStudentSubject{ID=18,StudentID=8, SubjectID=12 }
            };
            relationshipsStudentSubject.ForEach(s => context.RelationStudentSubject.Add(s));
            context.SaveChanges();

            var grades = new List<Grade>
            {
                new Grade{ID=1,  StudentID=1, SubjectID=1  , TeacherID=1, GradeValue=10},
                new Grade{ID=2,  StudentID=1, SubjectID=2  , TeacherID=1, GradeValue=9},
                new Grade{ID=3,  StudentID=2, SubjectID=1  , TeacherID=1, GradeValue=7},
                new Grade{ID=4,  StudentID=2, SubjectID=2  , TeacherID=1, GradeValue=10},
                new Grade{ID=5,  StudentID=3, SubjectID=1  , TeacherID=1, GradeValue=5},
                new Grade{ID=6,  StudentID=3, SubjectID=2  , TeacherID=1, GradeValue=10},
                new Grade{ID=7,  StudentID=3, SubjectID=3  , TeacherID=1, GradeValue=1},
                new Grade{ID=8,  StudentID=3, SubjectID=4  , TeacherID=2, GradeValue=10},
                new Grade{ID=9,  StudentID=4, SubjectID=5  , TeacherID=2, GradeValue=10},
                new Grade{ID=10, StudentID=4, SubjectID=6  , TeacherID=3, GradeValue=10},
                new Grade{ID=11, StudentID=5, SubjectID=7  , TeacherID=4, GradeValue=9},
                new Grade{ID=12, StudentID=5, SubjectID=8  , TeacherID=4, GradeValue=10},
                new Grade{ID=13, StudentID=6, SubjectID=9  , TeacherID=5, GradeValue=2},
                new Grade{ID=14, StudentID=6, SubjectID=10 , TeacherID=5, GradeValue=10},
                new Grade{ID=15, StudentID=7, SubjectID=11 , TeacherID=5, GradeValue=10},
                new Grade{ID=16, StudentID=7, SubjectID=12 , TeacherID=6, GradeValue=5},
                new Grade{ID=17, StudentID=8, SubjectID=11 , TeacherID=5, GradeValue=10},
                new Grade{ID=18, StudentID=8, SubjectID=12 , TeacherID=6, GradeValue=4}
            };
            grades.ForEach(s => context.Grade.Add(s));
            context.SaveChanges();
        }
    }
}
