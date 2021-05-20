using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class Subjects
    {
        public int Create(Models.SubjectList subject)
        {
            using (DB.EF.DBContext db = new DB.EF.DBContext())
            {
                Models.Subject sub = new Subject();
                sub.CourseID = subject.CourseID;
                sub.Name = subject.SubjectName;

                db.Subject.Add(sub);

                return db.SaveChanges();
            }
        }

        public Models.Subject GetByID(int ID)
        {
            using (DB.EF.DBContext db = new DB.EF.DBContext())
            {
                var ret = (from s in db.Subject
                           where s.ID == ID
                           select s).FirstOrDefault();

                return ret;
            }
        }

        public IEnumerable<SubjectList> GetAll()
        {
            using (DB.EF.DBContext db = new DB.EF.DBContext())
            {
                var get = (from s in db.Subject
                           join c in db.Course on s.CourseID equals c.ID
                           select new SubjectList
                           {
                               SubjectID = s.ID,
                               SubjectName = s.Name,
                               CourseID = s.CourseID,
                               CourseName = c.Name
                           }).ToList();

                return get;
            }
        }

        public bool Update(Models.Subject subject)
        {
            using (DB.EF.DBContext db = new DB.EF.DBContext())
            {
                var update = (from s in db.Subject
                              where s.ID == subject.ID
                              select s).SingleOrDefault();

                if (update == null)
                    return false;

                if (!string.IsNullOrEmpty(subject.Name))
                    update.Name = subject.Name;

                if (subject.CourseID > 0)
                    update.CourseID = subject.CourseID;

                db.SaveChanges();

                return true;
            }
        }

        public bool Delete(int id)
        {
            using (DB.EF.DBContext db = new DB.EF.DBContext())
            {
                var delete = (from s in db.Subject
                              where s.ID == id
                              select s).FirstOrDefault();

                if (delete == null)
                    return false;

                db.Subject.Remove(delete);

                db.SaveChanges();

                return true;
            }
        }
    }
}
