using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class Courses
    {
        public int Create(Models.Course course)
        {
            using (DB.EF.DBContext db = new DB.EF.DBContext())
            {
                db.Course.Add(course);

                return db.SaveChanges();
            }
        }

        public Models.Course GetByID(int ID)
        {
            using (DB.EF.DBContext db = new DB.EF.DBContext())
            {
                var ret = (from s in db.Course
                           where s.ID == ID
                           select s).FirstOrDefault();

                return ret;
            }
        }

        public IEnumerable<Course> GetAll()
        {
            using (DB.EF.DBContext db = new DB.EF.DBContext())
            {
                var get = (from s in db.Course
                           select s).ToList();

                return get;
            }
        }

        public bool Update(Models.Course course)
        {
            using (DB.EF.DBContext db = new DB.EF.DBContext())
            {
                var update = (from s in db.Course
                              where s.ID == course.ID
                              select s).SingleOrDefault();

                if (update == null)
                    return false;

                if (!string.IsNullOrEmpty(course.Name))
                    update.Name = course.Name;

                db.SaveChanges();

                return true;
            }
        }

        public bool Delete(int id)
        {
            using (DB.EF.DBContext db = new DB.EF.DBContext())
            {
                var delete = (from s in db.Course
                              where s.ID == id
                              select s).FirstOrDefault();

                if (delete == null)
                    return false;

                db.Course.Remove(delete);

                db.SaveChanges();

                return true;
            }
        }
    }
}
