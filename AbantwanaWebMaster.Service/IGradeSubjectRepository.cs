using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public interface IGradeSubjectRepository : IDisposable
    {
        GradeSubject GetById(Int32 id);
        List<GradeSubject> GetAll();
        void Insert(GradeSubject model);
        void Update(GradeSubject model);
        void Delete(GradeSubject model);
        IEnumerable<GradeSubject> Find(Func<GradeSubject, bool> predicate);   

    }
}
