using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public interface IYearLearnerGradeSubjectRepository : IDisposable
    {
        YearLearnerGradeSubject GetById(Int32 id);
        List<YearLearnerGradeSubject> GetAll();
        void Insert(YearLearnerGradeSubject model);
        void Update(YearLearnerGradeSubject model);
        void Delete(YearLearnerGradeSubject model);
        IEnumerable<YearLearnerGradeSubject> Find(Func<YearLearnerGradeSubject, bool> predicate);   

    }
}
