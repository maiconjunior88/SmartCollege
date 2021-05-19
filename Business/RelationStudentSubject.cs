using Models;
using System;
using System.Linq;

namespace Business
{
    public class RelationStudentSubject
    {
        public int Create(Models.RelationStudentSubject relationStudentSubject)
        {
            using (DB.EF.DBContext db = new DB.EF.DBContext())
            {
                db.RelationStudentSubject.Add(relationStudentSubject);

                return db.SaveChanges();
            }
        }

        public Models.RelationStudentSubject GetByID(int ID)
        {
            using (DB.EF.DBContext db = new DB.EF.DBContext())
            {
                var ret = (from s in db.RelationStudentSubject  
                           where s.ID == ID
                           select s).FirstOrDefault();

                return ret;
            }
        }

        public bool Update(Models.RelationStudentSubject relationStudentSubject)
        {
            using (DB.EF.DBContext db = new DB.EF.DBContext())
            {
                var update = (from s in db.RelationStudentSubject
                              where s.ID == relationStudentSubject.ID
                              select s).SingleOrDefault();

                if (update == null)
                    return false;

                if (relationStudentSubject.StudentID >0 )
                    update.StudentID = relationStudentSubject.ID;

                if (relationStudentSubject.SubjectID>0)
                    update.SubjectID = relationStudentSubject.SubjectID;

                db.SaveChanges();

                return true;
            }
        }

        public bool Delete(Models.RelationStudentSubject relationStudentSubject)
        {
            using (DB.EF.DBContext db = new DB.EF.DBContext())
            {
                var delete = (from s in db.RelationStudentSubject
                              where s.ID == relationStudentSubject.ID
                              select s).FirstOrDefault();

                if (delete == null)
                    return false;

                db.RelationStudentSubject.Remove(delete);

                db.SaveChanges();

                return true;
            }
        }
    }
}
