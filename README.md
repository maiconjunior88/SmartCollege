# SmartCollege
Create a CRUD of the entities (Courses, Subjects, Teacher, Student, Grades) 

Objective:

This aplication is for control college the students, courses, subjects, teachers, grades. 
The main objective is view at using C# .Net Core, Asp.Net Core Web API, MVC, Angular, BootStrap

Requirements:

Node.js

=> https://nodejs.org/en/
=> node-v14.17.3-x64.msi

Angular CLI

=> npm install -g @angular/cli

DB/EF/DBContext.cs

Database.SetInitializer<DBContext>(new CreateDatabaseIfNotExists<DBContext>());
//Database.SetInitializer<CollegeDBContext>(new DropCreateDatabaseAlways<CollegeDBContext>());
//Database.SetInitializer<CollegeDBContext>(new DropCreateDatabaseIfModelChanges<CollegeDBContext>());
Database.SetInitializer<DBContext>(new Infrastructure.Seed.DbInitializer());
