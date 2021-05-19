using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class Teachers
    {
        public int Create(Models.Teacher teacher)
        {
            using (DB.EF.DBContext db = new DB.EF.DBContext())
            {
                db.Teacher.Add(teacher);

                return db.SaveChanges();
            }
        }

        public Models.Teacher GetByID(int ID)
        {
            using (DB.EF.DBContext db = new DB.EF.DBContext())
            {
                var ret = (from s in db.Teacher
                           where s.ID == ID
                           select s).FirstOrDefault();

                return ret;
            }
        }

        public IEnumerable<Models.Teacher> GetAll()
        {
            using (DB.EF.DBContext db = new DB.EF.DBContext())
            {
                var get = (from s in db.Teacher
                           select s).ToList();

                return get;
            }
        }

        public bool Update(Models.Teacher teacher)
        {
            using (DB.EF.DBContext db = new DB.EF.DBContext())
            {
                var update = (from s in db.Teacher
                              where s.ID == teacher.ID
                              select s).SingleOrDefault();

                if (update == null)
                    return false;

                if (!string.IsNullOrEmpty(teacher.Name))
                    update.Name = teacher.Name;

                if (teacher.BirthDate != new DateTime())
                    update.BirthDate = teacher.BirthDate;

                if (teacher.Salary > 0)
                    update.Salary = teacher.Salary;

                db.SaveChanges();

                return true;
            }
        }

        public bool Delete(int id)
        {
            using (DB.EF.DBContext db = new DB.EF.DBContext())
            {
                var delete = (from s in db.Teacher
                              where s.ID == id
                              select s).FirstOrDefault();

                if (delete == null)
                    return false;

                db.Teacher.Remove(delete);

                db.SaveChanges();

                return true;
            }
        }
    }
}
