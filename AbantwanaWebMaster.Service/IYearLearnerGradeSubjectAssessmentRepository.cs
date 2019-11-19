using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public interface IYearLearnerGradeSubjectAssessmentRepository : IDisposable
    {
        YearLearnerGradeSubjectAssessment GetById(Int32 id);
        List<YearLearnerGradeSubjectAssessment> GetAll();
        void Insert(YearLearnerGradeSubjectAssessment model);
        void Update(YearLearnerGradeSubjectAssessment model);
        void Delete(YearLearnerGradeSubjectAssessment model);
        IEnumerable<YearLearnerGradeSubjectAssessment> Find(Func<YearLearnerGradeSubjectAssessment, bool> predicate);   

    }
}
