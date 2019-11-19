using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbantwanaWebMaster.Model;
using AbantwanaWebMaster.Service;
using AbantwanaWebMaster.Data;
using System.Data.Entity;


namespace AbantwanaWebMaster.BusinessLogic
{
    public class SubjectBusiness
    {
        DataContext db = new DataContext();


        public List<Model.Subject> GetSubjects()
        {
            using (var SubjectRep = new SubjectRepository())
            {
                return SubjectRep.GetAll().Select(x => new Model.Subject()
                {
                    subjectId = x.subjectId,
                    subjectName= x.subjectName
                }).ToList();
            }


        }
        public List<Model.GradeSubject> GetGradeSubjects(int id)
        {
            using (var SubjectRep = new GradeSubjectRepository())
            {
                return SubjectRep.GetAll().Where(p=>p.gradeId==id).Select(x => new Model.GradeSubject()
                {
                    subjectId = x.subjectId,
                    gradeId= x.gradeId,
                    subjectName=x.subject.subjectName,
                    active=x.active,
                    requirement=x.requirement
                }).ToList();
            }


        }

        public int counter()
        {

            using (var SubjectRep = new SubjectRepository())
            {
                return SubjectRep.GetAll().Count();
            }
        }

        public void addSubject(Model.Subject subject)
        {

            using (var SubjectRep = new SubjectRepository())
            {

                var addSub = new Data.Subject
                {
                    subjectId = subject.subjectId,
                    subjectName = subject.subjectName
                    
                };
                SubjectRep.Insert(addSub);
            }
        }
        public void addGradeSubject(Model.GradeSubject x)
        {

            using (var SubjectRep = new GradeSubjectRepository())
            {

                var addSub = new Data.GradeSubject
                {
                    subjectId = x.subjectId,
                    gradeId = x.gradeId,
                    active = x.active,
                    requirement = x.requirement

                };
                SubjectRep.Insert(addSub);
            }
        }
        public void updateGradeSubject(Model.GradeSubject x)
        {

            using (var SubjectRep = new GradeSubjectRepository())
            {

                var addSub = new Data.GradeSubject
                {
                    subjectId = x.subjectId,
                    gradeId = x.gradeId,
                    active = x.active,
                    requirement = x.requirement

                };
                db.Entry(addSub).State = EntityState.Modified;
                db.SaveChanges();
               // SubjectRep.Update(addSub);
            }
        }

    }
}
