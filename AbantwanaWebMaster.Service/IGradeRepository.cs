using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public interface IGradeRepository : IDisposable
    {
        Grade GetById(Int32 id);
        List<Grade> GetAll();
        void Insert(Grade model);
        void Update(Grade model);
        void Delete(Grade model);
        IEnumerable<Grade> Find(Func<Grade, bool> predicate);   

    }
}
