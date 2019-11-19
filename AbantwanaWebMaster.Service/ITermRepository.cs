using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public interface ITermRepository : IDisposable
    {
        Term GetById(Int32 id);
        List<Term> GetAll();
        void Insert(Term model);
        void Update(Term model);
        void Delete(Term model);
        IEnumerable<Term> Find(Func<Term, bool> predicate);   

    }
}
