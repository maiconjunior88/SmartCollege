using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class Grade
    {
        public int Create(Models.Grade grade)
        {
            using (DB.EF.DBContext db = new DB.EF.DBContext())
            {
                db.Grade.Add(grade);

                return db.SaveChanges();
            }
        }

        public Models.Grade GetByID(int ID)
        {
            using (DB.EF.DBContext db = new DB.EF.DBContext())
            {
                var ret = (from s in db.Grade
                           where s.ID == ID
                           select s).FirstOrDefault();

                return ret;
            }
        }

        public IEnumerable<Models.Grade> GetAll()
        {
            using (DB.EF.DBContext db = new DB.EF.DBContext())
            {
                var get = (from s in db.Grade
                           select s).ToList();

                return get;
            }
        }

        public bool Update(Models.Grade grade)
        {
            using (DB.EF.DBContext db = new DB.EF.DBContext())
            {
                var update = (from s in db.Grade
                              where s.ID == grade.ID
                              select s).SingleOrDefault();

                if (update == null)
                    return false;

                if (grade.StudentID > 0)
                    update.StudentID = grade.StudentID;

                if (grade.TeacherID > 0)
                    update.TeacherID = grade.TeacherID;

                if (grade.SubjectID > 0)
                    update.SubjectID = grade.SubjectID;

                if (grade.GradeValue > 0)
                    update.GradeValue = grade.GradeValue;

                db.SaveChanges();

                return true;
            }
        }

        public bool Delete(int id)
        {
            using (DB.EF.DBContext db = new DB.EF.DBContext())
            {
                var delete = (from s in db.Grade
                              where s.ID == id
                              select s).FirstOrDefault();

                if (delete == null)
                    return false;

                db.Grade.Remove(delete);

                db.SaveChanges();

                return true;
            }
        }
    }
}
