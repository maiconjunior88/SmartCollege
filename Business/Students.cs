using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class Students
    {
        public int Create(Student student)
        {
            using (DB.EF.DBContext db = new DB.EF.DBContext())
            {
                db.Student.Add(student);

                return db.SaveChanges();
            }
        }

        public Student GetByID(int ID)
        {
            using (DB.EF.DBContext db = new DB.EF.DBContext())
            {
                var ret = (from s in db.Student
                           where s.ID == ID
                           select s).FirstOrDefault();

                return ret;
            }
        }

        public IEnumerable<Student> GetAll()
        {
            using (DB.EF.DBContext db = new DB.EF.DBContext())
            {
                var get = (from s in db.Student
                           select s).ToList();

                return get;
            }
        }

        public bool Update(Student student)
        {
            using (DB.EF.DBContext db = new DB.EF.DBContext())
            {
                var update = (from s in db.Student
                              where s.ID == student.ID
                              select s).SingleOrDefault();

                if (update == null)
                    return false;

                if (!string.IsNullOrEmpty(student.Name))
                    update.Name = student.Name;

                if (student.BirthDate != new DateTime())
                    update.BirthDate = student.BirthDate;

                db.SaveChanges();

                return true;
            }
        }

        public bool Delete(int ID)
        {
            using (DB.EF.DBContext db = new DB.EF.DBContext())
            {
                var delete = (from s in db.Student
                              where s.ID == ID
                              select s).FirstOrDefault();

                if (delete == null)
                    return false;

                db.Student.Remove(delete);

                db.SaveChanges();

                return true;
            }
        }
    }
}
