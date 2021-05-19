using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Models;

namespace DB.EF
{
    public class DBContext : DbContext
    {
        public DBContext() : base("DBContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
           // Database.SetInitializer<DBContext>(new CreateDatabaseIfNotExists<DBContext>());
            //Database.SetInitializer<CollegeDBContext>(new DropCreateDatabaseAlways<CollegeDBContext>());
            // Database.SetInitializer<CollegeDBContext>(new DropCreateDatabaseIfModelChanges<CollegeDBContext>());
           // Database.SetInitializer<DBContext>(new Infrastructure.Seed.DbInitializer());
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<RelationStudentSubject> RelationStudentSubject { get; set; }
        public DbSet<RelationTeacherSubject> RelationTeacherSubject { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
